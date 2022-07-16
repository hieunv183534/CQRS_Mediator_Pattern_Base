import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthGuard} from 'src/app/shared/guards/guards.class';
import {EntityComponent} from "./view/entity.component";

const routes: Routes = [
  { path: '', component: EntityComponent, canActivate: [AuthGuard] }

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EntityRoutingModule {}
