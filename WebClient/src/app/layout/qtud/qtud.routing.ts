import { Routes, RouterModule } from '@angular/router';
import { QtudComponent } from './qtud.component';

/* const newLocal = './qtud-group_permisstion/quan-ly-phan-quyen.module'; */
const routes: Routes = [
  {
    path: '', component: QtudComponent, children: [
      { path: 'menu', loadChildren: () => import('./dim-menu/dim-menu.module').then(x => x.DimMenuModule) },
      { path: 'quan-tri-nguoi-dung/nhom-quyen', loadChildren: () => import('./qtud-group_permisstion/quan-ly-nhom-quyen.module').then(x => x.QuanLyPhanQuyenModule) },
      { path: 'quan-tri-nguoi-dung/tai-khoan', loadChildren: () => import('./tai-khoan/tai-khoan.module').then(x => x.TaiKhoanModule) },
      { path: 'nhat-ky-he-thong', loadChildren: () => import('./nhat-ky-he-thong/nhat-ky-he-thong.module').then(x => x.NhatKyHeThongModule) }
    ]
  },
];

export const QtudRoutes = RouterModule.forChild(routes);
