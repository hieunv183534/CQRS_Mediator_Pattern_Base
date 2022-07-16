import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VanbanhotroComponent } from './vanbanhotro.component';
import { VanbanhotroRoutes } from './vanbanhotro.routing';
@NgModule({
  imports: [
    CommonModule,
    VanbanhotroRoutes
  ],
  declarations: [VanbanhotroComponent]
})
export class VanbanhotroModule { }
