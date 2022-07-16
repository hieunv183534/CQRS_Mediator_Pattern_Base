import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrudDataDialogComponent } from './crud-data-dialog.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [
    CrudDataDialogComponent
  ],
  declarations: [CrudDataDialogComponent],
  entryComponents: [CrudDataDialogComponent]
})
export class CrudDataDialogModule { }
