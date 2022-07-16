import { AuthCallbackRoutes } from './auth-callback.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthCallbackComponent } from './auth-callback.component';

@NgModule({
  imports: [
    CommonModule,
    AuthCallbackRoutes
  ],
  declarations: [AuthCallbackComponent]
})
export class AuthCallbackModule { }
