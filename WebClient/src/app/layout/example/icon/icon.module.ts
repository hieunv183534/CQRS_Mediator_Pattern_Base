import { IconRoutes } from './icon.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconComponent } from './icon.component';

@NgModule({
  imports: [
    CommonModule,
    IconRoutes
  ],
  declarations: [IconComponent]
})
export class IconModule { }
