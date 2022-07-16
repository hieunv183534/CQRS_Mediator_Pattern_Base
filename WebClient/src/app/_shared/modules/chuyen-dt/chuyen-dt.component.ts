import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { GiaoNhanMailRouteApi, GiaoNhanMailRouteScheduleApi } from '../../bccp-api.services';
import { UserService } from './../../../_shared/services/user.service';
@Component({
  selector: 'app-chuyen-dt',
  templateUrl: './chuyen-dt.component.html',
  styleUrls: ['./chuyen-dt.component.scss']
})
export class ChuyenDtComponent implements OnInit, OnChanges {

  @Input() mailrouteValue: any = null;
  @Input() mailrouteRequired = false;
  @Input() mailroutescheduleValue: any = null;
  @Input() mailroutescheduleRequired = false;
  @Input() disabled = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onChange = new EventEmitter<any>();
  public formAreaPlace: FormGroup;
  public whereMailroute = {};
  public whereMailrouteSchedule = {};

  constructor(private fb: FormBuilder,
    public userService: UserService,
    public mailrouteApi: GiaoNhanMailRouteApi,
    public mailroutescheduleApi: GiaoNhanMailRouteScheduleApi) {

    this.formAreaPlace = this.fb.group({
      mailroute: [null],
      mailrouteschedule: [null]
    });
  }

  async ngOnInit(): Promise<void> {

  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    // provinceValue
    if (changes.mailrouteValue && changes.mailrouteValue.currentValue !== changes.mailrouteValue.previousValue) {
      if (changes.mailrouteValue.currentValue !== this.formAreaPlace.get('mailroute').value) {
        this.formAreaPlace.get('mailroute').setValue(changes.mailrouteValue.currentValue);
        this.onChangeMailroute(false);
      }
    }
    if (changes.mailrouteRequired && changes.mailrouteRequired.currentValue !== changes.mailrouteRequired.previousValue) {
      if (changes.mailrouteRequired.currentValue) {
        this.formAreaPlace.get('mailroute').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('mailroute').setValidators([]);
      }
    }   
    if (changes.mailroutescheduleValue && changes.mailroutescheduleValue.currentValue !== changes.mailroutescheduleValue.previousValue) {
      if (changes.mailroutescheduleValue.currentValue !== this.formAreaPlace.get('mailrouteschedule').value) {
        this.formAreaPlace.get('mailrouteschedule').setValue(changes.mailroutescheduleValue.currentValue);
        this.onChangeMailrouteSchedule(false);
      }
    }
    if (changes.mailroutescheduleRequired && changes.mailroutescheduleRequired.currentValue
      !== changes.mailroutescheduleRequired.previousValue) {
      if (changes.districtRequired.currentValue) {
        this.formAreaPlace.get('mailrouteschedule').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('mailrouteschedule').setValidators([]);
      }
    }
    // disable control
    if (changes.disabled && changes.disabled.currentValue !== changes.disabled.previousValue) {
      if (changes.disabled.currentValue) {
        this.formAreaPlace.disableMulti(['mailroute', 'mailrouteschedule']);
      } else {
        this.formAreaPlace.enableMulti(['mailroute', 'mailrouteschedule']);
      }
    }
  }

  async onChangeMailroute(isEmitChange = true): Promise<void> {
    const mailRouteKey = this.formAreaPlace.get('mailroute').value;
    this.whereMailrouteSchedule = {
      mailRouteKey
    };
    this.formAreaPlace.get('mailrouteschedule').setValue(null);
    if (mailRouteKey) {
      this.formAreaPlace.get('mailrouteschedule').enable();
    } else {
      this.formAreaPlace.get('mailrouteschedule').disable();
    }
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }

  async onChangeMailrouteSchedule(isEmitChange = true): Promise<void> {
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }
}

