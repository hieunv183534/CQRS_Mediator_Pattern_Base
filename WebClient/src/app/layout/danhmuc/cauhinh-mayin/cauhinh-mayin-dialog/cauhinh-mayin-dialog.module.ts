import { DanhSachMayInComponent } from './danh-sach-may-in/danh-sach-may-in.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CauhinhMayinDialogComponent } from './cauhinh-mayin-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  declarations: [
    CauhinhMayinDialogComponent, 
    DanhSachMayInComponent
  ]
})
export class CauhinhMayinDialogModule { }
