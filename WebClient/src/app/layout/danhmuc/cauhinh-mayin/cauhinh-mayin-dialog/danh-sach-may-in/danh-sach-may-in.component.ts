import { PrinterService } from './../../../../../_shared/services/printer.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-danh-sach-may-in',
  templateUrl: './danh-sach-may-in.component.html',
  styleUrls: ['./danh-sach-may-in.component.scss']
})
export class DanhSachMayInComponent implements OnInit {

  @Output() onClose = new EventEmitter<any>();
  @Output() onSave = new EventEmitter<any>();
  public listOfData: any[] = [];
  public isLoading = false;

  constructor(private printerService: PrinterService) { }

  async ngOnInit() {
    this.isLoading = true;
    const rs = await this.printerService.getPrinters();
    this.listOfData = rs;
    this.isLoading = false;
  }

  saveData(value: any){
    this.onSave.emit(value);
  }
}
