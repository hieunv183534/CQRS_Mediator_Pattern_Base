import { LienTinhDialogComponent } from './lientinh-dialog/lientinh-dialog.component';
import { ProvinceApi } from './../../../../_shared/bccp-api.services';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ActivatedRoute } from '@angular/router';
import { DomesticDetailProvinceFreightGetPagingQueryResult, DomesticDetailProvinceFreightGetPagingQuery,
  DetailProvinceFreightApi,  DomesticProvinceInterconnectDeleteCommand
 } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-ctcuochinh-lientinh',
  templateUrl: './lientinh.component.html',
  styleUrls: ['./lientinh.component.scss']
})
export class LienTinhComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
 @Input('mode') mode: string;
 // tslint:disable-next-line: no-input-rename
 @Input('ruleId') ruleId: number;
 // tslint:disable-next-line: no-input-rename
 @Input('stepId') stepId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticDetailProvinceFreightGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  public lstStatus: any[] = [
    { value: 1, text: 'Đang sử dụng' },
    { value: 2, text: 'Đã xóa' },
  ];

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private detailProvinceFreightApi: DetailProvinceFreightApi,
    public provinceApi: ProvinceApi,
    private ruote: ActivatedRoute
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      fromProvinceCode: [],
      toProvinceCode: [],
      domesticFreightBlockId: []
    });
    // const queryData = this.ruote.snapshot.queryParams;
    // if (queryData.ruleId) {
    //   this.ruleId = queryData.ruleId;
    // } else {
    //   this.ruleId = parseInt(this.ruote.snapshot.params.ruleId);
    // }
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DomesticDetailProvinceFreightGetPagingQuery({
      ...paging
    });

    if (this.ruleId) {
      where.and.push({domesticFreightRuleId: this.ruleId});
    }
    if (this.stepId) {
      where.and.push({domesticFreightStepId: this.stepId});
    }
    if (formData.fromProvinceCode) {
      where.and.push({fromProvinceCode: formData.fromProvinceCode});
    }
    if (formData.toProvinceCode) {
      where.and.push({toProvinceCode: formData.toProvinceCode});
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.detailProvinceFreightApi.getPaging(params).toPromise();
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
    debugger;
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới';
      option.size = DialogSize.full;
      option.component = LienTinhDialogComponent;
      option.inputs = {
        ruleId: this.ruleId,
        stepId: this.stepId,
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
      option.size = DialogSize.full;
      option.component = LienTinhDialogComponent;
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
      option.size = DialogSize.full;
      option.component = LienTinhDialogComponent;
      option.inputs = {
        id,
        stepId: this.stepId,
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

    const params = new DomesticProvinceInterconnectDeleteCommand({
      id: listId
    });
    const rs = await this.detailProvinceFreightApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }
}
