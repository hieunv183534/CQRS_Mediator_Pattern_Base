import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { DimDeliveryRouteApi, PhatDeliveryPointApi } from '../../bccp-api.services';
import { UserService } from './../../../_shared/services/user.service';
@Component({
  selector: 'app-diemphat',
  templateUrl: './diemphat.component.html',
  styleUrls: ['./diemphat.component.scss']
})
export class DiemphatComponent implements OnInit, OnChanges {

  @Input() deliveryrouteValue: any = null;
  @Input() deliveryrouteRequired = false;
  @Input() deliverypointValue: any = null;
  @Input() deliverypointRequired = false;
  @Input() disabled = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onChange = new EventEmitter<any>();
  public formAreaPlace: FormGroup;
  public whereDeliveryRoute = {};
  public whereDeliveryPoint = {};

  constructor(private fb: FormBuilder,
    public userService: UserService,
    public deliveryrouteApi: DimDeliveryRouteApi,
    public deliverypointApi: PhatDeliveryPointApi) {

    this.formAreaPlace = this.fb.group({
      deliveryroute: [null],
      deliverypoint: [null]
    });
  }

  async ngOnInit(): Promise<void> {

  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    // provinceValue
    if (changes.deliveryrouteValue && changes.deliveryrouteValue.currentValue !== changes.deliveryrouteValue.previousValue) {
      if (changes.deliveryrouteValue.currentValue !== this.formAreaPlace.get('deliveryroute').value) {
        this.formAreaPlace.get('deliveryroute').setValue(changes.deliveryrouteValue.currentValue);
        this.onChangeDeliveryroute(false);
      }
    }
    if (changes.deliveryrouteRequired && changes.deliveryrouteRequired.currentValue !== changes.deliveryrouteRequired.previousValue) {
      if (changes.deliveryrouteRequired.currentValue) {
        this.formAreaPlace.get('deliveryroute').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('deliveryroute').setValidators([]);
      }
    }   
    if (changes.deliverypointValue && changes.deliverypointValue.currentValue !== changes.deliverypointValue.previousValue) {
      if (changes.deliverypointValue.currentValue !== this.formAreaPlace.get('deliverypoint').value) {
        this.formAreaPlace.get('deliverypoint').setValue(changes.deliverypointValue.currentValue);
        this.onChangeDeliverypoint(false);
      }
    }
    if (changes.deliverypointRequired && changes.deliverypointRequired.currentValue
      !== changes.deliverypointRequired.previousValue) {
      if (changes.districtRequired.currentValue) {
        this.formAreaPlace.get('deliverypoint').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('deliverypoint').setValidators([]);
      }
    }
    // disable control
    if (changes.disabled && changes.disabled.currentValue !== changes.disabled.previousValue) {
      if (changes.disabled.currentValue) {
        this.formAreaPlace.disableMulti(['deliveryroute', 'deliverypoint']);
      } else {
        this.formAreaPlace.enableMulti(['deliveryroute', 'deliverypoint']);
      }
    }
  }

  async onChangeDeliveryroute(isEmitChange = true): Promise<void> {
    debugger;
    const deliveryrouteKey = this.formAreaPlace.get('deliveryroute').value;
    this.whereDeliveryPoint = {
      deliveryrouteKey,
      fromPOSCode: deliveryrouteKey.fromPOSCode,
      deliveryRouteCode: deliveryrouteKey.deliveryRouteCode
    };
    this.formAreaPlace.get('deliverypoint').setValue(null);
    if (deliveryrouteKey) {
      this.formAreaPlace.get('deliverypoint').enable();
    } else {
      this.formAreaPlace.get('deliverypoint').disable();
    }
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }

  async onChangeDeliverypoint(isEmitChange = true): Promise<void> {
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }
}

