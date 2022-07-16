import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-form-step-second',
  templateUrl: './form-step-second.component.html',
  styleUrls: ['./form-step-second.component.scss']
})
export class FormStepSecondComponent implements OnInit {

  @Input() formValue: any;
  @Output() onSubmit = new EventEmitter<any>();
  @Output() onCancel = new EventEmitter<void>();

  constructor() { }

  async ngOnInit(): Promise<void> {
    // set data to form
    // if (this.formValue) {
    //   this.myForm.patchValue(this.formValue);
    // }
  }

  async cancelForm(): Promise<void> {
    // nên confirm trước khi trở về
    this.onCancel.emit();
  }

  async submitForm(): Promise<void> {
    // this.myForm.markAllAsDirty();
    // if (this.myForm.invalid) { return; }
    // const body: any = this.myForm.value;
    // this.isLoading = true;
    // logic api
    // đẩy dữ liệu ra ngoài form cha
    // this.onSubmit.emit(body);
    this.onSubmit.emit({});
    // this.isSubmit = false;
  }

}
