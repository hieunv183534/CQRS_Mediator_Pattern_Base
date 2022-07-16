import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'showCountPaging'
})
export class ShowCountPagingPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if(+value === 0){
      return `Không có bản ghi nào được tìm thấy`;
    }
    if(+value <= 100){
      return `Có ${value} kết quả được tìm thấy`;
    }
    return `Có hơn 100 kết quả được tìm thấy`;
  }

}
