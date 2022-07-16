import { BandodpPageRoutes } from './bandodp-page.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandodpPageComponent } from './bandodp-page.component';

@NgModule({
  imports: [
    CommonModule,
    BandodpPageRoutes
  ],
  declarations: [BandodpPageComponent]
})
export class BandodpPageModule { }
