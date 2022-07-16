import { AuthCallbackComponent } from './auth-callback.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: AuthCallbackComponent },
];

export const AuthCallbackRoutes = RouterModule.forChild(routes);
