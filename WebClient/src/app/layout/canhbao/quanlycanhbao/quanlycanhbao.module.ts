import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanlycanhbaoComponent } from './quanlycanhbao.component';
import { QuanlycanhbaoRoutes } from './quanlycanhbao.routing';
import { QuanlycanhbaoDataDialogModule } from './quanlycanhbao-data-dialog/quanlycanhbao-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,  
    QuanlycanhbaoDataDialogModule,
    QuanlycanhbaoRoutes,

  ],
  declarations: [QuanlycanhbaoComponent]
})
export class QuanlycanhbaoModule { }
