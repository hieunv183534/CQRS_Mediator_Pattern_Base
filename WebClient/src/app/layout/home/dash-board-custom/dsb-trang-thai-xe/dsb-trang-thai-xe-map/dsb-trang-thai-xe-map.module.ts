import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DsbTrangThaiXeMapComponent } from './dsb-trang-thai-xe-map.component';
import { DsbTrangThaiXeMapRoutes } from './dsb-trang-thai-xe-map.routing';

@NgModule({
  imports: [
    CommonModule,
    DsbTrangThaiXeMapRoutes
  ],
  declarations: [DsbTrangThaiXeMapComponent]
})
export class DsbTrangThaiXeMapModule { }
