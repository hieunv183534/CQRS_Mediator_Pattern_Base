import { AccountComponent } from './account.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: AccountComponent, children: [
      { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
      { path: 'logout', loadChildren: () => import('./logout/logout.module').then(m => m.LogoutModule) },
      { path: 'change-password', loadChildren: () => import('./change-password/change-password.module').then(m => m.ChangePasswordModule) }
    ]
  },
];

export const AccountRoutes = RouterModule.forChild(routes);
