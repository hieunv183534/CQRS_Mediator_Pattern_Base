import { Routes, RouterModule } from '@angular/router';
import {CanhbaoComponent } from './canhbao.component';
const routes: Routes = [
  { 
    path: '', component: CanhbaoComponent, children: [
      { path: 'quanlycanhbao', loadChildren: () => import('./quanlycanhbao/quanlycanhbao.module').then(x => x.QuanlycanhbaoModule) }   
    ]
   },
];

export const CanhbaoRoutes = RouterModule.forChild(routes);
