import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputDateWeekComponent } from './input-date-week.component';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzDatePickerModule
  ],
  exports:[
    InputDateWeekComponent
  ],
  declarations: [InputDateWeekComponent]
})
export class InputDateWeekModule { }
