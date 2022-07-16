import { Routes, RouterModule } from '@angular/router';
import { InfoComponent } from './info.component'

const routes: Routes = [
  { path:'', component: InfoComponent },
];

export const InfoRoutes = RouterModule.forChild(routes);
