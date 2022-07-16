import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EndPointApiComponent } from './end-point-api.component';
import { EndPointApiRoutes } from './end-point-api.routing';

@NgModule({
  imports: [
    CommonModule,
    EndPointApiRoutes
  ],
  declarations: [EndPointApiComponent]
})
export class EndPointApiModule { }
