import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';


@Pipe({
  name: 'dateYYYMMDDFormat'
})
export class DateYYYYMMDDFormatPipe extends DatePipe implements PipeTransform {

  // yyyyMMDD -> dd/MM/yyyy
  transform(value: any, args?: any): any {
    if (!value || value.length < 8){
      return '';
    }
    const dateValue = new Date(parseInt(value.substring(0, 4)), parseInt(value.substring(4, 6)) - 1, parseInt(value.substring(6, 8)))
    return super.transform(dateValue, 'dd/MM/yyyy');
  }

}
