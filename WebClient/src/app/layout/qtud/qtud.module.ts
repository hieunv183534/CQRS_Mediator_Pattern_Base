import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QtudComponent } from './qtud.component';
import { QtudRoutes } from './qtud.routing';

@NgModule({
  imports: [
    CommonModule,
    QtudRoutes
  ],
  declarations: [QtudComponent]
})
export class QtudModule { }
