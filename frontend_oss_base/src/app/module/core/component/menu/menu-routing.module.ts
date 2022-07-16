import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ViewMenuComponent} from './view-menu/view-menu.component';
import {AuthGuard} from 'src/app/shared/guards/guards.class';

const routes: Routes = [
  { path: '', 
  component: ViewMenuComponent , 
  canActivate: [AuthGuard]
}

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MenuRoutingModule {}
