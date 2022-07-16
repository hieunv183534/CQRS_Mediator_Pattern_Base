import { Pipe, PipeTransform } from '@angular/core';
import { OptionModel } from 'src/app/_base/models/option-model';

@Pipe({
  name: 'status'
})
export class StatusPipe implements PipeTransform {

  transform(value: number | string, listOfStatus: OptionModel[]): string {
    const status = listOfStatus.find(x => x.value === value);
    return !!status ? status.text : '';
  }

}
