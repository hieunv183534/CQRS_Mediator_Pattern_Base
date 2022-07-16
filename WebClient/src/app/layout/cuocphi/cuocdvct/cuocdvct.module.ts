import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { MotbuuguiModule } from './motbuugui/motbuugui.module';
import { PhantramcuocchinhModule } from './phantramcuocchinh/phantramcuocchinh.module';
import { CuocDvctComponent } from './cuocdvct.component';
@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    MotbuuguiModule,
    PhantramcuocchinhModule
  ],
  exports: [
    CuocDvctComponent
  ],
  declarations: [CuocDvctComponent]
})
export class CuocDvctModule { }
