import { BieudoDatasetDialogComponent } from './bieudo-dataset-dialog/bieudo-dataset-dialog.component';
import { FormModule } from './../../../_base/controls/form/form.module';
import { BieudoDatasetRoutes } from './bieudo-dataset.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BieudoDatasetComponent } from './bieudo-dataset.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BieudoDatasetRoutes
  ],
  declarations: [
    BieudoDatasetComponent,
    BieudoDatasetDialogComponent]
})
export class BieudoDatasetModule { }
