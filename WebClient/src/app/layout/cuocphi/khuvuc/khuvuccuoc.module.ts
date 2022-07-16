import { BuuCucComponent } from './buucuc/buucuc.component';
import { HuyenComponent } from './huyen/huyen.component';
import { KhuVucDialogComponent } from './khuvuc-dialog/khuvuc-dialog.component';
import { TinhComponent } from './tinh/tinh.component';
import { KhuVucCuocComponent } from './khuvuccuoc.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { QuanHuyenModule } from '../../../_shared/modules/quanhuyen/quanhuyen.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    QuanHuyenModule
  ],
  exports: [
    KhuVucCuocComponent
  ],
  declarations: [KhuVucCuocComponent, KhuVucDialogComponent, TinhComponent, HuyenComponent, BuuCucComponent]
})
export class KhuVucCuocModule { }
