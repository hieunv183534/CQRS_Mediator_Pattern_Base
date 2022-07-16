import { ChangePasswordComponent } from './change-password.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: ChangePasswordComponent },
];

export const ChangePasswordRoutes = RouterModule.forChild(routes);
