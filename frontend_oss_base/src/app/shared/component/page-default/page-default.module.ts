import { NgModule} from '@angular/core';
import {PageDefaultComponent} from './page-default.component';
import {PageDefaultRoutingModule} from './page-default-routing.module';

@NgModule({
  declarations: [
   PageDefaultComponent
  ],
  imports: [
    PageDefaultRoutingModule,    
  ],
  providers: []

})
export class PageDefaultModule {

}
