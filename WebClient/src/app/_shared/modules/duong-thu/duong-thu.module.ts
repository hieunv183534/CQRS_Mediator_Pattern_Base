import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DuongThuComponent } from './duong-thu.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [DuongThuComponent],
  declarations: [DuongThuComponent]
})
export class DuongThuModule { }
