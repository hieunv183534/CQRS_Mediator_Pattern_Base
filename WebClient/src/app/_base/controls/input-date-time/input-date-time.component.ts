import { DatePipe } from '@angular/common';
import {
  AfterViewInit,
  Component,
  ElementRef,
  EventEmitter,
  forwardRef,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild,
  ViewEncapsulation
} from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import Inputmask from 'inputmask';


declare let $;
@Component({
  selector: 'input-date-time',
  templateUrl: './input-date-time.component.html',
  styleUrls: ['./input-date-time.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputDateTimeComponent),
      multi: true,
    }
  ]
})
export class InputDateTimeComponent implements OnInit, AfterViewInit, ControlValueAccessor, OnChanges {
  constructor(
    private el: ElementRef,
    public datePipe: DatePipe
  ) { }

  @Input() class: any = '';
  @Input() placeholder: any = '';
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() readonly = false;
  @Input() format = 'dd/MM/yyyy HH:mm';
  @Input() allowClear = true;
  @Input() min: number;
  @Input() max: number;
  // tslint:disable-next-line:no-output-rename
  @Output('onChange') eventOnChange = new EventEmitter<any>();
  // tslint:disable-next-line:no-output-rename
  @Output('onBlur') eventOnBlur = new EventEmitter<void>();
  // tslint:disable-next-line:no-output-rename
  @Output('onUnBlur') eventOnUnBlur = new EventEmitter<void>();

  @ViewChild('myInputDate') myInputElementRef: ElementRef;

  // tslint:disable-next-line:member-ordering
  public controlValueDate: Date | null = null;
  public controlValue: string | null = null;
  public pickerOpen = false;

  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  ngOnInit(): void {

  }

  ngOnChanges(changes: SimpleChanges): void {
  }

  ngAfterViewInit(): void {
    $(this.el.nativeElement).removeClass(this.class);
    Inputmask('datetime', {
      inputFormat: 'dd/mm/yyyy HH:MM',
      placeholder: '__/__/____ __:__',
      alias: 'datetime',
      min: '01/01/0000',
      clearMaskOnLostFocus: false,
      // isComplete: (buffer, opts) => {
      //   console.log('Data', buffer, opts);
      // },
    }).mask(this.myInputElementRef.nativeElement);
  }

  writeValue(obj: any): void {
    if (typeof obj === 'string'){
      console.error('Gi?? tr??? input-date-time ph???i l?? Date');
    }else{
      // this.controlValue = obj;
      this.controlValue = this.datePipe.transform(obj, this.format);
      this.controlValueDate = obj;
    }
  }

  registerOnChange(fn: any): void {
    this.eventBaseChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.eventBaseTouched = fn;
  }

  onBlur(): void {
    this.eventBaseTouched();
    this.eventOnBlur.emit();
  }

  onUnBlur(): void {
    this.eventOnUnBlur.emit();
  }

  onChange(): void {
    // this.eventBaseChange(this.getValueControl());
    // this.eventOnChange.emit(this.getValueControl());
    if (/[_]/.test(this.controlValue)) {
      this.controlValue = null;
    }
    const value = this.getValueControl();
    this.controlValueDate = value;
    this.pickerOpen = false;
    this.eventBaseChange(value);
    this.eventOnChange.emit(value);
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  getValueControl(): Date {
    if (!this.controlValue) {
      return null;
    }
    return this.getValueDate();
  }

  getValueDate(): Date {
    const fullDateTime = this.controlValue.split(' ');
    const arrDate = fullDateTime[0].split('/');
    const arrTime = fullDateTime[1].split(':');
    return new Date(
      +arrDate[2],
      +arrDate[1] - 1,
      +arrDate[0],
      +arrTime[0],
      +arrTime[1],
    );
  }

  handleEndOpenChange(open: boolean): void {
    console.log(open);
    this.pickerOpen = open;
  }

  openPicker(): void {
    // this.dateTimePicker.open();
    this.pickerOpen = !this.pickerOpen;
  }

  onChangePicker(): void {
    console.log('onChangePicker', this.controlValueDate);
    this.controlValue = this.controlValue = this.datePipe.transform(this.controlValueDate, this.format);
    this.onChange();
  }

  onClear(): void {
    this.controlValue = null;
    this.controlValueDate = null;
    this.eventBaseChange(this.controlValue);
    this.eventOnChange.emit(this.controlValue);
  }
}
