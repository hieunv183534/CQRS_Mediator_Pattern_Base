import { IconComponent } from './icon.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: IconComponent },
];

export const IconRoutes = RouterModule.forChild(routes);
