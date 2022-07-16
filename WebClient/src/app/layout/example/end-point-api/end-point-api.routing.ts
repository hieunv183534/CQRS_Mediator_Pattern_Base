import { EndPointApiComponent } from './end-point-api.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path:'', component: EndPointApiComponent },
];

export const EndPointApiRoutes = RouterModule.forChild(routes);
