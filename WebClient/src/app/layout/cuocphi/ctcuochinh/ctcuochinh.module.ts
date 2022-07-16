import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CtcuochinhComponent } from './ctcuochinh.component';
import { LienTinhDialogComponent } from './lientinh/lientinh-dialog/lientinh-dialog.component';
import { LienKhuVucDialogComponent } from './lienkhuvuc/lienkhuvuc-dialog/lienkhuvuc-dialog.component';
import { LienTinhComponent } from './lientinh/lientinh.component';
import { LienKhuVucComponent } from './lienkhuvuc/lienkhuvuc.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
@NgModule({
  imports: [
    CommonModule,
    NzTabsModule,
    FormModule
  ],
  declarations: [CtcuochinhComponent, LienKhuVucComponent, LienKhuVucDialogComponent, LienTinhComponent, LienTinhDialogComponent]
})
export class CtcuochinhModule { }
