import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BieudoDataDialogComponent } from './bieudo-data-dialog.component';
import { ThongtincobanBieudoComponent } from './thongtincoban-bieudo/thongtincoban-bieudo.component';
import { PhanquyenBieudoComponent } from './phanquyen-bieudo/phanquyen-bieudo.component';
import { ThembuucucDataDialogModule } from './thembuucuc-data-dialog/thembuucuc-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    ThembuucucDataDialogModule
  ],
  declarations: [
    BieudoDataDialogComponent,
    ThongtincobanBieudoComponent,
    PhanquyenBieudoComponent
  ]
})
export class BieudoDataDialogModule { }
