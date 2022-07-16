import {Component, EventEmitter, Input, OnChanges, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {System} from '../../../model/system.class';

@Component({
  selector: 'app-update-system',
  templateUrl: './update-system.component.html',  
})
export class UpdateSystemComponent implements OnInit, OnChanges {
  @Input() isVisible: boolean;
  @Input() system: System;  
  @Output() data: EventEmitter<any> = new EventEmitter();
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();  
  formUpdate: FormGroup;
  submitted = false;  
  value: string[] = [];
  isVisibleRole = false;  

  constructor(private formBuilder: FormBuilder) {
    this.formUpdate = this.formBuilder.group({
      id: [null],
      code: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],      
      name: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      description: [null]
    });    
  }

  ngOnInit(): void {
    // this.pathValue();
  }  
  
  ngOnChanges(): void {    
    if (this.system != null) {                  
      this.pathValue();      
    }
  }

  pathValue() {
    this.formUpdate.patchValue({
      id: this.system.id,
      code: this.system.code,      
      name: this.system.name,
      description: this.system.description,     
    });
  }

  cancel(value) {
    this.isVisibleRole = value;
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

}
