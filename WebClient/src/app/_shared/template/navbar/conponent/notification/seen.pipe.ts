import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'seen'
})
export class SeenPipe implements PipeTransform {

  transform(value: any[]): boolean {
    const notSeen = value.filter(x => !x?.readTime);
    return notSeen.length > 0;
  }
}
