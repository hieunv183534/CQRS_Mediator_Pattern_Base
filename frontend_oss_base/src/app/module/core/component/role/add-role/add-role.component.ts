import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActionService} from '../../../service/action.service';
import {Action} from '../../../model/action.model';
import {Constant} from 'src/app/shared/constants/constant.class';
import { EntityDto } from '../../../model/entity.class';
import { EntityService } from '../../../service/entity.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html' ,
  providers: [EntityService]
})
export class AddRoleComponent implements OnInit {
  @Input() isVisibleAdd: boolean;
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  @Output() cancelAdd: EventEmitter<any> = new EventEmitter();
  formAdd: FormGroup;
  submitted = false;
  @Input() actions: Action[];
  @Input() entities: EntityDto[];
  actionResponses: Action[] = [];
  statusOptions = Constant.statusOptions;

  constructor(private fb: FormBuilder,                            
              private actionService: ActionService,
              private entityService: EntityService) {
    this.formAdd = fb.group({
      roleName: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      createdDate: new Date(),
      status: [null, [Validators.required]],
      actionId: [null, [Validators.required]],
      entityId: [null, [Validators.required]],
      applicationId: [null]
    });
  }

  ngOnInit(): void {    
    this.actionService.getListActiveAction().subscribe(res => {
      this.actions = res;
    });    
    this.entityService.getActiveEntity().subscribe(res => {
      this.entities = res;
    });
  }

  handleCancel() {
    this.submitted = false;
    this.isVisibleAdd = false;
    this.cancelAdd.emit(this.isVisibleAdd);
    this.formAdd.reset();
  }

  get f() {
    return this.formAdd.controls;
  }

  handleOk() {
    this.submitted = true;
    if (this.formAdd.valid) {                  
      this.isVisibleAdd = false;
      this.submitAdd.emit(this.formAdd.value);
      this.submitted = false;
    }
  }
}
