import {Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Role} from '../../../model/role.class';
import {Constant} from 'src/app/shared/constants/constant.class';
import { MessageService } from 'primeng/api';
import {Action} from '../../../model/action.model';
import {RoleService} from '../../../service/role-service';
import { EntityDto } from '../../../model/entity.class';

@Component({
  selector: 'app-update-role',
  templateUrl: './update-role.component.html',  
})
export class UpdateRoleComponent implements OnInit, OnChanges {
  @Input() isVisibleUpdate: boolean;
  @Input() role: Role;
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  @Output() cancelUpdate: EventEmitter<any> = new EventEmitter();
  formUpdate: FormGroup;
  submitted = false;
  @Input() actions: Action[];
  @Input() entities: EntityDto[];
  
  actionResponses: Action; 
  statusOptions = Constant.statusOptions;

  constructor(private fb: FormBuilder,
              private messageService: MessageService,                            
              private roleService: RoleService) {
    this.formUpdate = fb.group({
      roleId: null,
      roleName: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      status: [null, [Validators.required]],
      actionId: [null, [Validators.required]],
      entityId: [null, [Validators.required]],      
    });
  }
  ngOnInit(): void {    
    this.formUpdate.get("status").setValue(this.role.status);
    this.formUpdate.get("roleName").setValue(this.role.description);
    this.formUpdate.get("actionId").setValue(this.role.actionId);
    this.formUpdate.get("entityId").setValue(this.role.entityId);    
  }

  ngOnChanges(): void {    
    this.formUpdate.get("status").setValue(this.role.status);
    this.formUpdate.get("roleName").setValue(this.role.description);
    this.formUpdate.patchValue({
      roleId: this.role.roleId,
      actionId: this.role.actionId,
      entityId: this.role.entityId,
    });
  }

  handleCancel() {
    this.submitted = false;
    this.isVisibleUpdate = false;
    this.cancelUpdate.emit(this.isVisibleUpdate);
    this.formUpdate.reset();
  }

  get f() {
    return this.formUpdate.controls;
  }

  handleOk() {
    this.submitted = true;
    if (this.formUpdate.valid) {    
      this.submitUpdate.emit(this.formUpdate.value); 
      this.submitted = false;
      this.isVisibleUpdate = false;      
    }
  }

}
