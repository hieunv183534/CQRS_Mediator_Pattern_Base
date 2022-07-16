import { CuocChinhDialogComponent } from './cuocchinh-dialog/cuocchinh-dialog.component';
import { CtcuochinhModule } from './../ctcuochinh/ctcuochinh.module';
import { CuocChinhComponent } from './cuocchinh.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzTabsModule } from 'ng-zorro-antd/tabs';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    CtcuochinhModule
  ],
  exports: [
    CuocChinhComponent
  ],
  declarations: [CuocChinhComponent, CuocChinhDialogComponent]
})
export class CuocChinhModule { }
 