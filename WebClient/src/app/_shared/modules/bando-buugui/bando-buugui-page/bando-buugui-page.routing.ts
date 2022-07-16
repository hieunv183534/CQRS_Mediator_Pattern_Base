import { Routes, RouterModule } from '@angular/router';
import { BandoBuuguiPageComponent } from './bando-buugui-page.component';

const routes: Routes = [
  { path:'', component: BandoBuuguiPageComponent },
];

export const BandoBuuguiPageRoutes = RouterModule.forChild(routes);
