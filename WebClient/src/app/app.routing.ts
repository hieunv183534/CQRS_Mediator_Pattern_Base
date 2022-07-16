import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_shared/services/auth.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'public',
    loadChildren: () => import('./public/public.module').then(m => m.PublicModule)
  },
  {
    path: 'ban-do',
    loadChildren: () => import('./_shared/modules/bando/bando-page/bando-page.module').then(m => m.BandoPageModule)
  },
  {
    path: 'ban-do-dp',
    loadChildren: () => import('./_shared/modules/bandodp/bandodp-page/bandodp-page.module').then(m => m.BandodpPageModule)
  },
  {
    path: 'ban-do-buu-gui',
    loadChildren: () => import('./_shared/modules/bando-buugui/bando-buugui-page/bando-buugui-page.module').then(m => m.BandoBuuguiPageModule)
  },
  {
    path: 'ban-do-xe',
    loadChildren: () => import('./layout/home/dash-board-custom/dsb-trang-thai-xe/dsb-trang-thai-xe-map/dsb-trang-thai-xe-map.module').then(m => m.DsbTrangThaiXeMapModule)
  }
];

export const AppRoutes = RouterModule.forRoot(routes);
