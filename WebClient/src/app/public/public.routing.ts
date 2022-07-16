import { PublicComponent } from './public.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: PublicComponent, children: [
      { path: 'barcode', loadChildren: () => import('./print-barcode/print-barcode.module').then(m => m.PrintBarcodeModule) },
      { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
      { path: 'auth-callback', loadChildren: () => import('./auth-callback/auth-callback.module').then(m => m.AuthCallbackModule) }
    ]
  },
];

export const PublicRoutes = RouterModule.forChild(routes);
