import { UploadFileComponent } from './upload-file.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: UploadFileComponent },
];

export const UploadFileRoutes = RouterModule.forChild(routes);
