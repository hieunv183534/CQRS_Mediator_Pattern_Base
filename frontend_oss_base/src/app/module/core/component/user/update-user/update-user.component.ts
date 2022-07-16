import {MenuRoles} from '../../../model/menuRoles.class';
import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {User} from '../../../model/user.class';
import {DatePipe} from '@angular/common';
import {Constant} from 'src/app/shared/constants/constant.class';
import {Group} from '../../../model/group.class';
import {UserService} from '../../../service/user-service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',  
})
export class UpdateUserComponent implements OnInit, OnChanges {
  @Input() isVisible: boolean;
  @Input() user: User;
  @Input() groups: Group [] = [];
  @Output() data: EventEmitter<any> = new EventEmitter();
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  onChangeAction = false;
  requireOtp: number;
  formUpdate: FormGroup;
  submitted = false;
  createdDate: string;  
  value: string[] = [];
  isVisibleRole = false;
  passwordVisible = false;
  @Input() nodes: MenuRoles[] = [];  

  statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];  
  loginTypeOptions = [{label: "Password", value: 0}, {label: "OTP", value: 1}, {label: "TOTP", value: 2}];

  constructor(
    private formBuilder: FormBuilder,
    private datePipe: DatePipe, private userService: UserService,
    private messageService: MessageService) {
    this.formUpdate = this.formBuilder.group({
      email: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      phoneNumber: [[null], [Validators.required, Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$')]],
      name: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      groupId: [null, [Validators.required]],      
      status: [null, Validators.required],
      userName: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      userId: [null],      
      requireOtp: [null, [Validators.required]]
    });    
  }

  ngOnInit(): void {
    // this.requireOtp = 0;
  }

  ngOnChanges(): void {
    this.onChangeAction = true;    
    if (this.user != null) {                  
      this.pathValue();
      this.requireOtp = this.user.requireOtp;      
      this.formUpdate.get('groupId').setValue(this.user.groupId);
    }
  }

  cancel(value) {
    this.isVisibleRole = value;
  }

  pathValue() {
    this.formUpdate.patchValue({
      userId: this.user.userId,
      email: this.user.email,
      name: this.user.name,
      userName: this.user.userName,
      phoneNumber: this.user.phoneNumber,
      status: this.user.status,      
      requireOtp: this.user.requireOtp,
      groupId: this.user.groupId
    });
  }

  get f() {
    return this.formUpdate.controls;
  }

  handleOk(): void {
    this.submitted = true;
    if (this.formUpdate.valid) {
      // this.isVisible = false;
      this.data.emit(this.formUpdate.value);
      this.submitted = false;
    }
  }

  handleCancel(): void {
    this.submitUpdate.emit(false);
    this.submitted = false;
    this.formUpdate.reset();
  }

  _keyPress(event: any) {
    const pattern = /[0-9]/;
    const inputChar = String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  handleGetOtp() {
    // waiting for handling
  }

  handleGetTotp() {
    this.userService.sendTotpCode(this.user.userName).subscribe(res => {
      if (res.errorCode === '00') {
        // this.notificationService.showNotification(Constant.SUCCESS, Constant.MESSAGE_SUCCESS_SENT_TOTP_CODE);
      } else {
        // this.notificationService.showNotification(Constant.ERROR, res.errorDescription);
      }
    }, error => {
      // this.notificationService.showNotification(Constant.ERROR, Constant.MESSAGE_SERVER_ERROR);
    });
  } 

}
