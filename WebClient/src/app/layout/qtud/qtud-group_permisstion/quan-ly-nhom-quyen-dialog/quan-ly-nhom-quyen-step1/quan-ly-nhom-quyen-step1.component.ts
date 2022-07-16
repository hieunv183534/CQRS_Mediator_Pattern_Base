import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { TableTreeConfigModel } from 'src/app/_base/models/table-tree-config-model';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { RoleApi, IdentityAspNetRoleFindOneQuery, IdentityAspNetRoleCreateCommand } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-quan-ly-nhom-quyen-step1',
  templateUrl: './quan-ly-nhom-quyen-step1.component.html',
  styleUrls: ['./quan-ly-nhom-quyen-step1.component.scss']
})
export class QuanLyNhomQuyenStep1Component implements OnInit {

  @Input() mode; any;
  @Input() formValue: any;
  @Output() onSubmit = new EventEmitter<any>();
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
 
  constructor(
    private messageService: MessageService,
    private fb: FormBuilder,
    private dialogService: DialogService,
    private roleApi: RoleApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      id: ['', [ValidatorExtension.required()]],
      name: ['', [ValidatorExtension.required()]],
      concurrencyStamp: ['']
    });

    if (this.formValue) {
      this.myForm.patchValue(this.formValue);
    }

    if (this.mode === 'view') {
      this.myForm.disable();
    }

    if (this.mode === 'edit'){
      this.myForm.get('id').disable();
    }

  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }

  async submitForm(): Promise<void> {
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.getRawValue();
    this.onSubmit.emit(body);
  }

}
