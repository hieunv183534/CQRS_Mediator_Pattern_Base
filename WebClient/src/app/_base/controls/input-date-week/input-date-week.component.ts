import { Component, EventEmitter, forwardRef, Input, OnInit, Output } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'input-date-week',
  templateUrl: './input-date-week.component.html',
  styleUrls: ['./input-date-week.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputDateWeekComponent),
      multi: true,
    }
  ]
})
export class InputDateWeekComponent implements OnInit, ControlValueAccessor {

  constructor() { }

  @Input() class: any = '';
  @Input() placeholder: any = '';
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() readonly = false;
  @Input() allowClear = true;
  // tslint:disable-next-line:no-output-rename
  @Output('onChange') eventOnChange = new EventEmitter<any>();

  public controlValue: string | null = null;
  public pickerOpen = false;

  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  writeValue(obj: any): void {
    debugger;
    if(!obj){
      obj = [];
      this.controlValue = obj;
      this.onChange();
      return;
    }
    this.controlValue = obj;
  }

  registerOnChange(fn: any): void {
    this.eventBaseChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.eventBaseTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  ngOnInit() {
  }

  onChange(): void {
    let value = this.controlValue;
    this.eventBaseChange(value);
    this.eventOnChange.emit(value);
  }

}
