import { MessageService } from 'src/app/_base/servicers/message.service';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ExampleBasicApi, GiaoNhanMailRouteApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-basic',
  templateUrl: './basic.component.html',
  styleUrls: ['./basic.component.scss']
})
export class BasicComponent implements OnInit {

  public isLoading = false; 
  public isSubmit = false;
  public formOrgin: string;
  public myForm: FormGroup;
  public selectBarcode = true;
  constructor(
    private fb: FormBuilder,
    private message: MessageService,
    public exampleBasicApi: ExampleBasicApi,
    public mailRouteApi: GiaoNhanMailRouteApi
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
      religionId: [null],
      listReligionId: [[]],
      autoComplate: ['Công giáo'],
      isSyn: [true],
      isChekout: [false],
      textarea: [''],
      province: [null],
      district: [null],
      commune: [null],
      datetime: [null]
    });
    this.isLoading = false;

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
    this.isSubmit = false;
  }

  async onChangeAreaPlace(value: any): Promise<void> {
    this.myForm.patchValue({
      province: value.province,
      district: value.district,
      commune: value.commune
    });
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
