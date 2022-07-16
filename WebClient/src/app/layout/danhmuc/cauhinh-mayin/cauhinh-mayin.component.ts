import { UserService } from './../../../_shared/services/user.service';
import { CauhinhMayinDialogComponent } from './cauhinh-mayin-dialog/cauhinh-mayin-dialog.component';
import { BCCP_BaseModelsPagingResultModel158, DanhMucReportManagerPrinterDeleteCommand, DanhMucReportManagerPrinterGetPagingQuery, DimReportManagerApi, DimReportManagePrinterCboApi } from './../../../_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { POSApi, DimReportManagerPrinterApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-cauhinh-mayin',
  templateUrl: './cauhinh-mayin.component.html',
  styleUrls: ['./cauhinh-mayin.component.scss']
})
export class CauhinhMayinComponent implements OnInit {

  public formSearch: FormGroup;


  public listOfData: BCCP_BaseModelsPagingResultModel158[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'printerID',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    public posApi: POSApi,
    private messageService: MessageService,
    private userService: UserService,
    public dimReportManagerApi: DimReportManagerApi,
    public dimReportManagePrinterCboApi: DimReportManagePrinterCboApi,
    private dimReportManagerPrinterApi: DimReportManagerPrinterApi,
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: [''],
      valueSearch: [null],
      posCode: [this.userService.userInfo.postCode],
      reportManagerID: [null]
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { printerID: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DanhMucReportManagerPrinterGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ printerName: { like: formData.name } });
    }

    if (formData.posCode) {
      where.and.push({ posCode: formData.posCode });
    }

    if (formData.reportManagerID) {
      where.and.push({ reportManagerID: formData.ReportManagerID });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.dimReportManagerPrinterApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = await rs.result.data.getMapingCombobox('posCode', 'posCodeName', this.posApi, null);
      this.listOfData = await this.listOfData.getMapingCombobox('reportManagerID', 'reportManagerName', this.dimReportManagePrinterCboApi, null);
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới';
      option.size = DialogSize.large;
      option.component = CauhinhMayinDialogComponent;
      option.inputs = {
        id: null,
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
      option.component = CauhinhMayinDialogComponent;
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
      option.size = DialogSize.large;
      option.component = CauhinhMayinDialogComponent;
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

  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new DanhMucReportManagerPrinterDeleteCommand({
      printerID: listId
    });
    const rs = await this.dimReportManagerPrinterApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }


  // async onEnter() { 
  //   let valueSearch = this.formSearch.get('valueSearch').value
  //   const formData = this.formSearch.value;

  //   const where = { and: [] };
  //   const params = new DanhMucDeviceGetValueSerachQuery({
  //     valueSearch: valueSearch,
  //     ...this.paging
  //   });

  //   if (formData.name) {
  //     where.and.push({ deviceName: { like: formData.name } });
  //   }

  //   // where loopback
  //   if (where.and.length > 0) {
  //     params.where = where;
  //   }
  //   debugger;
  //   this.isLoading = true;
  //   const rs = await this.deviceApi.getAutoFill(params).toPromise();
  //   if (rs.success) {
  //     this.tableConfig.reset();
  //     this.listOfData = await rs.result.data.getMapingCombobox('posCode', 'posCodeName', this.posApi, null);
  //     this.paging = rs.result.paging;
  //   } else {
  //     this.messageService.notiMessageError(rs.error);
  //   }

  //   this.isLoading = false;
  // }

}