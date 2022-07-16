import { Routes, RouterModule } from '@angular/router';
import { CrudMultiKeyComponent } from './crud-multi-key.component';

const routes: Routes = [
  { path: '', component: CrudMultiKeyComponent },
];

export const CrudMultiKeyRoutes = RouterModule.forChild(routes);
