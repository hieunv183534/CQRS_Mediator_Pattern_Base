import { CuocVungModule } from './../cuoc-vung/cuoc-vung.module';
import { CuocChinhModule } from './../cuocchinh/cuocchinh.module';
import { CuocvungxaModule } from './../cuocvungxa/cuocvungxa.module';
import { HuyenComponent } from './../cuocvungxa/huyen/huyen.component';
import { XaComponent } from './../cuocvungxa/xa/xa.component';
//import { CauHinhVungModule } from './../cauhinhvung/cauhinhvung.module';
import { VungCuocModule } from './../vung/vungcuoc.module';
import { PhanKhuVucModule } from './../phankhuvuc/phankhuvuc.module';
import { KhuVucCuocModule } from '../khuvuc/khuvuccuoc.module';
import { CuocDvctModule } from '../cuocdvct/cuocdvct.module';
import { BangCuocDialogComponent } from './bangcuoc-dialog/bangcuoc-dialog.component';
import { BangCuocComponent } from './bangcuoc.component';
import { BangCuocRoutes } from './bangcuoc.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { QuanHuyenModule } from '../../../_shared/modules/quanhuyen/quanhuyen.module';
import { AreaPlaceModule } from './../../../_shared/modules/area-place/area-place.module';
@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    KhuVucCuocModule,
    PhanKhuVucModule,
    VungCuocModule,
    AreaPlaceModule,
    //CauHinhVungModule,
    CuocChinhModule,
    CuocvungxaModule,
    CuocVungModule,
    BangCuocRoutes,
    CuocDvctModule,
    QuanHuyenModule
  ],
  declarations: [BangCuocComponent, BangCuocDialogComponent,HuyenComponent,XaComponent]
})
export class BangCuocModule { }
