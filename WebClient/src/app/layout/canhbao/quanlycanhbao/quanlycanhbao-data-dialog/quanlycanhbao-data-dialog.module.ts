import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanlycanhbaoDataDialogComponent } from './quanlycanhbao-data-dialog.component';
import { AreaPlaceModule } from './../../../../_shared/modules/area-place/area-place.module';
@NgModule({
  imports: [
    CommonModule,
    FormModule,
    AreaPlaceModule
  ],
  declarations: [QuanlycanhbaoDataDialogComponent],
  entryComponents: [QuanlycanhbaoDataDialogComponent],
  exports: [
    QuanlycanhbaoDataDialogComponent
  ]
})
export class QuanlycanhbaoDataDialogModule { }
