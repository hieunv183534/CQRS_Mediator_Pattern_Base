import {Component, EventEmitter, Input, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { System } from '../../../model/system.class';
import { CustomValidator } from 'src/app/shared/custom-validator/noWhitespace.class';

@Component({
  selector: 'app-add-entity',
  templateUrl: './add-entity.component.html'
})
export class AddEntityComponent implements OnInit {

  @Input() isVisibleAdd: boolean;  
  @Input() systems: System[];
  formAdd: FormGroup;
  submitted: boolean;
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  @Output() closeAdd: EventEmitter<any> = new EventEmitter();  

  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {    
    this.formAdd = this.fb.group({
      name: [null, Validators.required],
      nameAscii: [null, [Validators.required, CustomValidator.cannotContainSpace]],
      systemId: [null],
      systemIds: [null, Validators.required],
      description: [null],
    });    
  }


  handleOk() {
    this.submitted = true;
    this.isVisibleAdd = true;
    if (this.formAdd.valid) {      
      this.submitAdd.emit(this.formAdd.value);      
    }
  }

  handleCancel(): void {
    this.submitted = false;
    this.isVisibleAdd = false;
    this.closeAdd.emit();     
  }

  get f() {
    return this.formAdd.controls;
  }
}
