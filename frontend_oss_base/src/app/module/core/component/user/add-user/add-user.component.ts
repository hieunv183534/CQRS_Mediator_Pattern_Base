import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {CustomValidator} from 'src/app/shared/custom-validator/noWhitespace.class';
import {Role} from '../../../model/role.class';
import {Group} from '../../../model/group.class';
import { MenuRoles } from '../../../model/menuRoles.class';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styles: [
    `.p-tag-value {
      color: white !important;
    }`
  ],
  providers: [MessageService]
})
export class AddUserComponent implements OnInit {
  @Input()isVisibleAdd: boolean;
  @Input()rolesAdd: Role[] = [];
  @Input()groupsAdd: Group [] = [];
  @Output() dataAdd: EventEmitter<any> = new EventEmitter();
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  formAdd: FormGroup;
  submitted = false;
  isVisibleRole = false;
  titleModelRole: string;
  groups: Group [] = [];
  statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];  
  loginTypeOptions = [{label: "Password", value: 0}, {label: "OTP", value: 1}, {label: "TOTP", value: 2}];

  @Input()nodes: MenuRoles[] = [];

  constructor(private formBuilder: FormBuilder, private messageService: MessageService) {
    this.formAdd  =  this.formBuilder.group({
      email: [[null], [Validators.required, CustomValidator.cannotContainSpace,
        Validators.minLength(6), Validators.email, Validators.maxLength(100)]],
      phoneNumber: [[null], [Validators.required, Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$')]],
      name: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      groupId: [null, [Validators.required]],      
      status: [null, [Validators.required]],
      password: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      userName: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      requireOtp: [null, [Validators.required]]      
    });
  }

  ngOnInit(): void {
    // this.formAdd.patchValue({
    //   status: '0',
    //   loginType: 0
    // });
    this.groups = this.groupsAdd;
  }

  get f() { return this.formAdd.controls; }

  handleOk(): void {
    this.submitted = true;
    if (this.formAdd.valid) {
      // this.isVisibleAdd = false;
      this.dataAdd.emit(this.formAdd.value);
      this.submitted = false;
      // this.formAdd.reset();
    }
  }
  handleCancel(): void {
    this.submitAdd.emit(false);
    this.submitted = false;
    this.formAdd.reset();
  }
  _keyPress(event: any) {
    const pattern = /[0-9]/;
    const inputChar = String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  cancel(value) {
    this.isVisibleRole = value;
  }  
}
