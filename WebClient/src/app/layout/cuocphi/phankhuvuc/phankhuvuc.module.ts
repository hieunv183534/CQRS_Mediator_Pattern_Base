import { StepBuuCucComponent } from './stepbuucuc/stepbuucuc.component';
import { StepHuyenComponent } from './stephuyen/stephuyen.component';
import { StepTinhComponent } from './steptinh/steptinh.component';
import { PhanKhuVucComponent } from './phankhuvuc.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzTabsModule } from 'ng-zorro-antd/tabs';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule
  ],
  exports: [
    PhanKhuVucComponent
  ],
  declarations: [PhanKhuVucComponent, StepTinhComponent, StepHuyenComponent, StepBuuCucComponent]
})
export class PhanKhuVucModule { }
