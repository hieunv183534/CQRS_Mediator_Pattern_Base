import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BieudoDataDialogModule } from './bieudo-data-dialog/bieudo-data-dialog.module';
import { BieudoComponent } from './bieudo.component';
import { BieudoRouters } from './bieudo.routing';
import { DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BieudoRouters,
    BieudoDataDialogModule,
    DragDropModule
  ],
  declarations: [BieudoComponent]
})
export class BieudoModule { }
