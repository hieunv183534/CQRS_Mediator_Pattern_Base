import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-print-barcode',
  templateUrl: './print-barcode.component.html',
  styleUrls: ['./print-barcode.component.scss']
})
export class PrintBarcodeComponent implements OnInit {

  public listItem: any[] = [];

  constructor(
    private rtla: ActivatedRoute
  ) { }

  async ngOnInit(): Promise<void> {
    const listData = this.rtla.snapshot.queryParams;
    if (listData.data) {
      try {
        this.listItem = JSON.parse(listData.data);
      } catch (error) {

      }
    }
  }

}
