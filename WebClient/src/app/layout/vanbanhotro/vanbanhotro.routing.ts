import { Routes, RouterModule } from '@angular/router';
import { VanbanhotroComponent } from './vanbanhotro.component';
const routes: Routes = [
  { 
    path: '', component: VanbanhotroComponent, children: [
      { path: 'quanlyvanban', loadChildren: () => import('./quanlyvanban/quanlyvanban.module').then(x => x.QuanlyvanbanModule) }
    
    ]
   },
];

export const VanbanhotroRoutes = RouterModule.forChild(routes);
