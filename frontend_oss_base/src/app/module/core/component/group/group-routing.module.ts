import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {GroupViewComponent} from './group-view/group-view.component';
import {AuthGuard} from 'src/app/shared/guards/guards.class';

const routes: Routes = [
  { path: '', component: GroupViewComponent, canActivate: [AuthGuard] }

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupRoutingModule {}
