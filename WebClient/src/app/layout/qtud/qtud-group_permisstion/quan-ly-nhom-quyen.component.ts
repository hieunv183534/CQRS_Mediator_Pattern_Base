import { IdentityAspNetRoleDeleteCommand, IdentityAspNetRoleGetPagingQuery, RoleApi } from './../../../_shared/bccp-api.services';
import { ThemNhomQuyenDialogComponent } from './quan-ly-nhom-quyen-dialog/them-nhom-quyen-dialog.component';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DialogSize, DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from './../../../_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';

@Component({
  selector: 'app-quan-ly-nhom-quyen',
  templateUrl: './quan-ly-nhom-quyen.component.html',
  styleUrls: ['./quan-ly-nhom-quyen.component.scss']
})
export class QuanlynhomquyenComponent implements OnInit {

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

  constructor(
    private messageService: MessageService,
    private fb: FormBuilder,
    private dialogService: DialogService,
    private roleApi: RoleApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: ['']
    });
    this.isLoading = false;
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new IdentityAspNetRoleGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ name: { like: formData.name } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.roleApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  addDataDialog(): void {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới';
      option.size = DialogSize.xlarge;
      option.component = ThemNhomQuyenDialogComponent;
      option.inputs = {
        data: null,
        mode: DialogMode.add
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          this.getData();
        }
      }
    });
  }


  showDataDialog(id: string): void {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem';
      option.size = DialogSize.xlarge;
      option.component = ThemNhomQuyenDialogComponent;
      option.inputs = {
        data: null,
        id: id,
        mode: DialogMode.view
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          this.getData();
        }
      }
    });
  }

  async editDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa dữ liệu';
      option.size = DialogSize.xlarge;
      option.component = ThemNhomQuyenDialogComponent;
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

  async deleteData(listId: string[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new IdentityAspNetRoleDeleteCommand({
      id: listId
    });
    const rs = await this.roleApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
