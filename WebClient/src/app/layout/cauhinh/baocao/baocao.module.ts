import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BaocaoDataDialogModule } from './baocao-data-dialog/baocao-data-dialog.module';
import { BaocaoComponent } from './baocao.component';
import { BaocaoRouters } from './baocao.routing';
import { ThemthumucDataDialogModule } from './themthumuc-data-dialog/themthumuc-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BaocaoDataDialogModule,
    ThemthumucDataDialogModule,
    BaocaoRouters
  ],
  declarations: [BaocaoComponent]
})
export class BaocaoModule { }
