import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputCheckBoxComponent } from './input-check-box.component';
import { NzCheckboxModule } from 'ng-zorro-antd';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NzCheckboxModule 
  ],
  exports:[
    InputCheckBoxComponent
  ],
  declarations: [InputCheckBoxComponent]
})
export class InputCheckBoxModule { }
