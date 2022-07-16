import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserComponent} from './user-view/user.component';
import {AuthGuard} from 'src/app/shared/guards/guards.class';
// import {UserProfileComponent} from './user-profile/user-profile.component';



const routes: Routes = [
  { path: '', component: UserComponent, canActivate: [AuthGuard]},
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule {}
