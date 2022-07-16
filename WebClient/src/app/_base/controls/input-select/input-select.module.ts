import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputSelectComponent } from './input-select.component';
import { FormsModule } from '@angular/forms';
import { NzSelectModule, NzIconModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    NzSelectModule
  ],
  exports: [
    InputSelectComponent
  ],
  declarations: [InputSelectComponent]
})
export class InputSelectModule { }
