import { Routes, RouterModule } from '@angular/router';
import { GetStartedComponent } from './get-started.component';

const routes: Routes = [
  { path:'', component: GetStartedComponent},
];

export const GetStartedRoutes = RouterModule.forChild(routes);
