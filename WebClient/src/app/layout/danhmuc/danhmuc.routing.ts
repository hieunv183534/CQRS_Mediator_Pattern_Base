import {Routes, RouterModule} from '@angular/router';
import {DanhmucComponent} from './danhmuc.component';

const routes: Routes = [
  {
    path: '', component: DanhmucComponent, children: [
      {path: 'ngay-nghi', loadChildren: () => import('./ngay-nghi/ngay-nghi.module').then(m => m.NgayNghiModule)},
      {path: 'cauhinh-mayin', loadChildren: () => import('./cauhinh-mayin/cauhinh-mayin.module').then(m => m.CauhinhMayinModule)},
      {path: 'file-taptrung', loadChildren: () => import('./file-taptrung/file-taptrung.module').then(m => m.FileTaptrungModule)}
    ]
  },
];

export const DanhmucRoutes = RouterModule.forChild(routes);
