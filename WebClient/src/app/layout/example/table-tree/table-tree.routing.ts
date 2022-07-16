import { TableTreeComponent } from './table-tree.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: TableTreeComponent },
];

export const TableTreeRoutes = RouterModule.forChild(routes);
