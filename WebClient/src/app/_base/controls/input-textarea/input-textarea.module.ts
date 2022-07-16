import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextareaComponent } from './input-textarea.component';
import { FormsModule } from '@angular/forms';
import { NzInputModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzInputModule
  ],
  exports: [
    InputTextareaComponent
  ],
  declarations: [InputTextareaComponent]
})
export class InputTextareaModule { }
