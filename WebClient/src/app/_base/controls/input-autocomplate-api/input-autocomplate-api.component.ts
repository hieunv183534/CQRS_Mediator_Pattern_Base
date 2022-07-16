import { PagingModel } from 'src/app/_base/models/response-model';
// tslint:disable-next-line:max-line-length
import { Component, OnInit, ViewEncapsulation, forwardRef, OnChanges, Input, Output, EventEmitter, ElementRef, SimpleChanges, OnDestroy } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { BehaviorSubject, from, Observable } from 'rxjs';
import { debounceTime, map, switchMap } from 'rxjs/operators';

declare var $;
@Component({
  // tslint:disable-next-line: component-selector
  selector: 'input-autocomplate-api',
  templateUrl: './input-autocomplate-api.component.html',
  styleUrls: ['./input-autocomplate-api.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputAutocomplateApiComponent),
      multi: true
    }
  ]
})
export class InputAutocomplateApiComponent implements OnInit, OnDestroy, ControlValueAccessor, OnChanges {
  constructor(
    private el: ElementRef
  ) {
    if (!this.actionName) {
      this.actionName = 'getCombobox';
    }
  }

  @Input() classControl: any = '';
  @Input() placeholder: any = '';
  @Input() apiService: any;
  @Input() actionName: string;
  @Input() apiParams: any = {};
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() readonly = false;
  @Input() allowClear = true;
  @Input() allowSearch = true;
  @Input() items: any[] = [];
  // tslint:disable-next-line:no-output-rename
  @Output('onChange') eventOnChange = new EventEmitter<any>();
  // tslint:disable-next-line:no-output-rename
  @Output('onBlur') eventOnBlur = new EventEmitter<void>();
  // tslint:disable-next-line:no-output-rename
  @Output('onUnBlur') eventOnUnBlur = new EventEmitter<void>();

  // tslint:disable-next-line:member-ordering
  public controlValue: any | null = null;
  public isLoading = false;
  public listOption: any[] = [];
  public searchChange$ = new BehaviorSubject('');
  public pageChange$ = new BehaviorSubject(1);
  public keySearchOld: string;
  public paging: PagingModel = {
    page: 1,
    size: 20,
    count: 0
  };
  public noData = false;
  private searchChange: any;
  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  getApiCombobox(param: any): Promise<any> {
    return this.apiService[this.actionName](param).toPromise();
  }

  ngOnInit(): void {
    this.searchChange = this.searchChange$
      .asObservable()
      .pipe(debounceTime(500)).subscribe(keySearch => {
        console.log('searchChange', keySearch);
        this.listOption = [];
        this.noData = false;
        this.getData(1, keySearch);
      });
  }

  ngOnDestroy(): void {
    this.searchChange.unsubscribe();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.apiParams && !changes.apiParams.firstChange) {
      console.log('ngOnChanges: apiParams', changes.apiParams.currentValue);
      this.listOption = [];
      this.noData = false;
      this.getData(1, '');
    }
  }

  async getData(page: number = 1, keySearch: string): Promise<void> {
    this.isLoading = true;
    const params = { ...this.paging, ...this.apiParams, keySearch };
    this.paging.page = page;
    params.page = page;
    const rs = await this.getApiCombobox(params);
    console.log('getData:' + keySearch, rs);
    if (rs.success) {
      if (rs.result.data.length === 0) {
        this.noData = true;
      } else {
        const valueData = [];
        for (const item of rs.result.data) {
          if (this.items.findIndex(x => x.value === item.value) === -1) {
            valueData.push({ value: item.value, text: item.text });
          }
        }
        this.listOption = [...this.listOption, ...valueData];
      }
    }
    this.isLoading = false;
  }

  writeValue(obj: any): void {
    this.controlValue = obj;
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
    if (this.searchChange$.value !== this.controlValue) {
      this.searchChange$.next(this.controlValue);
    }
    this.eventBaseChange(this.controlValue);
    this.eventOnChange.emit(this.controlValue);
  }

  onClear(): void {
    this.controlValue = '';
    this.eventBaseChange(this.controlValue);
    this.eventOnChange.emit(this.controlValue);
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }
}

