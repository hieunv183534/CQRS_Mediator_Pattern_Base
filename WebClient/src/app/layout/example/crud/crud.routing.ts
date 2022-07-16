import { CrudComponent } from './crud.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: CrudComponent },
];

export const CrudRoutes = RouterModule.forChild(routes);
