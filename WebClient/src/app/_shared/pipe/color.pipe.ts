import { Pipe, PipeTransform } from '@angular/core';
import { OptionModel } from 'src/app/_base/models/option-model';

@Pipe({
  name: 'color'
})
export class ColorPipe implements PipeTransform {

  transform(value: number | string, listOfStatus: OptionModel[]): string {
    const status = listOfStatus.find(x => x.value === value);
    return !!status ? status.color : '';
  }

}
