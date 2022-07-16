import { Routes, RouterModule } from '@angular/router';
import { NgayNghiComponent } from './ngay-nghi.component';

const routes: Routes = [
  { path: '', component: NgayNghiComponent },
];

export const NgayNghiRoutes = RouterModule.forChild(routes);
