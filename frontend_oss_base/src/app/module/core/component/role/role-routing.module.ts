import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RoleComponent} from './role-view/role.component';
import {AuthGuard} from 'src/app/shared/guards/guards.class';

const routes: Routes = [
  { path: '', component: RoleComponent , canActivate: [AuthGuard]}

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule {}
