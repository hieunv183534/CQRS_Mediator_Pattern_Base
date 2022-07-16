import { Routes, RouterModule } from '@angular/router';
import { BangCuocComponent } from './bangcuoc.component';

const routes: Routes = [
  {  path: '', component: BangCuocComponent},
];

export const BangCuocRoutes = RouterModule.forChild(routes);
