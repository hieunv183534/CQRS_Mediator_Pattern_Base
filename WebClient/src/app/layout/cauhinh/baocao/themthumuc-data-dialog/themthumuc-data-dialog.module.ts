import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { ThemthumucDataDialogComponent } from './themthumuc-data-dialog.component';
import { NzSpaceModule } from 'ng-zorro-antd/space';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzSpaceModule
  ],
  exports:[
    ThemthumucDataDialogComponent
  ],
  declarations: [ThemthumucDataDialogComponent]
})
export class ThemthumucDataDialogModule { }
