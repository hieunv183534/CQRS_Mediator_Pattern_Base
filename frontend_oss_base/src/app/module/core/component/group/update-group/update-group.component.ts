import {Component, EventEmitter, Input, OnInit, OnChanges, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Group} from '../../../model/group.class';

@Component({
  selector: 'app-update-group',
  templateUrl: './update-group.component.html',
})
export class UpdateGroupComponent implements OnInit, OnChanges  {
  @Input() isVisibleUpdate: boolean;
  @Input() group: Group;  
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  @Output() cancelUpdate: EventEmitter<any> = new EventEmitter();

  formUpdate: FormGroup;
  submitted = false;

  statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];  

  constructor(private fb: FormBuilder) {
    this.formUpdate = fb.group({
      groupId: null,
      name: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],      
      description: [null, [Validators.maxLength(2000)]],
      status: [null, [Validators.required]],      
    });
  }

  ngOnInit(): void {
    console.log("init");
  }

  ngOnChanges(): void {    
    this.formUpdate.get('groupId').setValue(this.group.groupId);
    this.formUpdate.get('name').setValue(this.group.name);
    this.formUpdate.get('description').setValue(this.group.description);
    this.formUpdate.get('status').setValue(this.group.status);
  }

  handleCancel() {
    this.submitted = false;
    this.isVisibleUpdate = false;
    this.cancelUpdate.emit();
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
    }
  } 
}
