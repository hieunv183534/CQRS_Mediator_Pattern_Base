import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'stringToFileName'
})
export class StringToFileName implements PipeTransform {

  transform(value: any, len?: number): any {
    if (!value) { return ''; }
    if (value === '') { return ''; }
    const fileName = JSON.parse(value)[0].fileName;

    // kiểm tra nếu không truyền vào độ dài thì trả về file name
    if (!len) { return fileName; }
    // Nếu truyền vào độ dài thì cắt bớt
    else {
      if ((fileName + '').length <= len) {
        return fileName;
      } else {
        return (value + '').substring(0, len) + '...';
      }
    }
  }
}
