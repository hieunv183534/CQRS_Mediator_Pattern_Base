import { Pipe, PipeTransform } from '@angular/core';
import { TimeAgoPipe } from 'time-ago-pipe';

@Pipe({
  name: 'csTimeAgo'
})
export class CsTimeAgoPipe extends TimeAgoPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value)
      .replace(/^(an|a)/, 'một')
      .replace('few', 'vài')
      .replace('seconds', 'giây')
      .replace(/minutes|minute/, 'phút')
      .replace(/hours|hour/, 'giờ')
      .replace(/days|day/, 'ngày')
      .replace(/months|month/, 'tháng')
      .replace(/years|year/, 'năm')
      .replace('ago', 'trước');
  }

}
