import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DanhmucComponent } from './danhmuc.component';
import {DanhmucRoutes} from './danhmuc.routing';

@NgModule({
  imports: [
    CommonModule,
    DanhmucRoutes
  ],
  declarations: [DanhmucComponent]
})
export class DanhmucModule { }
