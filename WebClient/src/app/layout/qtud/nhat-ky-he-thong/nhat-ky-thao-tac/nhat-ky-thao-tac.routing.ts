import { NhatKyThaoTacComponent } from './nhat-ky-thao-tac.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: NhatKyThaoTacComponent },
];

export const NhatKyThaoTacRoutes = RouterModule.forChild(routes);
