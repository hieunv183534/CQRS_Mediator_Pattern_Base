import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputPasswordComponent } from './input-password.component';
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
    InputPasswordComponent
  ],
  declarations: [InputPasswordComponent]
})
export class InputPasswordModule { }
