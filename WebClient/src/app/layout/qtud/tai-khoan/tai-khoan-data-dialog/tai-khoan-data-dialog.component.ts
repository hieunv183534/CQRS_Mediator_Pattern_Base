import { IdentityAspNetUserCreateCommand, IdentityAspNetUserFindOneQuery, IdentityAspNetUserUpdateCommand, POSApi, UserApi } from './../../../../_shared/bccp-api.services';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi, ExampleExampleBasicFindOneQuery, ExampleExampleBasicCreateCommand, ExampleExampleBasicUpdateCommand, CustomerApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-tai-khoan-data-dialog',
  templateUrl: './tai-khoan-data-dialog.component.html',
  styleUrls: ['./tai-khoan-data-dialog.component.scss']
})
export class TaiKhoanDataDialogComponent implements OnInit {

  @Input() mode: string;
  @Input() id: string;
  @Input() type: number;
  // tslint:disable-next-line: no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    public exampleBasicApi: ExampleBasicApi,
    private userApi: UserApi,
    private dialogService: DialogService,
    public posApi: POSApi,
    public customerApi: CustomerApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      username: ['', ValidatorExtension.required()],
      fullName: [null, [ValidatorExtension.required()]],
      password: [null],
      confirmPassword: [null, [ValidatorExtension.compareValidator('password', 'Xác nhận mật khẩu không đúng')]],
      tel: [null],
      posCode: [null],
      unitCode: [null],
      customerCode: [null],
      areaPos: [[]],
      address: [null],
      email: [null]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new IdentityAspNetUserFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.userApi.findOne(params).toPromise();
      if (rs.success) {
        let dataFind: any = rs.result;
        if (dataFind.areaPos) {
          dataFind.areaPos = JSON.parse(dataFind.areaPos);
        }
        this.myForm.patchValue(dataFind);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    } else {
      //dang ky thi ko duoc de trong pass
      this.myForm.get('password').setValidators(ValidatorExtension.required())
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      // logic view edit in here
      this.myForm.disableMulti(['username']);
    }

    switch (this.type) {
      case 1:
        this.myForm.get('posCode').setValidators([ValidatorExtension.required()]);
        break;
      default:
        this.myForm.get('customerCode').setValidators([ValidatorExtension.required()]);
        break;
    }

    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // giá trị form body
    const body = this.myForm.getRawValue();
    body.areaPos = JSON.stringify(body.areaPos);

    let listDataPos: any[] = this.myForm.get('areaPos').value;
    if (listDataPos && listDataPos.length > 0 && listDataPos.findIndex(x=>x == body.posCode) === -1) {
      this.messageService.notiMessageError('Bưu cục mặc định chọn phải nằm trong Phạm vi bưu cục quản lý');
      return;
    }

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new IdentityAspNetUserCreateCommand();
      addData.init(body);
      const rs = await this.userApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        /* nếu lỗi trả về có gắn vào một control name trên form thì
        *  hiển thị lỗi tại control đó. còn nếu không xác định được control
        *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const updateData = new IdentityAspNetUserUpdateCommand();
      updateData.init({
        id: this.id,
        ...body
      });
      const rs = await this.userApi.update(updateData).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        /* nếu lỗi trả về có gắn vào một control name trên form thì
        *  hiển thị lỗi tại control đó. còn nếu không xác định được control
        *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
