import { DanhMucHolidayDeleteCommand, DanhMucHolidayGetPagingQuery, HolidayApi } from './../../../_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi, DimTransportApi, DimTransportGroupApi, ExampleExampleBasicGetPagingQuery, ExampleExampleBasicDeleteCommand } from 'src/app/_shared/bccp-api.services';
import { NgayNghiDataComponent } from './ngay-nghi-data/ngay-nghi-data.component';

@Component({
  selector: 'app-ngay-nghi',
  templateUrl: './ngay-nghi.component.html',
  styleUrls: ['./ngay-nghi.component.scss']
})
export class NgayNghiComponent implements OnInit {

  public formSearch: FormGroup;

  public listOfData: any[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'holidayCode',
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
    private holidayApi: HolidayApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: ['']
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { holidayDate: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new DanhMucHolidayGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ holidayName: { like: formData.name } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.holidayApi.getPaging(params).toPromise();
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
      option.title = 'Thêm mới ngày nghỉ';
      option.size = DialogSize.large;
      option.component = NgayNghiDataComponent;
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
      option.title = 'Xem thông ngày nghỉ';
      option.size = DialogSize.large;
      option.component = NgayNghiDataComponent;
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
      option.title = 'Sửa dữ liệu ngày nghỉ';
      option.size = DialogSize.large;
      option.component = NgayNghiDataComponent;
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

    const params = new DanhMucHolidayDeleteCommand({
      holidayCode: listId
    });
    const rs = await this.holidayApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
