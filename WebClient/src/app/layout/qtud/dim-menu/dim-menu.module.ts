import { FormModule } from 'src/app/_base/controls/form/form.module';
import { DimMenuDataDialogModule } from './dim-menu-data-dialog/dim-menu-data-dialog.module';
import { DimMenuRoutes } from './dim-menu.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DimMenuComponent } from './dim-menu.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    DimMenuDataDialogModule,
    DimMenuRoutes
  ],
  declarations: [DimMenuComponent]
})
export class DimMenuModule { }
