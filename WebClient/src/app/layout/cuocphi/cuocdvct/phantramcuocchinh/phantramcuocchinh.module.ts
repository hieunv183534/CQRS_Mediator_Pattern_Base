import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { PhantramcuocchinhComponent } from './phantramcuocchinh.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  declarations: [PhantramcuocchinhComponent]
})
export class PhantramcuocchinhModule { }
