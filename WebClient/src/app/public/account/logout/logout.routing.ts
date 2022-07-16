import { Routes, RouterModule } from '@angular/router';
import { LogoutComponent } from './logout.component';

const routes: Routes = [
  { path: '', component: LogoutComponent },
];

export const LogoutRoutes = RouterModule.forChild(routes);
