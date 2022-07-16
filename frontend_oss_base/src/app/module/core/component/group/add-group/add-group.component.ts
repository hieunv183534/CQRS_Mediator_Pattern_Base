import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
})
export class AddGroupComponent implements OnInit {
  @Input() isVisibleAdd: boolean;
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  @Output() data: EventEmitter<any> = new EventEmitter();  
  formAdd: FormGroup;
  submitted = false;  

  statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];  

  constructor(private fb: FormBuilder) {
    this.formAdd = fb.group({
      name: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(100)]],
      createdDate: new Date(),
      description: [null, [Validators.maxLength(2000)]],
      status: [null, [Validators.required]],      
    });
  }

  ngOnInit(): void {
  }

  handleCancel() {
    this.submitted = false;
    this.isVisibleAdd = false;
    this.submitAdd.emit(this.isVisibleAdd);
    this.formAdd.reset();
  }

  get f() {
    return this.formAdd.controls;
  }

  handleOk() {
    this.submitted = true;
    if (this.formAdd.valid) {      
      this.data.emit(this.formAdd.value);
      this.submitted = false;      
    }
  } 
}
