import { Routes, RouterModule } from '@angular/router';
import { BaocaoComponent } from './baocao.component';
const routes: Routes = [
  { path: '', component: BaocaoComponent },
];

export const BaocaoRouters = RouterModule.forChild(routes);
