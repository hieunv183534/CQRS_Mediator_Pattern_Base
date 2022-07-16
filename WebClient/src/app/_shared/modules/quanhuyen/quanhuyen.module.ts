import { FormModule } from './../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanHuyenComponent } from './quanhuyen.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [QuanHuyenComponent],
  declarations: [QuanHuyenComponent]
})
export class QuanHuyenModule { }
