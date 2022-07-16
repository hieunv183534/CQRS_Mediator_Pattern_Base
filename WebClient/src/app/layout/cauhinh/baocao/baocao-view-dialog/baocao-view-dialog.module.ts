import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaocaoViewDialogComponent } from './baocao-view-dialog.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports:[
    BaocaoViewDialogComponent
  ],
  declarations: [BaocaoViewDialogComponent]
})
export class BaocaoViewDialogModule { }
