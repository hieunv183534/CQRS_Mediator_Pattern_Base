import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaiKhoanDataDialogComponent } from './tai-khoan-data-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports:[
    TaiKhoanDataDialogComponent
  ],
  declarations: [TaiKhoanDataDialogComponent]
})
export class TaiKhoanDataDialogModule { }
