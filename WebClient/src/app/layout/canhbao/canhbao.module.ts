import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CanhbaoComponent } from './canhbao.component';
import { CanhbaoRoutes } from './canhbao.routing';
@NgModule({
  imports: [
    CommonModule,
    CanhbaoRoutes
  ],
  declarations: [CanhbaoComponent]
})
export class CanhbaoModule { }
