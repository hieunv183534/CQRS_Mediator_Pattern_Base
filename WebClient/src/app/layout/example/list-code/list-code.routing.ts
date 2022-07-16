import { ListCodeComponent } from './list-code.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: ListCodeComponent },
];

export const ListCodeRoutes = RouterModule.forChild(routes);
