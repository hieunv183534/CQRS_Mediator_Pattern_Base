import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RenderErrorsComponent } from './render-errors.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [RenderErrorsComponent],
  declarations: [RenderErrorsComponent]
})
export class RenderErrorsModule { }
