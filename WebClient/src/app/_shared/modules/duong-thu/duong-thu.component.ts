import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { GiaoNhanMailRouteApi, GiaoNhanMailRouteScheduleApi, GiaoNhanMailRoutePOSApi } from '../../bccp-api.services';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-duong-thu',
  templateUrl: './duong-thu.component.html',
  styleUrls: ['./duong-thu.component.scss']
})
export class DuongThuComponent implements OnInit, OnChanges {

  @Input() mailrouteValue: any = null;
  @Input() mailrouteRequired = false;
  @Input() mailroutescheduleValue: any = null;
  @Input() mailroutescheduleRequired = false;
  @Input() mailrouteposValue: any = null;
  @Input() mailrouteposRequired = false;
  @Input() disabled = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onChange = new EventEmitter<any>();
  public formAreaPlace: FormGroup;
  public whereMailroute = {};
  public whereMailrouteSchedule = {};
  public whereMailroutePOS = {};
  public disabledControl = false;
  constructor(private fb: FormBuilder,
    public mailrouteApi: GiaoNhanMailRouteApi,
    public mailroutescheduleApi: GiaoNhanMailRouteScheduleApi,
    public mailrouteposApi: GiaoNhanMailRoutePOSApi,
    private userService: UserService) {

    this.formAreaPlace = this.fb.group({
      mailroute: [null],
      mailrouteschedule: [null],
      mailroutepos: [null]
    });
  }

  async ngOnInit(): Promise<void> {
    this.whereMailroute = {pOSCode: this.userService.userInfo.postCode};
    if(this.disabled)
    {
      this.disabledControl = true;
    }
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

    // districtValue
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

    // communeValue
    if (changes.mailrouteposValue && changes.mailrouteposValue.currentValue !== changes.mailrouteposValue.previousValue) {
      if (changes.mailrouteposValue.currentValue !== this.formAreaPlace.get('mailroutepos').value) {
        this.formAreaPlace.get('mailroutepos').setValue(changes.mailrouteposValue.currentValue);
        this.onChangeMailroutePOS(false);
      }
    }
    if (changes.mailrouteposRequired && changes.mailrouteposRequired.currentValue !== changes.mailrouteposRequired.previousValue) {
      if (changes.mailrouteposRequired.currentValue) {
        this.formAreaPlace.get('mailroutepos').setValidators([ValidatorExtension.required('Không được để trống')]);
      } else {
        this.formAreaPlace.get('mailroutepos').setValidators([]);
      }
    }

    // disable control
    if (changes.disabled && changes.disabled.currentValue !== changes.disabled.previousValue) {
      if (changes.disabled.currentValue) {
        this.formAreaPlace.disableMulti(['mailroute', 'mailrouteschedule', 'mailroutepos']);
      } else {
        this.formAreaPlace.enableMulti(['mailroute', 'mailrouteschedule', 'mailroutepos']);
      }
    }
  }

  async onChangeMailroute(isEmitChange = true): Promise<void> {
    const mailRouteKey = this.formAreaPlace.get('mailroute').value;
    this.whereMailrouteSchedule = {
      mailRouteKey
    };
    this.formAreaPlace.get('mailrouteschedule').setValue(null);
    this.formAreaPlace.get('mailroutepos').setValue(null);

    if (mailRouteKey) {
      this.formAreaPlace.get('mailrouteschedule').enable();
      this.formAreaPlace.get('mailroutepos').disable();
    } else {
      this.formAreaPlace.get('mailrouteschedule').disable();
      this.formAreaPlace.get('mailroutepos').disable();
    }
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }

  async onChangeMailrouteSchedule(isEmitChange = true): Promise<void> {
    const mailRouteScheduleKey = this.formAreaPlace.get('mailrouteschedule').value;
    this.whereMailroutePOS = {
      mailRouteScheduleKey
    };
    this.formAreaPlace.get('mailroutepos').setValue(null);

    if (mailRouteScheduleKey) {
      this.formAreaPlace.get('mailroutepos').enable();
    } else {
      this.formAreaPlace.get('mailroutepos').disable();
    }

    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }

  async onChangeMailroutePOS(isEmitChange = true): Promise<void> {
    if (isEmitChange) {
      this.onChange.emit(this.formAreaPlace.getRawValue());
    }
  }

}

