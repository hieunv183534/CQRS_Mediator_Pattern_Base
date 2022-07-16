import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SystemComponent} from './system-view/system.component';
import {AuthGuard} from 'src/app/shared/guards/guards.class';
// import {UserProfileComponent} from './user-profile/user-profile.component';



const routes: Routes = [
  { path: '', component: SystemComponent, canActivate: [AuthGuard]},
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SystemRoutingModule {}
