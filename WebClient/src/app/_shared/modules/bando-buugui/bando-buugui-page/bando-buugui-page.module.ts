import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BandoBuuguiPageComponent } from './bando-buugui-page.component';
import { BandoBuuguiPageRoutes } from './bando-buugui-page.routing';

@NgModule({
  imports: [
    CommonModule,
    BandoBuuguiPageRoutes
  ],
  declarations: [BandoBuuguiPageComponent]
})
export class BandoBuuguiPageModule { }
