import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { EntityDto } from '../../../model/entity.class';
import { System } from '../../../model/system.class';
import { CustomValidator } from 'src/app/shared/custom-validator/noWhitespace.class';

@Component({
  selector: 'app-update-entity',
  templateUrl: './update-entity.component.html'
})
export class UpdateEntityComponent implements OnInit, OnChanges {
  @Input() entity: EntityDto;  
  @Input() isVisibleUpdate: boolean;  
  @Input() systems: System[];
  formUpdate: FormGroup;
  submitted: boolean;
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  @Output() closeUpdate: EventEmitter<any> = new EventEmitter();  

  constructor(private fb: FormBuilder) {
    this.formUpdate = this.fb.group({
      entityId: [null, Validators.required],
      name: [null, Validators.required],
      nameAscii: [null, [Validators.required, CustomValidator.cannotContainSpace]],      
      systemIds: [null, Validators.required],
      status: [1], // fix cung la 1 - Active
      description: [null],
    });
  }

  ngOnInit(): void {
    
  }

  ngOnChanges(changes: SimpleChanges) {        
    this.formUpdate.get('entityId').setValue(this.entity.entityId);
    this.formUpdate.get('name').setValue(this.entity.name);
    this.formUpdate.get('nameAscii').setValue(this.entity.nameAscii);
    this.formUpdate.get('description').setValue(this.entity.description);
    let ids = [];
    this.entity.systemsDto.forEach(system => {
      ids.push(system.id);
    });
    this.formUpdate.get('systemIds').patchValue(ids);  
  }  

  handleOk() {
    this.submitted = true;
    this.isVisibleUpdate = true;
    if (this.formUpdate.valid) {      
      this.submitUpdate.emit(this.formUpdate.value);      
    }
  }

  handleCancel(): void {
    this.submitted = false;
    this.isVisibleUpdate = false;
    this.closeUpdate.emit();     
  }

  get f() {
    return this.formUpdate.controls;
  }
}
