import { NhatKyHeThongRoutes } from './nhat-ky-he-thong.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NhatKyHeThongComponent } from './nhat-ky-he-thong.component';

@NgModule({
  imports: [
    CommonModule,
    NhatKyHeThongRoutes
  ],
  declarations: [NhatKyHeThongComponent]
})
export class NhatKyHeThongModule { }
