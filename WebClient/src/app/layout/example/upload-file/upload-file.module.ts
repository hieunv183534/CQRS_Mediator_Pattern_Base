import { UploadFileDataDialogModule } from './upload-file-data-dialog/upload-file-data-dialog.module';
import { UploadFileRoutes } from './upload-file.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UploadFileComponent } from './upload-file.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { CrudDataDialogModule } from '../crud/crud-data-dialog/crud-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    CrudDataDialogModule,
    UploadFileDataDialogModule,
    UploadFileRoutes
  ],
  declarations: [UploadFileComponent]
})
export class UploadFileModule { }
