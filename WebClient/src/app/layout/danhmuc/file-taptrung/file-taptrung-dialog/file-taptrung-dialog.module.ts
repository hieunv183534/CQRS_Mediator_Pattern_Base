import { FormModule } from './../../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileTaptrungDialogComponent } from './file-taptrung-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  declarations: [FileTaptrungDialogComponent]
})
export class FileTaptrungDialogModule { }
