import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CauhinhComponent } from './cauhinh.component';
import { CauhinhRoutes } from './cauhinh.routing';

@NgModule({
  imports: [
    CommonModule,
    CauhinhRoutes
  ],
  declarations: [CauhinhComponent]
})
export class CauhinhModule { }
