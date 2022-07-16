import { CuocChinhDialogComponent } from './cuocchinh-dialog/cuocchinh-dialog.component';
//import { CauHinhVungComponent } from './../cauhinhvung/cauhinhvung.component';
import { CtcuochinhComponent } from './../ctcuochinh/ctcuochinh.component';
import { DomesticFreightStepApi,
  DomesticDomesticFreightStepGetPagingQuery,
   DomesticDomesticFreightStepGetPagingQueryResult,
   DomesticDomesticFreightStepDeleteCommand } from './../../../_shared/bccp-api.services';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cuocphi-cuocchinh',
  templateUrl: './cuocchinh.component.html',
  styleUrls: ['./cuocchinh.component.scss']
})
export class CuocChinhComponent implements OnInit {
 // tslint:disable-next-line: no-input-rename
 @Input('mode') mode: string;
 // tslint:disable-next-line: no-input-rename
 @Input('ruleId') ruleId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticDomesticFreightStepGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel;
  public typeView: string;


  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private domesticFreightStepApi: DomesticFreightStepApi,
    private ruote: ActivatedRoute
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      stepCode: [''],
    });
    if (this.ruote.snapshot.params.ruleId){
      this.ruleId = parseInt(this.ruote.snapshot.params.ruleId, 10);
      this.typeView = 'form';
    }
    else{
      this.typeView = 'control';
    }
    // const queryData = this.ruote.snapshot.queryParams;
    // if (queryData.ruleId) {
    //   this.ruleId = queryData.ruleId;
    // } else {
    //   this.ruleId = parseInt(this.ruote.snapshot.params.ruleId, 10);
    // }
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DomesticDomesticFreightStepGetPagingQuery({
      ...paging
    });

    if (this.ruleId) {
      params.domesticFreightRuleId = this.ruleId;
    }
    if (formData.stepCode) {
      params.stepCode = formData.stepCode;
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.domesticFreightStepApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset(); 
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới';
      option.size = DialogSize.medium;
      option.component = CuocChinhDialogComponent;
      option.inputs = {
        ruleId: this.ruleId,
        mode: DialogMode.add
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          this.getData({ ...this.paging, page: 1 });
        }
      }
    });
  }

  async showDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem thông tin dữ liệu';
      option.size = DialogSize.large;
      option.component = CuocChinhDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.view
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async editDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa dữ liệu';
      option.size = DialogSize.medium;
      option.component = CuocChinhDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData(this.paging);
      }
    });
  }
  async detailDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Chi tiết bước cước';
      option.size = DialogSize.large;
      debugger;
      option.component = CtcuochinhComponent;
      option.inputs = {
        ruleId:this.ruleId,
        stepId:id,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData(this.paging);
      }
    });
  }
  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new DomesticDomesticFreightStepDeleteCommand({
      id: listId
    });
    const rs = await this.domesticFreightStepApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
