import { ProvinceApi, DistrictApi, CommuneApi } from './../../bccp-api.services';
import { ValidatorExtension } from './../../../_base/extensions/validator-extension';
import { Component, Input, OnInit, OnChanges, SimpleChanges, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-area-place',
  templateUrl: './area-place.component.html',
  styleUrls: ['./area-place.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AreaPlaceComponent implements OnInit, OnChanges {

  @Input() provinceValue: any = null;
  @Input() provinceRequired = false;
  @Input() districtValue: any = null;
  @Input() districtRequired = false;
  @Input() communeValue: any = null;
  @Input() communeRequired = false;  
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

  markAllAsDirty(){
    this.formAreaPlace.markAllAsDirty();
  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {

    const fromData = this.formAreaPlace.value;
    // provinceValue
    if (changes.provinceValue && changes.provinceValue.currentValue !== fromData.province) {
      this.formAreaPlace.get('province').setValue(changes.provinceValue.currentValue);
      this.onChangeProvince();
    }
    if (changes.provinceRequired && changes.provinceRequired.currentValue !== changes.provinceRequired.previousValue) {
      if (changes.provinceRequired.currentValue) {
        this.formAreaPlace.get('province').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('province').setValidators([]);
      }
    }

    // districtValue
    if (changes.districtValue && changes.districtValue.currentValue !== fromData.district) {
      this.formAreaPlace.get('district').setValue(changes.districtValue.currentValue);
      this.onChangeDistrict();
    }
    if (changes.districtRequired && changes.districtRequired.currentValue !== changes.districtRequired.previousValue) {
      if (changes.districtRequired.currentValue) {
        this.formAreaPlace.get('district').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('district').setValidators([]);
      }
    }

    // communeValue
    if (changes.communeValue && changes.communeValue.currentValue !== fromData.commune) {
      this.formAreaPlace.get('commune').setValue(changes.communeValue.currentValue);
      this.onChangeCommune();
    }
    if (changes.communeRequired && changes.communeRequired.currentValue !== changes.communeRequired.previousValue) {
      if (changes.communeRequired.currentValue) {
        this.formAreaPlace.get('commune').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('commune').setValidators([]);
      }
    }
  }

  async onChangeProvince(): Promise<void> {
    const provinceCode = this.formAreaPlace.get('province').value;
    this.whereDistrict = {
      provinceCode
    };
    this.formAreaPlace.get('district').setValue(null);
    this.formAreaPlace.get('commune').setValue(null);

    if (provinceCode) {
      this.formAreaPlace.get('district').enable();
      this.formAreaPlace.get('commune').disable();
    } else {
      this.formAreaPlace.get('district').disable();
      this.formAreaPlace.get('commune').disable();
    }
    this.provinceValue = provinceCode;
    this.onChange.emit(this.formAreaPlace.getRawValue());
  }

  async onChangeDistrict(): Promise<void> {
    const districtCode = this.formAreaPlace.get('district').value;
    this.whereCommune = {
      districtCode
    };
    this.formAreaPlace.get('commune').setValue(null);

    if (districtCode) {
      this.formAreaPlace.get('commune').enable();
    } else {
      this.formAreaPlace.get('commune').disable();
    }

    this.districtValue = districtCode;
    this.onChange.emit(this.formAreaPlace.getRawValue());
  }

  async onChangeCommune(): Promise<void> {
    const communeCode = this.formAreaPlace.get('commune').value;
    this.communeValue = communeCode;
    this.onChange.emit(this.formAreaPlace.getRawValue());
  }

}
