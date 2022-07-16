import { ApplicationApi, IdentityMenuDeleteCommand, IdentityMenuGetAllQuery, MenuApi } from 'src/app/_shared/bccp-api.services';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { TableTreeConfigModel } from 'src/app/_base/models/table-tree-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DimMenuDataDialogComponent } from './dim-menu-data-dialog/dim-menu-data-dialog.component';

@Component({
  selector: 'app-dim-menu',
  templateUrl: './dim-menu.component.html',
  styleUrls: ['./dim-menu.component.scss']
})
export class DimMenuComponent implements OnInit {
  public myForm: FormGroup;

  public listOfData: any[] = [];
  public isLoading = false;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });

  public tableTreeConfig: TableTreeConfigModel = new TableTreeConfigModel({
    keyId: 'id',
    keyParentId: 'parentId',
    collapseDefault: true,
    mapOfExpandedData: {}
  });

  public checked = false;
  public loading = false;

  public lstStatus: any[] = [
    { value: 1, text: 'Hiển thị' },
    { value: 2, text: 'Ẩn' },
  ];

  constructor(
    private dialogService: DialogService,
    private messageService: MessageService,
    private fb: FormBuilder,
    public applicationApi: ApplicationApi,
    public menuApi: MenuApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      applicationId: [null],
      menuName: ['']
    });
    await this.getData();
  }

  async getData(): Promise<void> {
    this.isLoading = true;
    this.myForm.textTrim();
    let formData = this.myForm.value;
    let where: any = { and: [{ type: 1 }] };
    const params = new IdentityMenuGetAllQuery({
      order: { order: true }
    });
    if (formData.applicationId) {
      where.and.push({ applicationId: formData.applicationId });
    }
    if (formData.menuName) {
      where.and.push({ name: formData.menuName });
    }
    params.where = where;

    const rs = await this.menuApi.getAll(params).toPromise();
    console.log('getData', rs);
    if (rs.success) {
      this.tableConfig.reset();
      let dataRaw = await rs.result.getMapingCombobox('applicationId', 'applicationName', this.applicationApi, null);
      this.listOfData = this.tableTreeConfig.convertDataRawToDataTree(dataRaw);
    }

    this.isLoading = false;
  }

  // async showDimMenu(): Promise<void> {

  // }

  async showDimMenu_FindOne(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Chi tiết danh mục';
      option.size = DialogSize.medium;
      option.component = DimMenuDataDialogComponent;
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

  async showDimMenu(): Promise<void> {
    const arrSelected = this.tableConfig.getItemSelectedArray();
    if (arrSelected.length > 1) {
      this.messageService.notiMessageWarning('Bạn chỉ được chọn 1 bản ghi!');
      return;
    } else if (arrSelected.length < 1) {
      this.messageService.notiMessageWarning('Bạn chưa thao tác chọn bản ghi!');
      return;
    }
    this.showDimMenu_FindOne(arrSelected[0]);
  }

  //  load compponent tim kiem

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới';
      option.size = DialogSize.xlarge;
      option.component = DimMenuDataDialogComponent;
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

  async showDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem menu';
      option.size = DialogSize.xlarge;
      option.component = DimMenuDataDialogComponent;
      option.inputs = {
        id: id,
        mode: DialogMode.view
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async editDataDialog(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa menu';
      option.size = DialogSize.xlarge;
      option.component = DimMenuDataDialogComponent;
      option.inputs = {
        id: id,
        mode: DialogMode.edit
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

  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new IdentityMenuDeleteCommand({
      id: listId
    });
    const rs = await this.menuApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData();
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

  async editDimMenu_findone(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa thông tin danh mục';
      option.size = DialogSize.medium;
      option.component = DimMenuDataDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData();
      }
    });
  }

  async editDimMenu(): Promise<void> {
    const arrSelected = this.tableConfig.getItemSelectedArray();
    if (arrSelected.length > 1) {
      this.messageService.notiMessageWarning('Bạn chỉ được chọn 1 bản ghi!');
      return;
    } else if (arrSelected.length < 1) {
      this.messageService.notiMessageWarning('Bạn chưa thao tác chọn bản ghi!');
      return;
    }
    this.editDimMenu_findone(arrSelected[0]);
  }
}
