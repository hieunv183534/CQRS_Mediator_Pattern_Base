import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputMonthComponent } from './input-month.component';
import { FormsModule } from '@angular/forms';
import { NzDatePickerModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzDatePickerModule
  ],
  exports:[
    InputMonthComponent
  ],
  declarations: [InputMonthComponent]
})
export class InputMonthModule { }
