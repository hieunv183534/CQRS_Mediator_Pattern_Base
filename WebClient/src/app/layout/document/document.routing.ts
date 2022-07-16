import { Routes, RouterModule } from '@angular/router';
import { DocumentComponent } from './document.component';

const routes: Routes = [
  {
    path: '', component: DocumentComponent, children: [
      { path: 'info', loadChildren: () => import('./info/info.module').then(x => x.InfoModule) },
      { path: 'get-started', loadChildren: () => import('./get-started/get-started.module').then(x => x.GetStartedModule) }
    ]
  },
];

export const DocumentRoutes = RouterModule.forChild(routes);
