
import { CuocVASUsingApi,
  DomesticVASUsingGetPagingQuery,
  DomesticVASUsingGetPagingQueryResult,
  DomesticVASUsingDeleteCommand,
  DomesticValueAddedServiceFreightPercentMainFreightApi,
  DomesticDomesticValueAddedServiceFreightPercentMainFreightDeleteByCodeCommand,
  DomesticValueAddedServiceFreightPerItemApi,
  DomesticDomesticValueAddedServiceFreightPerItemDeleteByCodeCommand } from '../../../_shared/bccp-api.services';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ActivatedRoute } from '@angular/router';
import { MotbuuguiComponent } from './motbuugui/motbuugui.component';
import { NackhoiluongComponent } from './nackhoiluong/nackhoiluong.component';
import { PhantramcuocchinhComponent } from './phantramcuocchinh/phantramcuocchinh.component';
@Component({
  selector: 'app-cuocphi-cuocdvct',
  templateUrl: './cuocdvct.component.html',
  styleUrls: ['./cuocdvct.component.scss']
})
export class CuocDvctComponent implements OnInit {
 // tslint:disable-next-line: no-input-rename
 @Input('mode') mode: string;
 // tslint:disable-next-line: no-input-rename
 @Input('ruleId') ruleId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticVASUsingGetPagingQueryResult[] = [];
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

  public lstStatus: any[] = [
    { value: 1, text: 'Đang sử dụng' },
    { value: 2, text: 'Đã xóa' },
  ];

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private vasUsingApi: CuocVASUsingApi,
    private domesticValueAddedServiceFreightPerItemApi: DomesticValueAddedServiceFreightPerItemApi,
    private domesticValueAddedServiceFreightPercentMainFreightApi: DomesticValueAddedServiceFreightPercentMainFreightApi,
    private ruote: ActivatedRoute
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
     
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
    //   this.ruleId = parseInt(this.ruote.snapshot.params.ruleId);
    // }
    await this.getData();
  }

  async getData(paging: PagingModel = {}): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DomesticVASUsingGetPagingQuery({
      ...paging
    });    

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.vasUsingApi.getPaging(params).toPromise();
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
    // const dialog = this.dialogService.openDialog(option => {
    //   option.title = 'Thêm mới';
    //   option.size = DialogSize.full;
    //   option.component = KhuVucDialogComponent;
    //   option.inputs = {
    //     ruleId: this.ruleId,
    //     mode: DialogMode.add
    //   };
    // }, (eventName, eventValue) => {
    //   if (eventName === 'onClose') {
    //     this.dialogService.closeDialogById(dialog.id);
    //     if (eventValue) {
    //       this.getData({ ...this.paging, page: 1 });
    //     }
    //   }
    // });
  }

  async showDataDialog(id: number): Promise<void> {
    // const dialog = this.dialogService.openDialog(option => {
    //   option.title = 'Xem thông tin dữ liệu';
    //   option.size = DialogSize.full;
    //   option.component = KhuVucDialogComponent;
    //   option.inputs = {
    //     id,
    //     mode: DialogMode.view
    //   };
    // }, (eventName) => {
    //   if (eventName === 'onClose') {
    //     this.dialogService.closeDialogById(dialog.id);
    //   }
    // });
  }

  async editDataDialog(id: number, method: number, vascode: string): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {      
      option.size = DialogSize.full;     
      switch ( method)
      {
        case 1:
          option.title = 'Cách tính cước theo nấc khối lượng bưu gửi';
          option.component = NackhoiluongComponent;
          break;
        case 5:
          option.title = 'Cách tính cước theo 1 bưu gửi';
          option.component = MotbuuguiComponent;
          option.size = DialogSize.medium;
          break;
        case 8:
          option.title = 'Cách tính cước theo % cước chính';
          option.component = PhantramcuocchinhComponent;
          option.size = DialogSize.medium;
          break;
        default:
            option.title = 'Cách tính cước theo 1 bưu gửi';
            option.component = MotbuuguiComponent;
      }
    
      option.inputs = {
        id: this.ruleId,
        vascode: vascode,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData(this.paging);
      }
    });
  }
  // async detailDataDialog(id: number): Promise<void> {
  //   const dialog = this.dialogService.openDialog(option => {
  //     option.title = 'Chi tiết vùng cước';
  //     option.size = DialogSize.full;
  //     option.component = KhuVucDialogComponent;
  //     option.inputs = {
  //       id,
  //       mode: DialogMode.edit
  //     };
  //   }, (eventName) => {
  //     if (eventName === 'onClose') {
  //       this.dialogService.closeDialogById(dialog.id);
  //       this.getData(this.paging);
  //     }
  //   });
  // }
  async deleteData(listId: number[], method: number, vascode: string): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }
    debugger;
    switch ( method)
    {
      case 1:
        // const params1 = new DomesticDomesticValueAddedServiceFreightPerItemDeleteByCodeCommand({
        //   domesticFreightRuleId: this.ruleId,valueAddedServiceCode:vascode
        // });
        // const rs1 = await this.domesticValueAddedServiceFreightPerItemApi.deleteByCode(params1).toPromise();
        // if (rs1.success) {
        //   this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
        //   this.getData(this.paging);
        // } else {
        //   this.messageService.notiMessageError(rs1.error);
        // }
        break;
      case 5:
        const params5 = new DomesticDomesticValueAddedServiceFreightPerItemDeleteByCodeCommand({
          domesticFreightRuleId: this.ruleId,valueAddedServiceCode:vascode
        });
        const rs5 = await this.domesticValueAddedServiceFreightPerItemApi.deleteByCode(params5).toPromise();
        if (rs5.success) {
          this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
          this.getData(this.paging);
        } else {
          this.messageService.notiMessageError(rs5.error);
        }
        break;
      case 8:
        const params8 = new DomesticDomesticValueAddedServiceFreightPercentMainFreightDeleteByCodeCommand({
          domesticFreightRuleId: this.ruleId,valueAddedServiceCode:vascode
        });
        const rs8 = await this.domesticValueAddedServiceFreightPercentMainFreightApi.deleteByCode(params8).toPromise();
        if (rs8.success) {
          this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
          this.getData(this.paging);
        } else {
          this.messageService.notiMessageError(rs8.error);
        }
        break;
      default:
          break;
    }
   
  }
}
