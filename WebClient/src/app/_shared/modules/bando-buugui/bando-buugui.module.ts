import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandoBuuguiComponent } from './bando-buugui.component';
import { PipeModule } from '../../pipe/pipe.module';

@NgModule({
  imports: [
    CommonModule,
    PipeModule
  ],
  exports:[
    BandoBuuguiComponent
  ],
  declarations: [BandoBuuguiComponent]
})
export class BandoBuuguiModule { }
