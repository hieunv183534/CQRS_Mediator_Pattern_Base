import { BandodpPageComponent } from './bandodp-page.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: BandodpPageComponent },
];

export const BandodpPageRoutes = RouterModule.forChild(routes);
