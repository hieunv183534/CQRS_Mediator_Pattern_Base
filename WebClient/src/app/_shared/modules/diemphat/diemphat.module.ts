import { FormModule } from './../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiemphatComponent } from './diemphat.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [DiemphatComponent],
  declarations: [DiemphatComponent]
})
export class DiemphatModule { }