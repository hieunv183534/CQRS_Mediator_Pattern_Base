import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandodpComponent } from './bandodp.component';
import { PipeModule } from '../../pipe/pipe.module';

@NgModule({
  imports: [
    CommonModule,
    PipeModule
  ],
  exports:[
    BandodpComponent
  ],
  declarations: [BandodpComponent]
})
export class BandodpModule { }
