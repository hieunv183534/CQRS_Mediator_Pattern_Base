import { BaocaoDataTestDialogModule } from './baocao-data-test-dialog/baocao-data-test-dialog.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BaocaoDataDialogComponent } from './baocao-data-dialog.component';
import { NzSpaceModule } from 'ng-zorro-antd/space';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzSpaceModule,
    BaocaoDataTestDialogModule
  ],
  exports:[
    BaocaoDataDialogComponent
  ],
  declarations: [BaocaoDataDialogComponent]
})
export class BaocaoDataDialogModule { }
