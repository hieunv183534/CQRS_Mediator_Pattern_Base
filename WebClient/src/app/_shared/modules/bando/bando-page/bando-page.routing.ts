import { BandoPageComponent } from './bando-page.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: BandoPageComponent },
];

export const BandoPageRoutes = RouterModule.forChild(routes);
