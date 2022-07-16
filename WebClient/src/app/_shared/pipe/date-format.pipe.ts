import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';


@Pipe({
  name: 'dateFormat'
})
export class DateFormatPipe extends DatePipe implements PipeTransform {

  // Date -> dd/MM/yyyy
  transform(value: any, format?: string): any {
    let date = null;
    if (format == null) {
      format = 'dd/MM/yyyy';
    }
    if (typeof value === 'string'){
      date = new Date(value);
    }else{
      date = value;
    }
    console.log('xxxx', format);
    return super.transform(date, format);
  }

}
