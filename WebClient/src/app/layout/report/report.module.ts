import { FormModule } from 'src/app/_base/controls/form/form.module';
import { BaocaoViewDialogModule } from 'src/app/layout/cauhinh/baocao/baocao-view-dialog/baocao-view-dialog.module';
import { ReportRoutes } from './report.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportComponent } from './report.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    BaocaoViewDialogModule,
    ReportRoutes
  ],
  declarations: [ReportComponent]
})
export class ReportModule { }
