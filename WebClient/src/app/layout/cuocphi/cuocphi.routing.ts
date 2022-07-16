import { Routes, RouterModule } from '@angular/router';
import { CuocPhiComponent } from './cuocphi.component';

const routes: Routes = [
  { path: '', component: CuocPhiComponent, children: [
    {path: 'bangcuoc', loadChildren: () => import('./bangcuoc/bangcuoc.module').then(x => x.BangCuocModule)}
  ] },
];

export const CuocPhiRoutes = RouterModule.forChild(routes);
