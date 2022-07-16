import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingComponent } from './paging.component';
import { NzIconModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    NzIconModule
  ],
  providers: [PagingComponent],
  exports: [PagingComponent],
  declarations: [PagingComponent]
})
export class PagingModule { }
