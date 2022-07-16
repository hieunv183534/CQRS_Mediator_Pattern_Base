import { ActionEndpointComponent } from './action-endpoint/action-endpoint.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DimMenuDataDialogComponent } from './dim-menu-data-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FormModule
  ],
  exports: [
    DimMenuDataDialogComponent
  ],
  entryComponents: [DimMenuDataDialogComponent],
  declarations: [
    DimMenuDataDialogComponent,
    ActionEndpointComponent
  ]
})
export class DimMenuDataDialogModule { }
