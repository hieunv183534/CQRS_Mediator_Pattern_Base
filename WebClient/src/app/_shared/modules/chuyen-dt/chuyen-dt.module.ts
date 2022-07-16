import { FormModule } from './../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChuyenDtComponent } from './chuyen-dt.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [ChuyenDtComponent],
  declarations: [ChuyenDtComponent]
})
export class ChuyenDtModule { }