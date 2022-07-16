import { CrudDataDialogModule } from './crud-data-dialog/crud-data-dialog.module';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { CrudRoutes } from './crud.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrudComponent } from './crud.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    CrudDataDialogModule,
    CrudRoutes
  ],
  declarations: [CrudComponent]
})
export class CrudModule { }
