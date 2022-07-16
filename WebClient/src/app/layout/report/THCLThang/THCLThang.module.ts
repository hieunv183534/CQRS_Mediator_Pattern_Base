import { THCLThangRoutes } from './THCLThang.routing';
import { BaocaoViewDialogModule } from 'src/app/layout/cauhinh/baocao/baocao-view-dialog/baocao-view-dialog.module';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { THCLThangComponent } from './THCLThang.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BaocaoViewDialogModule,
    THCLThangRoutes
  ],
  declarations: [THCLThangComponent]
})
export class THCLThangModule { }
