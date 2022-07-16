import { RouterModule, Routes } from '@angular/router';
import { CauhinhComponent } from './cauhinh.component';

const routes: Routes = [
  {
    path: '', component: CauhinhComponent, children: [
      { path: 'baocao', loadChildren: () => import('./baocao/baocao.module').then(m => m.BaocaoModule) },
      { path: 'bieudo', loadChildren: () => import('./bieudo/bieudo.module').then(m => m.BieudoModule) },
      { path: 'dulieu-bieudo', loadChildren: () => import('./bieudo-dataset/bieudo-dataset.module').then(m => m.BieudoDatasetModule) }
    ]
  },
];

export const CauhinhRoutes = RouterModule.forChild(routes);
