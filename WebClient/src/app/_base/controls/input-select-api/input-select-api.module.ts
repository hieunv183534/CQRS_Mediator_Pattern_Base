import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputSelectApiComponent } from './input-select-api.component';
import { FormsModule } from '@angular/forms';
import { NzSelectModule, NzIconModule, NzSpinModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    NzSpinModule,
    NzSelectModule
  ],
  exports: [
    InputSelectApiComponent
  ],
  declarations: [InputSelectApiComponent]
})
export class InputSelectApiModule { }
