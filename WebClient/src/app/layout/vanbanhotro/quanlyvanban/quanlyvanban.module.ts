import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuanlyvanbanComponent } from './quanlyvanban.component';
import { QuanlyvanbanRoutes } from './quanlyvanban.routing';
import { QuanlyvanbanDataDialogModule } from './quanlyvanban-data-dialog/quanlyvanban-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,  
    QuanlyvanbanDataDialogModule,
    QuanlyvanbanRoutes,

  ],
  declarations: [QuanlyvanbanComponent]
})
export class QuanlyvanbanModule { }
