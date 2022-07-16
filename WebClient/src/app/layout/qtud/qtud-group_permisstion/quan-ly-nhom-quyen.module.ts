import { ThemNhomQuyenDialogModule } from './quan-ly-nhom-quyen-dialog/them-nhom-quyen-dialog.module';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { QuanLyNhomQuyenRoutes } from './quan-ly-nhom-quyen.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanlynhomquyenComponent } from './quan-ly-nhom-quyen.component';

@NgModule({
  imports: [
    CommonModule,
    ThemNhomQuyenDialogModule,
    FormModule,
    QuanLyNhomQuyenRoutes
  ],
  declarations: [	QuanlynhomquyenComponent,
   ]
})
export class QuanLyPhanQuyenModule { }
