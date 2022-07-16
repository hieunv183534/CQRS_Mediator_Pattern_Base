import { BieudoDatasetComponent } from './bieudo-dataset.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: BieudoDatasetComponent },
];

export const BieudoDatasetRoutes = RouterModule.forChild(routes);
