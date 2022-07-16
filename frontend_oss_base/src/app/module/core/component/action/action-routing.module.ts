import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthGuard} from 'src/app/shared/guards/guards.class';
import { ActionComponent } from './view/action.component';

const routes: Routes = [
  { path: '', component: ActionComponent, canActivate: [AuthGuard] }

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ActionRoutingModule {}
