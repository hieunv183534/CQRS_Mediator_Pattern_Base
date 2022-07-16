import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-form-step-first',
  templateUrl: './form-step-first.component.html',
  styleUrls: ['./form-step-first.component.scss']
})
export class FormStepFirstComponent implements OnInit {

  @Input() formValue: any;
  @Output() onSubmit = new EventEmitter<any>();

  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public myForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private message: MessageService,
    public exampleBasicApi: ExampleBasicApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      textSearch: ['', [
        ValidatorExtension.required(),
        ValidatorExtension.space(),
        ValidatorExtension.specialChar()]
      ],
      textSearchExtra: [''],
      isExtra: [true],
      textBasic: [''],
      textNumber: [null],
      inputDate: [null],
      inputMonth: [null],
      inputFloat: [null],
      gender: [2],
      optionSentMail: [true],
      optionSentNotification: [false],
      selectSigle: [null],
      selectMulti: [[]],
      religionId: [32],
      listReligionId: [[62, 32]],
      autoComplate: ['Công giáo'],
      isSyn: [true],
      isChekout: [false],
      textarea: ['']
    });
    this.isLoading = false;
    // set data to form
    if (this.formValue) {
      this.myForm.patchValue(this.formValue);
    }
    // add valid custom
    const dateNow = new Date();
    this.myForm.get('inputDate').setValidators([ValidatorExtension.minDate(dateNow)]);
  }

  async submitForm(): Promise<void> {
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.value;
    this.isLoading = true;
    // logic api
    // đẩy dữ liệu ra ngoài form cha
    this.onSubmit.emit(body);
    this.isSubmit = false;
  }

  async textSearchOnKeyEnter(): Promise<void> {
    this.message.notiMessageSuccess(this.myForm.get('textSearch').value);
  }

  async textSearchExtraOnKeyEnter(): Promise<void> {
    this.message.notiMessageSuccess(this.myForm.get('textSearchExtra').value);
  }

  async textBasicOnKeyTab(): Promise<void> {
    this.message.notiMessageSuccess(this.myForm.get('textBasic').value);
  }

}
