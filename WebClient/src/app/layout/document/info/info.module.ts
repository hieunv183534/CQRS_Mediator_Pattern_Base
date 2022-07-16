import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './info.component';
import { InfoRoutes } from './info.routing';

@NgModule({
  imports: [
    CommonModule,
    InfoRoutes
  ],
  declarations: [InfoComponent]
})
export class InfoModule { }
