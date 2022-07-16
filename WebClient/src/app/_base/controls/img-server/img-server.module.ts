import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImgServerComponent } from './img-server.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports:[
    ImgServerComponent
  ],
  declarations: [ImgServerComponent]
})
export class ImgServerModule { }
