import { PrintBarcodeComponent } from './print-barcode.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: PrintBarcodeComponent },
];

export const PrintBarcodeRoutes = RouterModule.forChild(routes);
