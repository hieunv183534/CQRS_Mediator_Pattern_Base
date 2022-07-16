import { Routes, RouterModule } from '@angular/router';
import { BieudoComponent } from './bieudo.component';
const routes: Routes = [
  { path: '', component: BieudoComponent },
];

export const BieudoRouters = RouterModule.forChild(routes);
