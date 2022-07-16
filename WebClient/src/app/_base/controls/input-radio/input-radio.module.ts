import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputRadioComponent } from './input-radio.component';
import { FormsModule } from '@angular/forms';
import { NzRadioModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzRadioModule
  ],
  exports: [
    InputRadioComponent
  ],
  declarations: [InputRadioComponent]
})
export class InputRadioModule { }
