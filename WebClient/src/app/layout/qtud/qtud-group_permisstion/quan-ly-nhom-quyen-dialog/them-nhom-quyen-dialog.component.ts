import { ApplicationApi, IdentityAspNetRoleCreateCommand, IdentityAspNetRoleFindOneQuery, IdentityMenuGetAllQuery, MenuApi, RoleApi } from './../../../../_shared/bccp-api.services';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableTreeConfigModel } from 'src/app/_base/models/table-tree-config-model';

@Component({
  selector: 'app-them-nhom-quyen-dialog',
  templateUrl: './them-nhom-quyen-dialog.component.html',
  styleUrls: ['./them-nhom-quyen-dialog.component.scss']
})
export class ThemNhomQuyenDialogComponent implements OnInit {

  @Input() mode: string;
  @Input() id: number;
  @Output() onClose = new EventEmitter<any>();

  public stepCurent = 0;

  public isLoading = true;
  public formFistValue: any = {};
  public formSecondValue: any = {
    listMatrixData: [],
    listOfTask: [],
    mapOfExpandedData: []
  };
  public formThreeValue: any[] = [];

  public listOfTask: any[] = []
  public listOfMenu: any[] = [];
  constructor(
    private messageService: MessageService,
    private roleApi: RoleApi,
    private menuApi: MenuApi,
    private applicationApi: ApplicationApi
  ) { }

  async ngOnInit(): Promise<void> {
    if (this.id) {
      const params = new IdentityAspNetRoleFindOneQuery({
        where: {and:[{id: this.id}]}
      });
      const rs = await this.roleApi.findOne(params).toPromise();
      if (rs.success) {
        this.formFistValue = {
          id: rs.result.id,
          name: rs.result.name,
          concurrencyStamp: rs.result.concurrencyStamp
        }
        this.formSecondValue.mapOfExpandedData = rs.result.aspNetRoleClaims;
        this.formThreeValue = rs.result.aspNetUserRoles;
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }
    await this.getListMatrixData();
    this.isLoading = false;
  }

  async getListMenuData(): Promise<void> {
    const params = new IdentityMenuGetAllQuery();
    const rs = await this.menuApi.getAll(params).toPromise();
    if (rs.success) {
      this.listOfMenu = rs.result;
    }
  }

  async getListTaskData(): Promise<void> {
    this.listOfTask = [
      { taskId: 'r', taskName: 'xem' },
      { taskId: 'c', taskName: 'thêm' },
      { taskId: 'u', taskName: 'sửa' },
      { taskId: 'd', taskName: 'xóa' }
    ]
  }

  async getListMatrixData(): Promise<void> {
    await this.getListMenuData();
    await this.getListTaskData();
    let dataRaw = await this.listOfMenu.getMapingCombobox('applicationId', 'applicationName', this.applicationApi, null);
    for (const item of dataRaw) {
      const menuData = this.formSecondValue.mapOfExpandedData.find(x => x.menuId === item.code);
      for (const task of this.listOfTask) {
        let valueTask = false;
        if (menuData) {
          valueTask = menuData.listTask.some(x => x === task.taskId);
        }
        item['task_' + task.taskId] = valueTask;
      }
    }
    this.formSecondValue = {
      listMatrixData: dataRaw,
      listOfTask: this.listOfTask
    };
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }

  async formCancel(): Promise<void> {
    this.stepCurent--;
  }

  async formFistSubmit(value): Promise<void> {
    this.formFistValue = value;
    this.stepCurent++;
  }

  async formSecondSubmit(value): Promise<void> {
    this.formSecondValue = value;
    this.stepCurent++;
  }

  async changeStep(value: number) : Promise<void> {
    // if(this.mode !== DialogMode.add){
    //   this.stepCurent = value;
    // }
  }

  async formThreeForm(value): Promise<void> {
    this.formThreeValue = value;
    this.isLoading = true;
    const roleData = this.formSecondValue.mapOfExpandedData;
    // logic api
    if (this.mode === DialogMode.add) { // them moi
      const params = new IdentityAspNetRoleCreateCommand();
      params.init({
        ...this.formFistValue,
        aspNetRoleClaims: roleData,
        aspNetUserRoles: this.formThreeValue
      });
      const res = await this.roleApi.create(params).toPromise();
      if (res.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(params);
      } else {
        this.messageService.notiMessageError(res.error);
      }
    } else { // update
      const params = new IdentityAspNetRoleCreateCommand();
      params.init({
        ...this.formFistValue,
        aspNetRoleClaims: roleData,
        aspNetUserRoles: this.formThreeValue
      });
      const res = await this.roleApi.update(params).toPromise();
      if (res.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        this.onClose.emit(params);
      } else {
        this.messageService.notiMessageError(res.error);
      }
    }

    this.isLoading = false;
  }

}
