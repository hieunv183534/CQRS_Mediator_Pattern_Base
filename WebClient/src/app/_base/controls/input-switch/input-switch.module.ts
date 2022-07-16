import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputSwitchComponent } from './input-switch.component';
import { NzSwitchModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzSwitchModule
  ],
  exports: [
    InputSwitchComponent
  ],
  declarations: [InputSwitchComponent]
})
export class InputSwitchModule { }
