import { ListCodeRoutes } from './list-code.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCodeComponent } from './list-code.component';

@NgModule({
  imports: [
    CommonModule,
    ListCodeRoutes
  ],
  declarations: [ListCodeComponent]
})
export class ListCodeModule { }
