import { Routes, RouterModule } from '@angular/router';
import { FileTaptrungComponent } from './file-taptrung.component';

const routes: Routes = [
  { path: '', component: FileTaptrungComponent },
];

export const FileTaptrungRoutes = RouterModule.forChild(routes);
