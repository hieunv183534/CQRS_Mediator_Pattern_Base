import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExampleComponent } from './example.component';
import { ExampleRoutes } from './example.routing';

@NgModule({
  imports: [
    CommonModule,
    ExampleRoutes
  ],
  declarations: [ExampleComponent]
})
export class ExampleModule { }
