import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { MotbuuguiComponent } from './motbuugui.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
  ],
  declarations: [MotbuuguiComponent]
})
export class MotbuuguiModule { }
