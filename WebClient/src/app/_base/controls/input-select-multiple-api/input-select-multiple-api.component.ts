import { PagingModel } from 'src/app/_base/models/response-model';
// tslint:disable-next-line:max-line-length
import { Component, OnInit, ViewEncapsulation, forwardRef, OnChanges, Input, Output, EventEmitter, ElementRef, SimpleChanges, OnDestroy, ChangeDetectorRef, AfterViewChecked } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'input-select-multiple-api',
  templateUrl: './input-select-multiple-api.component.html',
  styleUrls: ['./input-select-multiple-api.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputSelectMultipleApiComponent),
      multi: true
    }
  ]
})
export class InputSelectMultipleApiComponent implements OnInit, OnDestroy, ControlValueAccessor, OnChanges {
  constructor(private cdr: ChangeDetectorRef) {
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
  @Input() max: number;
  // tslint:disable-next-line:no-output-rename
  @Output('onChange') eventOnChange = new EventEmitter<any>();
  // tslint:disable-next-line:no-output-rename
  @Output('onBlur') eventOnBlur = new EventEmitter<void>();
  // tslint:disable-next-line:no-output-rename
  @Output('onUnBlur') eventOnUnBlur = new EventEmitter<void>();

  // tslint:disable-next-line:member-ordering
  public controlValue: any[] | null = null;
  public isLoading = false;
  public isInit = false;
  public listOption: any[] = [];
  public listItemBonus: any[] = [];
  public searchChange$ = new BehaviorSubject('');
  public pageChange$ = new BehaviorSubject(1);
  public textSearchOld: string;
  public paging: PagingModel = {
    page: 1,
    size: 20,
    count: 0
  };
  public noData = false;
  private searchChange: any;
  private pageChange: any;
  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  getApiCombobox(param: any): Promise<any> {
    return this.apiService[this.actionName](param).toPromise();
  }

  ngOnInit(): void {
    if (!this.max) {
      this.max = Infinity;
    }
    this.searchChange = this.searchChange$
      .asObservable()
      .pipe(debounceTime(500)).subscribe(textSearch => {
        console.log('searchChange', textSearch);
        this.listOption = [];
        this.noData = false;
        if(!this.disabled){
          this.getData(1, textSearch);
        }
      });
    this.pageChange = this.pageChange$
      .asObservable()
      .pipe(debounceTime(500)).subscribe(page => {
        if (page > 1) {
          console.log('pageChange', page);
          this.getData(page, this.searchChange$.value);
        }
      });
  }

  ngOnDestroy(): void {
    this.searchChange.unsubscribe();
    this.pageChange.unsubscribe();
  }

  async ngOnChanges(changes: SimpleChanges): Promise<void> {
    if (changes.apiParams && !changes.apiParams.firstChange) {
      console.log('ngOnChanges: apiParams', changes.apiParams.currentValue);
      this.listOption = [];
      this.noData = false;
      
      const listTask = [this.getData(1, ''),this.checkItemBonus()]
      this.isInit = false;
      Promise.all(listTask).then(() => {
        this.isInit = true;
        this.cdr.detectChanges();
      });
      
    }
  }

  loadMore(): void {
    const pageNew = this.paging.page + 1;
    if (!this.noData && !this.isLoading && this.pageChange.value !== pageNew) {
      this.pageChange.next(pageNew);
    }
  }

  async getData(page: number = 1, textSearch: string): Promise<void> {
    this.isLoading = true;
    const params = { ...this.paging, ...this.apiParams, textSearch, loadMore: true  };
    this.paging.page = page;
    params.page = page;
    const rs = await this.getApiCombobox(params);
    console.log('getData:' + textSearch, rs);
    if (rs.success) {
      if (rs.result.data.length === 0) {
        this.noData = true;
      } else {
        const valueData = [];
        for (const item of rs.result.data) {
          if ([...this.items, ...this.listItemBonus].findIndex(x => this.deepCompare(x.value, item.value)) === -1) {
            valueData.push({ value: item.value, text: item.text });
          }
        }
        this.listOption = [...this.listOption, ...valueData];
      }
    }
    this.isLoading = false;
  }

  onSearch(value: string): void {
    if (this.searchChange$.value !== value) {
      this.searchChange$.next(value);
    }
  }

  writeValue(obj: any): void {
    this.controlValue = obj;
    this.isInit = false;
    this.checkItemBonus().then(() => {
      this.isInit = true;
      this.cdr.detectChanges();
    });
  }

  async checkItemBonus(): Promise<void> {
    console.log('checkItemBonus', this.controlValue);
    this.listItemBonus = [];
    if (this.controlValue && this.controlValue.length > 0) {
      const checkExits = [...this.items, ...this.listOption].findIndex(x => this.deepCompare(x.value, this.controlValue));
      if (checkExits === -1) {
        const params = { ...this.apiParams, page: 1, size: 200, valueSearch: this.controlValue, loadMore: true  };
        const rs = await this.apiService.getCombobox(params).toPromise();
        if (rs.success) {
          const valueData = [];
          // tslint:disable-next-line: forin
          for (const item of rs.result.data) {
            let itemValue = item.value;
            for (const itemCV of this.controlValue) {
              if (itemCV instanceof Object) {
                if (this.deepCompare(itemCV, itemValue)) {
                  itemValue = itemCV;
                }
              } else {
                break;
              }
            }
            valueData.push({ value: itemValue, text: item.text });
          }
          this.listItemBonus = valueData;
        }
      } else {
        this.controlValue = [...this.items, ...this.listOption][checkExits].value;
      }
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
    const valueData = [this.items, ... this.listItemBonus, ...this.listOption].filter(x => this.controlValue.some(y => this.deepCompare(y, x.value)));
    this.eventBaseChange(this.controlValue);
    this.eventOnChange.emit(valueData);
  }

  onClear(): void {
    this.controlValue = [];
    this.eventBaseChange(this.controlValue);
    this.eventOnChange.emit(this.controlValue);
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
    if(!isDisabled && this.listOption.length === 0 && !this.isLoading){
      this.getData(1,this.searchChange$.value);
    }
  }

  deepCompare(object1: any, object2: any): boolean {
    if (!object1 || !object2) {
      return false;
    }
    if (object1 instanceof Object) {
      let pass = 0;
      let check = 0;
      // tslint:disable-next-line: forin
      for (const key in object1) {
        if (object1[key] === object2[key]) {
          pass++;
        }
        check++;
      }
      return pass === check;
    } else {
      return object1 === object2;
    }
  }
}

