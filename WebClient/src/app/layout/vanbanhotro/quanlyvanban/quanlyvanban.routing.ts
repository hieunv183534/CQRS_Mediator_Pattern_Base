import { QuanlyvanbanComponent } from './quanlyvanban.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: QuanlyvanbanComponent },
];

export const QuanlyvanbanRoutes = RouterModule.forChild(routes);
