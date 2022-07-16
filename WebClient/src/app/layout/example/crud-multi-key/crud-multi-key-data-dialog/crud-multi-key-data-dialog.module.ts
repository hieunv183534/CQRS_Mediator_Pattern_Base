import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrudMultiKeyDataDialogComponent } from './crud-multi-key-data-dialog.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  declarations: [CrudMultiKeyDataDialogComponent],
  entryComponents: [CrudMultiKeyDataDialogComponent],
  exports: [CrudMultiKeyDataDialogComponent]
})
export class CrudMultiKeyDataDialogModule { }
