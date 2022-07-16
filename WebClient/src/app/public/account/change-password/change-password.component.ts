import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { IdentityAspNetUserChangePasswordCommand, UserApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  public isLoading = false; 
  public isSubmit = false;
  public formOrgin: string;
  public myForm: FormGroup;
  public selectBarcode = true;
  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private userApi: UserApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      passwordOld: ['', [
        ValidatorExtension.required()
      ]],
      password: [null],
      confirmPassword: [null, [ValidatorExtension.compareValidator('password', 'Xác nhận mật khẩu không đúng')]],
    });
    this.isLoading = false;
  }

  async submitForm(): Promise<void> {
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.value;
    this.isSubmit = true;
    const addData = new IdentityAspNetUserChangePasswordCommand();
    addData.init(body);
    const rs = await this.userApi.changePassword(body).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Đổi mật khẩu thành công');
    } else {
      /* nếu lỗi trả về có gắn vào một control name trên form thì
      *  hiển thị lỗi tại control đó. còn nếu không xác định được control
      *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
      */
      this.messageService.notiMessageError(this.myForm.bindError(rs.error));
    }
    // logic api
    this.isSubmit = false;
  }

}
