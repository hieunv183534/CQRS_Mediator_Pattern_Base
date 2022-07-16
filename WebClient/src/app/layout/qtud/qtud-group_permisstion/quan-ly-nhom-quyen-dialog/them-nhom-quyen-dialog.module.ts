import { TaiKhoanSelectModule } from './../../tai-khoan/tai-khoan-select/tai-khoan-select.module';
import { QuanLyNhomQuyenStep3Component } from './quan-ly-nhom-quyen-step3/quan-ly-nhom-quyen-step3.component';
import { QuanLyNhomQuyenStep2Component } from './quan-ly-nhom-quyen-step2/quan-ly-nhom-quyen-step2.component';
import { QuanLyNhomQuyenStep1Component } from './quan-ly-nhom-quyen-step1/quan-ly-nhom-quyen-step1.component';
import { FormModule } from '../../../../_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemNhomQuyenDialogComponent } from './them-nhom-quyen-dialog.component';
import { NzStepsModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    NzStepsModule,
    TaiKhoanSelectModule,
    FormModule
  ],
  declarations: [
    ThemNhomQuyenDialogComponent,
    QuanLyNhomQuyenStep1Component,
    QuanLyNhomQuyenStep2Component,
    QuanLyNhomQuyenStep3Component
  ],
  entryComponents: [ThemNhomQuyenDialogComponent],
  exports: [
    ThemNhomQuyenDialogComponent,
  ]
})
export class ThemNhomQuyenDialogModule { }
