import { IdentityAspNetUserGetPagingByIdQuery, IdentityAspNetUserGetPagingQuery, UserApi } from './../../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { TaiKhoanSelectComponent } from '../../../tai-khoan/tai-khoan-select/tai-khoan-select.component';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { MessageService } from 'src/app/_base/servicers/message.service';

@Component({
  selector: 'app-quan-ly-nhom-quyen-step3',
  templateUrl: './quan-ly-nhom-quyen-step3.component.html',
  styleUrls: ['./quan-ly-nhom-quyen-step3.component.scss']
})
export class QuanLyNhomQuyenStep3Component implements OnInit {

  @Input() formValue: any[];
  @Input() mode: any;
  @Output() onSubmit = new EventEmitter<any>();
  @Output() onCancel = new EventEmitter<void>();
  @Output() onClose = new EventEmitter<any>();

  public listOfData: any[] = [];
  public isLoading = false;
  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });

  constructor(
    private dialogService: DialogService,
    private messageService: MessageService,
    private userApi: UserApi
  ) { }

  ngOnInit() {
    if (!this.formValue) {
      this.formValue = [];
    } else {
      this.getData();
    }
  }

  async getData() {

    if (this.formValue.length === 0) {
      return;
    }

    const listId = [];
    for (const item of this.formValue) {
      listId.push(item.userId );
    }

    const params = new IdentityAspNetUserGetPagingByIdQuery({
      size: listId.length,
      listId: listId
    });

    this.isLoading = true;
    const rs = await this.userApi.getPagingById(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
    } else {
      this.messageService.notiMessageError(rs.error);
    }
    this.isLoading = false;
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }

  async cancelForm(): Promise<void> {
    this.onCancel.emit();
  }

  async submitForm(): Promise<void> {
    this.onSubmit.emit(this.formValue);
  }

  async addUserMember(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm thành viên';
      option.size = DialogSize.large;
      option.component = TaiKhoanSelectComponent;
      option.inputs = {
        itemSelected: this.formValue.map(x => x.userId),
        mode: this.mode
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
      if (eventName === 'onSubmit') {
        if (eventValue) {
          for (const item of eventValue) {
            if (!this.formValue.some(x => x.userId === item)) {
              this.formValue.push({ userId: item });
            }
          }
          this.getData();
          this.dialogService.closeDialogById(dialog.id);
        }
      }
    });
  }

  async deleteUserMember(id: any): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }
    const index = this.formValue.findIndex(x=>x.userId === id);
    if(index!== -1){
      this.formValue.splice(index,1);
    }
    this.listOfData = this.listOfData.filter(x=> x.id !== id);
  }
}
