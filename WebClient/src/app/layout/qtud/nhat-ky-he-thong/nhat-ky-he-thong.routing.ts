import { NhatKyHeThongComponent } from './nhat-ky-he-thong.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: NhatKyHeThongComponent, children:[
    { path: 'nhat-ky-thao-tac', loadChildren: () => import('./nhat-ky-thao-tac/nhat-ky-thao-tac.module').then(x=>x.NhatKyThaoTacModule)},
    { path: 'nhat-ky-loi', loadChildren: () => import('./nhat-ky-loi/nhat-ky-loi.module').then(x=>x.NhatKyLoiModule)}
  ] },
];

export const NhatKyHeThongRoutes = RouterModule.forChild(routes);
