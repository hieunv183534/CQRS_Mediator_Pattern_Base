import { CrudMultiKeyDataDialogModule } from './crud-multi-key-data-dialog/crud-multi-key-data-dialog.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrudMultiKeyComponent } from './crud-multi-key.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { CrudMultiKeyRoutes } from './crud-multi-key.routing';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    CrudMultiKeyDataDialogModule,
    CrudMultiKeyRoutes
  ],
  declarations: [CrudMultiKeyComponent]
})
export class CrudMultiKeyModule { }
