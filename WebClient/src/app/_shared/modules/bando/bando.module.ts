import { NzIconModule } from 'ng-zorro-antd/icon';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandoComponent } from './bando.component';
import { PipeModule } from '../../pipe/pipe.module';

@NgModule({
  imports: [
    CommonModule,
    NzIconModule,
    PipeModule
  ],
  exports:[
    BandoComponent
  ],
  declarations: [BandoComponent]
})
export class BandoModule { }
