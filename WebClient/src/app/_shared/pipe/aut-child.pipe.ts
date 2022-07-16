import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'autChild'
})
export class AutChildPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.checkChild(value);
  }

  checkChild(authData: any) {
    let result = [];
    for (const key in authData) {
      if ((typeof authData[key] === 'object') && Array.isArray(authData[key])) {
        result = result.concat(authData[key]);
      } else {
        result = result.concat(this.checkChild(authData[key]));
      }
    }

    return result;
  }

}
