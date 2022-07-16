import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountComponent } from './account.component';
import { AccountRoutes } from './account.routing';

@NgModule({
  imports: [
    CommonModule,
    AccountRoutes
  ],
  declarations: [AccountComponent]
})
export class AccountModule { }
