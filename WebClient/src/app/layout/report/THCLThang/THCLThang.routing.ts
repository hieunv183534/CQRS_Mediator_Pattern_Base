import { Routes, RouterModule } from '@angular/router';
import { THCLThangComponent } from './THCLThang.component';

const routes: Routes = [
  { path: '', component: THCLThangComponent },
];

export const THCLThangRoutes = RouterModule.forChild(routes);

