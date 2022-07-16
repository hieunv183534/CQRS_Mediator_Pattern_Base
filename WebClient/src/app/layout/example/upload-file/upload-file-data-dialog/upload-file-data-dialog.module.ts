import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UploadFileDataDialogComponent } from './upload-file-data-dialog.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports:[
    UploadFileDataDialogComponent
  ],
  declarations: [UploadFileDataDialogComponent]
})
export class UploadFileDataDialogModule { }
