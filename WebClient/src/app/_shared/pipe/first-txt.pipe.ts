import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstTxt'
})
export class FirstTxtPipe implements PipeTransform {

  transform(value: string, args?: any): any {
    if(!value){
      return '';
    }
    return value.substring(0,1);
  }

}
