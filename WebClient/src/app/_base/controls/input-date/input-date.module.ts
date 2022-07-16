import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputDateComponent } from './input-date.component';
import { FormsModule } from '@angular/forms';
import { NzDatePickerModule, NzIconModule, NzInputModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzDatePickerModule,
    NzIconModule,
    NzInputModule,
  ],
  exports:[
    InputDateComponent
  ],
  declarations: [InputDateComponent]
})
export class InputDateModule { }
