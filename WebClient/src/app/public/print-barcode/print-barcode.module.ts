import { PrintBarcodeRoutes } from './print-barcode.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrintBarcodeComponent } from './print-barcode.component';
import { NgxBarcodeModule } from 'ngx-barcode';

@NgModule({
  imports: [
    CommonModule,
    NgxBarcodeModule, // Import lib barcode
    PrintBarcodeRoutes
  ],
  declarations: [PrintBarcodeComponent]
})
export class PrintBarcodeModule { }
