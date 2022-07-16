import { NhatKyThaoTacRoutes } from './nhat-ky-thao-tac.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NhatKyThaoTacComponent } from './nhat-ky-thao-tac.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NhatKyThaoTacRoutes
  ],
  declarations: [NhatKyThaoTacComponent]
})
export class NhatKyThaoTacModule { }
