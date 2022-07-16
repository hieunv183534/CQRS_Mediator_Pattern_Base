import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzSelectModule, NzIconModule, NzSpinModule } from 'ng-zorro-antd';
import { InputSelectMultipleApiComponent } from './input-select-multiple-api.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    NzSpinModule,
    NzSelectModule
  ],
  exports: [
    InputSelectMultipleApiComponent
  ],
  declarations: [InputSelectMultipleApiComponent]
})
export class InputSelectMultipleApiModule { }
