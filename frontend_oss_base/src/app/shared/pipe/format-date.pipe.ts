import {Pipe, PipeTransform} from '@angular/core';
import {DatePipe} from '@angular/common';
import {Constant} from '../constants/constant.class';

@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe extends DatePipe implements PipeTransform {
  transform(value: any, args?: any): any {
    return super.transform(value, args ? args : Constant.DATE_FMT);
  }
}
