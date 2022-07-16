import { Component, forwardRef, OnInit} from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR, NgControl} from "@angular/forms";
import {noop} from "rxjs";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-ngx-date-time-picker',
  templateUrl: './ngx-date-time-picker.component.html',
  styleUrls: ['./ngx-date-time-picker.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => NgxDateTimePickerComponent),
    }
  ]
})
export class NgxDateTimePickerComponent implements OnInit, ControlValueAccessor {
  public ngControl: NgControl;
  isMeridian = false;
  showSpinners = false;
  myTime: Date = new Date();
  isVisibleDateTimePicker = false;
  dateString = new Date();
  bsInlineValue = new Date();
  public onTouched: () => void = noop;
  public onChange: (_: any) => void = noop;

  constructor(private datePipe: DatePipe) { }

  ngOnInit(): void {

  }

  onInputChange(value: any) {
    let isValidDate = true;
    let _dateValue = value.target.value.trim();
    if (_dateValue !== null && _dateValue !== '') {
      if (_dateValue.indexOf(' ') === _dateValue.lastIndexOf(' ')) {
        const arrayDate = _dateValue.split(' ');
        if (arrayDate.length === 2) {
          const _date = arrayDate[0];
          const _hoursAndMinutes = arrayDate[1];
          let _dateParts = _date.split("/");
          if (_dateParts.length === 3) {
            let arrayTime = _hoursAndMinutes.split(':');
            if (arrayTime.length === 2) {
              let _dateObject = new Date(+_dateParts[2], _dateParts[1] - 1, +_dateParts[0], arrayTime[0], arrayTime[1], 59);
              this.dateString = _dateObject;
              this.bsInlineValue = _dateObject;
              this.myTime = _dateObject;
              console.log(_dateObject, '_datObject');
            } else {
              isValidDate = false;
            }
          } else {
            isValidDate = false;
          }
        } else {
          isValidDate = false;
        }
      } else {
        isValidDate = false;
      }
    } else {
      isValidDate = false;
    }
    console.log(isValidDate);
    if (isValidDate) {
      this.onChange(this.dateString);
    }
  }

  writeValue(newModel: Date) {
    console.log(newModel, "newModel");
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  bsValueChange(bsValue: Date) {
    this.bsInlineValue = new Date(bsValue);
    bsValue.setHours(this.myTime.getHours());
    bsValue.setMinutes(this.myTime.getMinutes());
    this.dateString = bsValue;
    this.bsInlineValue = bsValue;
    this.onChange(this.dateString);
  }
  changeTimeModel(time: any) {
    let _date = new Date(this.bsInlineValue);
    _date.setHours(this.myTime.getHours());
    _date.setMinutes(this.myTime.getMinutes());
    this.dateString = _date;
    this.onChange(this.dateString);
  }
}
