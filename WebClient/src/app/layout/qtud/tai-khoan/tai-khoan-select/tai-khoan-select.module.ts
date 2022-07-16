import { FormModule } from './../../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaiKhoanSelectComponent } from './tai-khoan-select.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports:[
    TaiKhoanSelectComponent
  ],
  declarations: [TaiKhoanSelectComponent]
})
export class TaiKhoanSelectModule { }
