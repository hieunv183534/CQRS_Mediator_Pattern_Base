import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {DateFormatPipe} from './pipe/format-date.pipe';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {ScrollingModule} from '@angular/cdk/scrolling';
// import {NzTagModule} from 'ng-zorro-antd/tag';
// import {
//   NgZorroAntdModule,
//   NzButtonModule, NzCollapseModule,
//   NzIconModule,
//   NzInputModule,
//   NzLayoutModule,
//   NzModalModule,
//   NzPaginationModule,
//   NzSelectModule,
//   NzTableModule,
// } from 'ng-zorro-antd';
// import {NzNotificationModule} from 'ng-zorro-antd/notification';
import {I18nModule} from '../i18n/i18n.module';
import {SelectLanguageComponent} from './component/select-language/select-language.component';
// import {NzFormModule} from 'ng-zorro-antd/form';
// import {NzResultModule} from 'ng-zorro-antd/result';
// import {NzDropDownModule} from 'ng-zorro-antd/dropdown';
// import {NzDatePickerModule} from 'ng-zorro-antd/date-picker';
// import {ReportDownloadComponent} from './component/report-download/report-download.component';
// import {ReportDownloadSelectionComponent} from './component/report-download/report-download-selection.component';
// import {IsNumberDirective} from './directive/is-number.directive';
// import {CurrencyFormatPipe} from './pipe/currency-format.pipe';
// import {MaskDateDirective} from './directive/mask-date.directive';
import {ErrorInterceptor} from './interceptor/error.interceptor';
// import { DownloadFileDirective } from './directive/download-file.directive';
// import {TruncatePipe} from './pipe/truncate.pipe';
// import {ParseCurrencyViDirective} from './directive/parse-currency-vi.directive';
// import {MaskTwoDecimalsDirective} from './directive/mask-two-decimals.directive';
// import {NumbericDirective} from './directive/numberic.directive';
// import {CurrencyFormatVNPipe} from './pipe/currency-format-vi.pipe';
// import { FilterColumnTableComponent } from './component/filter-column/filter-column.component';
// import { LoadingCustomComponent } from './component/loading-custom/loading-custom.component';
// import { NzBackTopModule } from 'ng-zorro-antd/back-top';
// import { NzRadioModule } from 'ng-zorro-antd/radio';
// import { ExportReportComponent } from './component/export-report/export-report.component';
// import { ExportButtonComponent } from './component/export-report/export-button/export-button.component';
// import {ParseCurrencyDirective} from './directive/parse-currency.directive';
// import {SanitizeHtmlPipe} from "./pipe/sanitize-html.pipe";
// import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { EditorModule, TINYMCE_SCRIPT_SRC } from '@tinymce/tinymce-angular';
// import { UploadInputComponent } from './component/upload-input/upload-input.component';
// import {UploadImageComponent} from "./component/upload-image/upload-image.component";
// import { NgxDateTimePickerComponent } from './component/ngx-date-time-picker/ngx-date-time-picker.component';
// import {BsDatepickerModule} from "ngx-bootstrap/datepicker";
// import {TimepickerModule} from "ngx-bootstrap/timepicker";


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    // NzTableModule,
    // NzPaginationModule,
    // NzInputModule,
    // NzButtonModule,
    // NzSelectModule,
    // NzModalModule,
    // NzIconModule,
    // NzLayoutModule,
    ScrollingModule,
    DragDropModule,
    // NzCollapseModule,
    // NgZorroAntdModule,
    // NzNotificationModule,
    I18nModule,
    // NzFormModule,
    // NzResultModule,
    // NzTagModule,
    // NzDropDownModule,
    // NzDatePickerModule,
    ScrollingModule,
    DragDropModule,
    // NzBackTopModule,
    // NzRadioModule,
    // CKEditorModule,
    // EditorModule,
    // BsDatepickerModule,
    // TimepickerModule
  ],
  exports: [
    DateFormatPipe,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    // NzTableModule,
    // NzPaginationModule,
    // NzInputModule,
    // NzButtonModule,
    // NzSelectModule,
    // NzModalModule,
    // NzIconModule,
    // NzCollapseModule,
    // NgZorroAntdModule,
    // NzNotificationModule,
    I18nModule,
    SelectLanguageComponent,
    // NzFormModule,
    // NzResultModule,
    // NzTagModule,
    // NzDropDownModule,
    // NzDatePickerModule,
    ScrollingModule,
    DragDropModule,
    // NzBackTopModule,
    // NzRadioModule,
    // CKEditorModule,
    // EditorModule,

    // Own

    // ReportDownloadComponent,
    // ReportDownloadSelectionComponent,
    // IsNumberDirective,
    // CurrencyFormatPipe,
    // CurrencyFormatVNPipe,
    // MaskDateDirective,
    // TruncatePipe,
    // SanitizeHtmlPipe,
    // DownloadFileDirective,
    // ParseCurrencyViDirective,
    // ParseCurrencyDirective,
    // MaskTwoDecimalsDirective,
    // NumbericDirective,
    // FilterColumnTableComponent,
    // LoadingCustomComponent,
    // ExportButtonComponent,
    // UploadInputComponent,
    // UploadImageComponent,
    // NgxDateTimePickerComponent
  ],
  declarations: [
    DateFormatPipe,
    SelectLanguageComponent,
    // ReportDownloadComponent,
    // ReportDownloadSelectionComponent,
    // IsNumberDirective,
    // CurrencyFormatPipe,
    // CurrencyFormatVNPipe,
    // MaskDateDirective,
    // DownloadFileDirective,
    // TruncatePipe,
    // SanitizeHtmlPipe,
    // ParseCurrencyViDirective,
    // ParseCurrencyDirective,
    // MaskTwoDecimalsDirective,
    // NumbericDirective,
    // FilterColumnTableComponent,
    // LoadingCustomComponent,
    // ExportReportComponent,
    // ExportButtonComponent,
    // UploadInputComponent,
    // UploadImageComponent,
    // NgxDateTimePickerComponent
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
  },
  { provide: TINYMCE_SCRIPT_SRC, useValue: 'tinymce/tinymce.min.js' },
],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SharedModule {
}
