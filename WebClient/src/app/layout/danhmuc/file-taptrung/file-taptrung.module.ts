import { FileTaptrungDialogModule } from './file-taptrung-dialog/file-taptrung-dialog.module';
import { FileTaptrungRoutes } from './file-taptrung.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileTaptrungComponent } from './file-taptrung.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { ThietBiDialogModule } from '../thiet-bi/thiet-bi-dialog/thiet-bi-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    ThietBiDialogModule,
    FileTaptrungDialogModule,
    FileTaptrungRoutes
  ],
  declarations: [FileTaptrungComponent]
})
export class FileTaptrungModule { }
