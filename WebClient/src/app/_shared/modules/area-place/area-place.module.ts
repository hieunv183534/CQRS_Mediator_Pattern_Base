import { FormModule } from './../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AreaPlaceComponent } from './area-place.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [AreaPlaceComponent],
  declarations: [AreaPlaceComponent]
})
export class AreaPlaceModule { }
