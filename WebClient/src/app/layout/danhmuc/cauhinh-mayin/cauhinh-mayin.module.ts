import { CauhinhMayinDialogModule } from './cauhinh-mayin-dialog/cauhinh-mayin-dialog.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CauhinhMayinComponent } from './cauhinh-mayin.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { ThietBiDialogModule } from '../thiet-bi/thiet-bi-dialog/thiet-bi-dialog.module';
import { CauhinhMayinRoutes } from './cauhinh-mayin.routing';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    ThietBiDialogModule,
    CauhinhMayinDialogModule,
    CauhinhMayinRoutes
  ],
  declarations: [CauhinhMayinComponent]
})
export class CauhinhMayinModule { }
