import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaocaoDataTestDialogComponent } from './baocao-data-test-dialog.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BaocaoViewDialogModule } from 'src/app/layout/cauhinh/baocao/baocao-view-dialog/baocao-view-dialog.module'

@NgModule({
  imports: [
    CommonModule,
    BaocaoViewDialogModule,
    FormModule
  ],
  exports:[
    BaocaoDataTestDialogComponent
  ],
  declarations: [BaocaoDataTestDialogComponent]
})
export class BaocaoDataTestDialogModule { }
