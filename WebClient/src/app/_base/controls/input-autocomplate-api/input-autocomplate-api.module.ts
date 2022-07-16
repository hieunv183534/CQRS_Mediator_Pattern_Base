import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzIconModule, NzInputModule, NzAutocompleteModule } from 'ng-zorro-antd';
import { InputAutocomplateApiComponent } from './input-autocomplate-api.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzIconModule,
    NzInputModule,
    NzAutocompleteModule
  ],
  exports: [
    InputAutocomplateApiComponent
  ],
  declarations: [InputAutocomplateApiComponent]
})
export class InputAutocomplateApiModule { }
