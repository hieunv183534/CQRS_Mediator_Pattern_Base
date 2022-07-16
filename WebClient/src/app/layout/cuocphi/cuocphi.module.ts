import { CuocChinhModule } from './cuocchinh/cuocchinh.module';
//import { CauHinhVungModule } from './cauhinhvung/cauhinhvung.module';
import { VungCuocModule } from './vung/vungcuoc.module';
import { KhuVucCuocModule } from './khuvuc/khuvuccuoc.module';
import { PhanKhuVucModule } from './phankhuvuc/phankhuvuc.module';
import { BangCuocModule } from './bangcuoc/bangcuoc.module';
import { CuocPhiRoutes } from './cuocphi.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CuocPhiComponent } from './cuocphi.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzTabsModule } from 'ng-zorro-antd/tabs';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    BangCuocModule,
    CuocPhiRoutes
  ],
  declarations: [CuocPhiComponent]
})
export class CuocPhiModule { }
