import { Component, OnInit, ViewEncapsulation, forwardRef, AfterViewInit, OnChanges, Input, Output, EventEmitter, ElementRef, SimpleChanges } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import createNumberMask from 'text-mask-addons/dist/createNumberMask';

declare var $;
@Component({
  selector: 'input-number',
  templateUrl: './input-number.component.html',
  styleUrls: ['./input-number.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputNumberComponent),
      multi: true,
    }
  ]
})
export class InputNumberComponent implements OnInit, AfterViewInit, ControlValueAccessor, OnChanges {
  constructor(
    private el: ElementRef
  ) { }

  @Input() class: any = '';
  @Input() placeholder: any = '';
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() readonly = false;
  @Input() min: number;
  @Input() max: number;
  @Input() step: number = 1;
  @Input() symbol: string = ' ';
  @Input() prefix: string = '';
  @Output('onChange') eventOnChange = new EventEmitter<any>();
  // tslint:disable-next-line: no-output-rename
  @Output('onBlur') eventOnBlur = new EventEmitter<void>();
  // tslint:disable-next-line: no-output-rename
  @Output('onUnBlur') eventOnUnBlur = new EventEmitter<void>();

  public controlValue: number | null = null;
  public maskFomat = createNumberMask({
    prefix: this.prefix,
    allowNegative: true,
    allowDecimal: false,
    thousandsSeparatorSymbol: this.symbol
  });
  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
  }

  ngAfterViewInit() {
    $(this.el.nativeElement).removeClass(this.class);
  }

  writeValue(obj: any) {
    this.controlValue = obj;
  }

  registerOnChange(fn: any) {
    this.eventBaseChange = fn;
  }

  registerOnTouched(fn: any) {
    this.eventBaseTouched = fn;
  }

  onBlur() {
    this.eventBaseTouched();
    this.eventOnBlur.emit();
  }

  onUnBlur() {
    if (this.getValue() > this.max) {
      this.controlValue = this.max;
      this.onChange();
    }
    if (this.getValue() < this.min) {
      this.controlValue = this.min;
      this.onChange();
    }
    this.eventOnUnBlur.emit();
  }

  onChange() {
    const val = this.getValue();
    this.eventBaseChange(+val);
    this.eventOnChange.emit(+val);
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  pushValue() {
    const val = this.getValue();
    if (this.max && +val + this.step > this.max) {
      this.controlValue = this.max;
      this.onChange();
      return;
    }
    this.controlValue = +val + this.step;
    this.onChange();
  }

  minusValue() {
    const val = this.getValue();
    if (+val <= this.min) { return; }
    if (+val <= this.step) {
      this.controlValue = this.min;
      this.onChange();
      return;
    }
    this.controlValue = +val - this.step;
    this.onChange();
  }

  private getValue() {
    let val: any = this.controlValue;
    if (!val) { val = ''; }
    val = val.toString().replace(new RegExp(this.symbol, 'g'), '');
    if (this.prefix !== '') {
      val = val.replace(new RegExp(this.prefix, 'g'), '');
    }
    return +val;
  }
}

