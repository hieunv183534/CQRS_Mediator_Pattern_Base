import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'datetimeFormat'
})
export class DatetimeFormatPipe extends DatePipe implements PipeTransform {

  // Datetime -> dd/MM/yyyy hh:mm
  transform(value: any, args?: any): any {
    let date = null;
    if(typeof value === 'string'){
      date = new Date(value);
    }else{
      date = value;
    }
    return super.transform(date, 'dd/MM/yyyy HH:mm');
  }

}
