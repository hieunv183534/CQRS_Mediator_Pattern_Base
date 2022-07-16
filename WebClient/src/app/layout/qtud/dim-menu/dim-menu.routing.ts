import { DimMenuComponent } from './dim-menu.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: DimMenuComponent },
];

export const DimMenuRoutes = RouterModule.forChild(routes);
