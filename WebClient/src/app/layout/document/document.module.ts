import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentComponent } from './document.component';
import { DocumentRoutes } from './document.routing'

@NgModule({
  imports: [
    CommonModule,
    DocumentRoutes
  ],
  declarations: [DocumentComponent]
})
export class DocumentModule { }
