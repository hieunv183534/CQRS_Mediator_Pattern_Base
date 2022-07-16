import {
  ExampleBasicMultiKeyApi, ExampleExampleBasicMultiKeyDeleteCommand,
  ExampleExampleBasicMultiKeyDeleteCommandKey,
  ExampleExampleBasicMultiKeyGetPagingQuery, ExampleExampleBasicMultiKeyGetPagingQueryResult, ExampleExampleBasicMultiKeyUpdateCommandKey
} from './../../../_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { CrudMultiKeyDataDialogComponent } from './crud-multi-key-data-dialog/crud-multi-key-data-dialog.component';

@Component({
  selector: 'app-crud-multi-key',
  templateUrl: './crud-multi-key.component.html',
  styleUrls: ['./crud-multi-key.component.scss']
})
export class CrudMultiKeyComponent implements OnInit {

  public formSearch: FormGroup;

  public listOfData: ExampleExampleBasicMultiKeyGetPagingQueryResult[] = [];
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
    private exampleBasicMultiKeyApi: ExampleBasicMultiKeyApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: ['']
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { 'id.id1': false, 'id.id2': false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new ExampleExampleBasicMultiKeyGetPagingQuery({
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
    const rs = await this.exampleBasicMultiKeyApi.getPaging(params).toPromise();
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
      option.component = CrudMultiKeyDataDialogComponent;
      option.inputs = {
        data: null,
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

  async showDataDialog(id: ExampleExampleBasicMultiKeyUpdateCommandKey): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem thông tin dữ liệu';
      option.size = DialogSize.large;
      option.component = CrudMultiKeyDataDialogComponent;
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

  async editDataDialog(id: ExampleExampleBasicMultiKeyUpdateCommandKey): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa dữ liệu';
      option.size = DialogSize.medium;
      option.component = CrudMultiKeyDataDialogComponent;
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

  async deleteData(listId: ExampleExampleBasicMultiKeyDeleteCommandKey[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new ExampleExampleBasicMultiKeyDeleteCommand({
      listId
    });
    const rs = await this.exampleBasicMultiKeyApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
