import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputDateRangeComponent } from './input-date-range.component';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzDatePickerModule
  ],
  exports:[
    InputDateRangeComponent
  ],
  declarations: [InputDateRangeComponent]
})
export class InputDateRangeModule { }
