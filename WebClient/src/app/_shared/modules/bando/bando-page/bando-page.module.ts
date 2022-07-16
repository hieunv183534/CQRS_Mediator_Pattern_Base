import { BandoPageRoutes } from './bando-page.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandoPageComponent } from './bando-page.component';

@NgModule({
  imports: [
    CommonModule,
    BandoPageRoutes
  ],
  declarations: [BandoPageComponent]
})
export class BandoPageModule { }
