import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {CustomValidator} from 'src/app/shared/custom-validator/noWhitespace.class';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-system',
  templateUrl: './add-system.component.html',
  styles: [
    `.p-tag-value {
      color: white !important;
    }`
  ],
  providers: [MessageService]
})
export class AddSystemComponent implements OnInit {
  @Input()isVisibleAdd: boolean;
  @Output() dataAdd: EventEmitter<any> = new EventEmitter();
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  formAdd: FormGroup;
  submitted = false;
  isVisibleRole = false;
  titleModelRole: string;

  constructor(private formBuilder: FormBuilder) {
    this.formAdd  =  this.formBuilder.group({
      code: [[null], [Validators.required, CustomValidator.cannotContainSpace,
        Validators.minLength(6), Validators.maxLength(20)]],
      name: [[null], [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      description: [null]
    });
  }

  ngOnInit(): void {    
  }

  get f() { return this.formAdd.controls; }

  handleOk(): void {
    this.submitted = true;
    if (this.formAdd.valid) {      
      this.dataAdd.emit(this.formAdd.value);
      this.submitted = false;      
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
