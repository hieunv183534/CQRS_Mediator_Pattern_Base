import { DateYYYYMMDDFormatPipe } from './date-yyyymmdd-format.pipe';
import { NgModule } from '@angular/core';
import { DateFormatPipe } from './date-format.pipe';
import { DatetimeFormatPipe } from './datetime-format.pipe';
import { StatusPipe } from './status.pipe';
import { ColorPipe } from './color.pipe';
import { AutChildPipe } from './aut-child.pipe';
import { CsTimeAgoPipe } from './time-ago.pipe';
import { TextMorePipe } from './text-more.pipe';
import { ShowCountPagingPipe } from './show-count-paging.pipe';
import { SafeIframePipe } from './safe-iframe.pipe';
import { StringToFileName } from './stringToFileName.pipe';
import { FirstTxtPipe } from './first-txt.pipe';
import { AbsPipe } from './abs.pipe';

@NgModule({
  declarations: [
    DateFormatPipe,
    DatetimeFormatPipe,
    StatusPipe,
    ColorPipe,
    AutChildPipe,
    CsTimeAgoPipe,
    TextMorePipe,
    StringToFileName,
    ShowCountPagingPipe,
    SafeIframePipe,
    DateYYYYMMDDFormatPipe,
    FirstTxtPipe,
    AbsPipe
  ],
  exports: [
    DateFormatPipe,
    DatetimeFormatPipe,
    StatusPipe,
    ColorPipe,
    AutChildPipe,
    CsTimeAgoPipe,
    TextMorePipe,
    StringToFileName,
    ShowCountPagingPipe,
    SafeIframePipe,
    DateYYYYMMDDFormatPipe,
    FirstTxtPipe,
    AbsPipe
  ]
})
export class PipeModule { }
