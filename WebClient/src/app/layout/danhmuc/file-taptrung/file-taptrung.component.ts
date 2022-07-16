import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OptionModel } from 'src/app/_base/models/option-model';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { BCCP_BaseModelsPagingResultModel125, DeviceApi, POSApi, ExampleBasicApi, DanhMucDeviceGetPagingQuery, DanhMucDeviceDeleteCommand, DanhMucDeviceGetValueSerachQuery, DimFileApi, BCCP_BaseModelsPagingResultModel144, DanhMucFileGetPagingQuery, DanhMucFileDeleteCommand } from 'src/app/_shared/bccp-api.services';
import { DeviceStatusColor } from 'src/app/_shared/enums/tiepnhan/acceptance';
import { ThietBiDialogComponent } from '../thiet-bi/thiet-bi-dialog/thiet-bi-dialog.component';
import { FileTaptrungDialogComponent } from './file-taptrung-dialog/file-taptrung-dialog.component';

@Component({
  selector: 'app-file-taptrung',
  templateUrl: './file-taptrung.component.html',
  styleUrls: ['./file-taptrung.component.scss']
})
export class FileTaptrungComponent implements OnInit {
  public formSearch: FormGroup;


  public listOfData: BCCP_BaseModelsPagingResultModel144[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public lstType = [
    {text: 'Mobile App', value: 1},
    {text: 'Máy in', value: 2},
    {text: 'File hướng dẫn', value: 3}
  ];

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'deviceID',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  public lstStatus: OptionModel[] = [
    { value: 0, text: 'Đang sử dụng', color: DeviceStatusColor.DangSuDung },
    { value: 1, text: 'Không còn sử dụng', color: DeviceStatusColor.KhongSuDung}
  ];

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    public posApi: POSApi,
    private messageService: MessageService,
    private dimFileApi: DimFileApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: [''],
      type: [null]
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DanhMucFileGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ deviceName: { like: formData.name } });
    }

    if (formData.type) {
      where.and.push({ posCode: formData.type });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.dimFileApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = await rs.result.data;
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
      option.component = FileTaptrungDialogComponent;
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
      option.component = FileTaptrungDialogComponent;
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
      option.component = FileTaptrungDialogComponent;
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

    const params = new DanhMucFileDeleteCommand({
      id: listId
    });
    const rs = await this.dimFileApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }
}
