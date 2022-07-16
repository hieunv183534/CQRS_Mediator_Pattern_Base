import { PipeModule } from './../../pipe/pipe.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { RouterModule } from '@angular/router';
import { NzSpinModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    NzSpinModule,
    PipeModule,
    RouterModule
  ],
  exports: [
    MenuComponent
  ],
  declarations: [MenuComponent]
})
export class MenuModule { }
