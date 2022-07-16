import { BarCodeComponent } from './bar-code.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: BarCodeComponent },
];

export const BarCodeRoutes = RouterModule.forChild(routes);
