import {
  DocumentsApi, HoTroDocumentsGetPagingQuery, HoTroDocumentsGetPagingQueryResult, HoTroDocumentsDeleteCommand
} from 'src/app/_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../_shared/services/user.service';
import { QuanlyvanbanDataDialogComponent } from './quanlyvanban-data-dialog/quanlyvanban-data-dialog.component';
import { environment } from 'src/environments/environment';
import { SettingService } from 'src/app/_shared/services/setting.service';
@Component({
  selector: 'app-giaotuigoi',
  templateUrl: './quanlyvanban.component.html',
  styleUrls: ['./quanlyvanban.component.scss']
})
export class QuanlyvanbanComponent implements OnInit {

  public formSearch: FormGroup;

  public isLoading = false;
  public paging: PagingModel = {
    page: 1,
    count: 100,
    size: 10
  };
  public listOfData = [];

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
    private settingService: SettingService,
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private userService: UserService,
    public documentsApi: DocumentsApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      Title: null,
      DateFrom: null,
      DateTo: null
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { dateCreated: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new HoTroDocumentsGetPagingQuery({
      ...paging
    });
    if (formData.Title) {
      where.and.push({ title: { like: formData.Title } });
    }
    if (formData.DateFrom) {
      params.dateFrom = formData.DateFrom;
    }
    if (formData.DateTo) {
      params.dateTo = formData.DateTo;
    }
    //where.and.push({ pOSCode: this.userService.userInfo.postCode });
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    this.isLoading = true;
    const rs = await this.documentsApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      for (const item of this.listOfData) {
        item.url = item.url ? JSON.parse(item.url) : [];
        for (const u of item.url) {
          u.fileUrl = this.getPathUrl(u.fileUrl);
        }
      }
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  getPathUrl(url: string) {
    return `${this.settingService.data.path}${url}`;
  }

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thông tin văn bản';
      option.size = DialogSize.medium;
      option.component = QuanlyvanbanDataDialogComponent;
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
    debugger;
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thông tin văn bản';
      option.size = DialogSize.medium;
      option.component = QuanlyvanbanDataDialogComponent;
      option.inputs = {
        id: id,
        mode: DialogMode.view
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

  async editDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa Thông tin văn bản';
      option.size = DialogSize.medium;
      option.component = QuanlyvanbanDataDialogComponent;
      option.inputs = {
        id: id,
        mode: DialogMode.edit
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

  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa văn bản này không?', ' ');
    if (!result) { return; }

    const params = new HoTroDocumentsDeleteCommand({
      id: listId
    });
    // tslint:disable-next-line: no-debugger
    debugger;
    const rs = await this.documentsApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }
}
