import { Routes, RouterModule } from '@angular/router';
import { CauhinhMayinComponent } from './cauhinh-mayin.component';

const routes: Routes = [
  { path: '', component: CauhinhMayinComponent },
];

export const CauhinhMayinRoutes = RouterModule.forChild(routes);