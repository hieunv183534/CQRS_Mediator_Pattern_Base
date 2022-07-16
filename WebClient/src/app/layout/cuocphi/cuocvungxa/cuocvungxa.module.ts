
import { CuocvungxaDialogComponent } from './cuocvungxa-dialog/cuocvungxa-dialog.component';
import { CuocvungxaComponent } from './cuocvungxa.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { QuanHuyenModule } from '../../../_shared/modules/quanhuyen/quanhuyen.module';
@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTabsModule,
    QuanHuyenModule
  ],
  exports: [
    CuocvungxaComponent
  ],
  declarations: [CuocvungxaComponent,
    CuocvungxaDialogComponent]
})
export class CuocvungxaModule { }
