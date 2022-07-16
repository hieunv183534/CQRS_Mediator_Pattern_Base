import { TaiKhoanDataDialogModule } from './tai-khoan-data-dialog/tai-khoan-data-dialog.module';
import { TaiKhoanRoutes } from './tai-khoan.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaiKhoanComponent } from './tai-khoan.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    TaiKhoanDataDialogModule,
    TaiKhoanRoutes
  ],
  declarations: [TaiKhoanComponent]
})
export class TaiKhoanModule { }
