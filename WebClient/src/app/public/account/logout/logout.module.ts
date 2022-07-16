import { LogoutRoutes } from './logout.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoutComponent } from './logout.component';

@NgModule({
  imports: [
    CommonModule,
    LogoutRoutes
  ],
  declarations: [LogoutComponent]
})
export class LogoutModule { }
