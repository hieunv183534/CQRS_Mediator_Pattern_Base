import { LogErrorLogGetPagingQuery, ErrorLogApi } from './../../../../_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-nhat-ky-loi',
  templateUrl: './nhat-ky-loi.component.html',
  styleUrls: ['./nhat-ky-loi.component.scss']
})
export class NhatKyLoiComponent implements OnInit {

  public formSearch: FormGroup;

  public listOfData: any[] = [];
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
    private errorLogApi: ErrorLogApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: ['']
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { CreateDate: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new LogErrorLogGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ colText: { like: formData.name } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.errorLogApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async showDataDialog(id: number): Promise<void> {
    // const dialog = this.dialogService.openDialog(option => {
    //   option.title = 'Xem thông tin dữ liệu';
    //   option.size = DialogSize.large;
    //   option.component = CrudDataDialogComponent;
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

  async editDataDialog(id: number): Promise<void> {
    // const dialog = this.dialogService.openDialog(option => {
    //   option.title = 'Sửa dữ liệu';
    //   option.size = DialogSize.medium;
    //   option.component = CrudDataDialogComponent;
    //   option.inputs = {
    //     id,
    //     mode: DialogMode.edit
    //   };
    // }, (eventName) => {
    //   if (eventName === 'onClose') {
    //     this.dialogService.closeDialogById(dialog.id);
    //     this.getData(this.paging);
    //   }
    // });
  }

  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    // const params = new ExampleExampleBasicDeleteCommand({
    //   id: listId
    // });
    // const rs = await this.exampleBasicApi.delete(params).toPromise();
    // if (rs.success) {
    //   this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
    //   this.getData(this.paging);
    // } else {
    //   this.messageService.notiMessageError(rs.error);
    // }
  }

}
