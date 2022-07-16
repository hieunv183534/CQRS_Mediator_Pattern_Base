import { ProvinceApi, DistrictApi, CommuneApi } from './../../bccp-api.services';
import { ValidatorExtension } from './../../../_base/extensions/validator-extension';
import { Component, Input, OnInit, OnChanges, SimpleChanges, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-quanhuyen',
  templateUrl: './quanhuyen.component.html',
  styleUrls: ['./quanhuyen.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class QuanHuyenComponent implements OnInit, OnChanges {

  @Input() provinceValue: any = null;
  @Input() provinceRequired = false;
  @Input() districtValue: any = null;
  @Input() districtRequired = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onChange = new EventEmitter<any>();
  public formAreaPlace: FormGroup;
  public whereProvince = {};
  public whereDistrict = {};
  public whereCommune = {};

  constructor(private fb: FormBuilder,
    public provinceApi: ProvinceApi,
    public districtApi: DistrictApi,
    public communeApi: CommuneApi) {

    this.formAreaPlace = this.fb.group({
      province: [null],
      district: [null],
      commune: [null]
    });
  }

  async ngOnInit(): Promise<void> {

  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {

    // provinceValue
    if (changes.provinceValue && changes.provinceValue.currentValue !== changes.provinceValue.previousValue) {
      this.formAreaPlace.get('province').setValue(changes.provinceValue.currentValue);
    }
    if (changes.provinceRequired && changes.provinceRequired.currentValue !== changes.provinceRequired.previousValue) {
      if (changes.provinceRequired.currentValue) {
        this.formAreaPlace.get('province').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('province').setValidators([]);
      }
    }

    // districtValue
    if (changes.districtValue && changes.districtValue.currentValue !== changes.districtValue.previousValue) {
      this.formAreaPlace.get('district').setValue(changes.districtValue.currentValue);
    }
    if (changes.districtRequired && changes.districtRequired.currentValue !== changes.districtRequired.previousValue) {
      if (changes.districtRequired.currentValue) {
        this.formAreaPlace.get('district').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('district').setValidators([]);
      }
    }  

    this.onChangeProvince();
  }

  async onChangeProvince(): Promise<void> {
    const provinceCode = this.formAreaPlace.get('province').value;
    this.whereDistrict = {
      provinceCode
    };
    this.formAreaPlace.get('district').setValue(null);   

    if (provinceCode) {
      this.formAreaPlace.get('district').enable();      
    } else {
      this.formAreaPlace.get('district').disable();
    }
    this.onChange.emit(this.formAreaPlace.getRawValue());
  }

  async onChangeDistrict(): Promise<void> {  
    this.onChange.emit(this.formAreaPlace.getRawValue());
  }
  
}
