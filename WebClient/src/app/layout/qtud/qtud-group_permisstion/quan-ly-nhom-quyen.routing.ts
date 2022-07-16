import { Routes, RouterModule } from '@angular/router';
import { QuanlynhomquyenComponent } from './quan-ly-nhom-quyen.component';

const routes: Routes = [
  { path: '', component: QuanlynhomquyenComponent },
];

export const QuanLyNhomQuyenRoutes = RouterModule.forChild(routes);
