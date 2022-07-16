import { Routes, RouterModule } from '@angular/router';
import { TaiKhoanComponent } from './tai-khoan.component';

const routes: Routes = [
  { path:'', component: TaiKhoanComponent },
];

export const TaiKhoanRoutes = RouterModule.forChild(routes);
