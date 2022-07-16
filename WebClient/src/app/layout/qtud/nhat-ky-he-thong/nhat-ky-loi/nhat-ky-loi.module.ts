import { NhatKyLoiRoutes } from './nhat-ky-loi.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NhatKyLoiComponent } from './nhat-ky-loi.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NhatKyLoiRoutes
  ],
  declarations: [NhatKyLoiComponent]
})
export class NhatKyLoiModule { }
