import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextSearchComponent } from './input-text-search.component';
import { NzInputModule, NzIconModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    NzInputModule
  ],
  exports: [
    InputTextSearchComponent
  ],
  declarations: [InputTextSearchComponent]
})
export class InputTextSearchModule { }
