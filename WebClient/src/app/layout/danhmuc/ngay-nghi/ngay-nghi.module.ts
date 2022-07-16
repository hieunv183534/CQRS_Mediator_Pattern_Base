import { NgayNghiDataComponent } from './ngay-nghi-data/ngay-nghi-data.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgayNghiComponent } from './ngay-nghi.component';
import { NgayNghiRoutes } from './ngay-nghi.routing';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NgayNghiRoutes
  ],
  declarations: [
    NgayNghiComponent,
    NgayNghiDataComponent
  ]
})
export class NgayNghiModule { }
