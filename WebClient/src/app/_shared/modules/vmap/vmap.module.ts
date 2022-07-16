import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VmapComponent } from './vmap.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BandoModule } from '../bando/bando.module';

@NgModule({
  imports: [
    CommonModule,
    BandoModule,
    FormModule
  ],
  exports:[
    VmapComponent
  ],
  declarations: [VmapComponent]
})
export class VmapModule { }
