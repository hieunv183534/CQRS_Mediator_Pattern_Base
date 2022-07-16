import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetStartedComponent } from './get-started.component';
import { GetStartedRoutes } from './get-started.routing';

@NgModule({
  imports: [
    CommonModule,
    GetStartedRoutes
  ],
  declarations: [GetStartedComponent]
})
export class GetStartedModule { }
