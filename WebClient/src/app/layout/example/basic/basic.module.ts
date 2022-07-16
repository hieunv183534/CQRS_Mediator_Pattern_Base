import { DuongThuModule } from './../../../_shared/modules/duong-thu/duong-thu.module';
import { AreaPlaceModule } from './../../../_shared/modules/area-place/area-place.module';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasicComponent } from './basic.component';
import { BasicRoutes } from './basic.routing';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    AreaPlaceModule,
    DuongThuModule,
    BasicRoutes
  ],
  declarations: [BasicComponent]
})
export class BasicModule { }
