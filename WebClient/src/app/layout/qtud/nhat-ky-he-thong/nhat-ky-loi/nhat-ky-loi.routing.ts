import { NhatKyLoiComponent } from './nhat-ky-loi.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: NhatKyLoiComponent },
];

export const NhatKyLoiRoutes = RouterModule.forChild(routes);
