import { FormModule } from './../../../_base/controls/form/form.module';
import { BarCodeRoutes } from './bar-code.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarCodeComponent } from './bar-code.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BarCodeRoutes
  ],
  declarations: [
    BarCodeComponent
  ]
})
export class BarCodeModule { }
