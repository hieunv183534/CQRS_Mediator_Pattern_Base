import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputNumberComponent } from './input-number.component';
import { FormsModule } from '@angular/forms';
import { NzInputNumberModule, NzIconModule, NzInputModule } from 'ng-zorro-antd';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzInputNumberModule,
    TextMaskModule,
    NzIconModule,
    NzInputModule
  ],
  exports:[
    InputNumberComponent
  ],
  declarations: [InputNumberComponent]
})
export class InputNumberModule { }
