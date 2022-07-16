import { InputPasswordModule } from './../input-password/input-password.module';
import { InputFileModule } from './../input-file/input-file.module';
import { InputDateTimeModule } from './../input-date-time/input-date-time.module';
import { InputTimeModule } from './../input-time/input-time.module';
import { InputAutocomplateApiModule } from './../input-autocomplate-api/input-autocomplate-api.module';
import { InputSelectApiModule } from './../input-select-api/input-select-api.module';
import { PipeModule } from 'src/app/_shared/pipe/pipe.module';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { PagingModule } from '../paging/paging.module';
import { InputTextModule } from '../input-text/input-text.module';
import { InputTextSearchModule } from '../input-text-search/input-text-search.module';
import { InputNumberModule } from '../input-number/input-number.module';
import { InputMonthModule } from '../input-month/input-month.module';
import { InputDateModule } from '../input-date/input-date.module';
import { InputFloatModule } from '../input-float/input-float.module';
import { InputSelectModule } from '../input-select/input-select.module';
import { InputTextareaModule } from '../input-textarea/input-textarea.module';
import { InputSwitchModule } from '../input-switch/input-switch.module';
import { InputCheckBoxModule } from '../input-check-box/input-check-box.module';
import { RenderErrorsModule } from '../render-errors/render-errors.module';
import { InputRadioModule } from '../input-radio/input-radio.module';
import { InputSelectMultipleModule } from '../input-select-multiple/input-select-multiple.module';
import { InputSelectMultipleApiModule } from '../input-select-multiple-api/input-select-multiple-api.module';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { InputDateWeekModule } from './../input-date-week/input-date-week.module';
import { InputDateRangeModule } from './../input-date-range/input-date-range.module';

@NgModule({
  imports: [
    FormsModule,
    ReactiveFormsModule,
    PagingModule,
    InputTextModule,
    InputTextSearchModule,
    InputNumberModule,
    InputDateModule,
    InputTimeModule,
    InputMonthModule,
    InputFloatModule,
    InputSelectModule,
    InputTextareaModule,
    InputSwitchModule,
    InputCheckBoxModule,
    InputRadioModule,
    InputSelectMultipleModule,
    InputSelectApiModule,
    InputSelectMultipleApiModule,
    InputAutocomplateApiModule,
    InputDateTimeModule,
    NgZorroAntdModule,
    InputFileModule,
    InputPasswordModule,
    InputDateWeekModule,
    InputDateRangeModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    PagingModule,
    InputTextModule,
    InputTextSearchModule,
    InputNumberModule,
    InputDateModule,
    InputTimeModule,
    InputMonthModule,
    InputFloatModule,
    InputSelectModule,
    InputTextareaModule,
    PipeModule,
    InputSwitchModule,
    InputCheckBoxModule,
    InputRadioModule,
    InputSelectMultipleModule,
    RenderErrorsModule,
    InputSelectApiModule,
    InputSelectMultipleApiModule,
    InputAutocomplateApiModule,
    InputDateTimeModule,
    NgZorroAntdModule,
    InputFileModule,
    InputPasswordModule,
    InputDateWeekModule,
    InputDateRangeModule
  ]
})
export class FormModule {
}
