import { ChangePasswordRoutes } from './change-password.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangePasswordComponent } from './change-password.component';
import { FormModule } from 'src/app/_base/controls/form/form.module';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    ChangePasswordRoutes
  ],
  declarations: [ChangePasswordComponent]
})
export class ChangePasswordModule { }
