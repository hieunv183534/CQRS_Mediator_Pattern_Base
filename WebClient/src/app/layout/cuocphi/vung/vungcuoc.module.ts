import { VungDialogComponent } from './vung-dialog/vung-dialog.component';
import { VungComponent } from './vung.component';
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
    VungComponent
  ],
  declarations: [VungComponent, VungDialogComponent]
})
export class VungCuocModule { }
