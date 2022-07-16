import { Routes, RouterModule } from '@angular/router';
import { BasicComponent } from './basic.component'

const routes: Routes = [
  { path: '', component: BasicComponent },
];

export const BasicRoutes = RouterModule.forChild(routes);
