import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTimeComponent } from './input-time.component';
import { FormsModule } from '@angular/forms';
import { NzTimePickerModule } from 'ng-zorro-antd/time-picker';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzTimePickerModule
  ],
  exports:[
    InputTimeComponent
  ],
  declarations: [InputTimeComponent]
})
export class InputTimeModule { }
