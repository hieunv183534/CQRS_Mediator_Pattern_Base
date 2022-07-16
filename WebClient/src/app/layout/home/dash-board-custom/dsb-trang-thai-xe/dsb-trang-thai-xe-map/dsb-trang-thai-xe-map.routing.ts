import { DsbTrangThaiXeMapComponent } from './dsb-trang-thai-xe-map.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: DsbTrangThaiXeMapComponent },
];

export const DsbTrangThaiXeMapRoutes = RouterModule.forChild(routes);
