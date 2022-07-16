import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleExampleBasicGetPagingQueryResult, ExampleBasicApi, ExampleExampleBasicGetPagingQuery } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-bar-code',
  templateUrl: './bar-code.component.html',
  styleUrls: ['./bar-code.component.scss']
})
export class BarCodeComponent implements OnInit {

  public formSearch: FormGroup;

  public listOfData: ExampleExampleBasicGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public barCodeViewUrl: string;
  public isLoadFirstIframe = true;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  public lstStatus: any[] = [
    { value: 1, text: 'Đang sử dụng' },
    { value: 2, text: 'Đã xóa' },
  ];

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private exampleBasicApi: ExampleBasicApi,
    private el: ElementRef<any> // Element comopent hien tai
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      name: ['']
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new ExampleExampleBasicGetPagingQuery({
      ...paging
    });

    if (formData.name) {
      where.and.push({ colText: { like: formData.name } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.exampleBasicApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async printBarcode(listItem: any[]): Promise<void> {
    if (listItem.length === 0) {
      this.messageService.notiMessageWarning('Bạn chưa chọn sản phẩm nào');
      return;
    }
    const result = await this.dialogService.confirm('', 'Bạn có cách chắn muốn in barcode các sản phẩm đã chọn không?');
    if (result) {
      const listCode = this.listOfData.filter(x => listItem.some(y => y === x.id)).map(x => x.id); // dang lay id lam ma barcode luon
      const urlNew = `/public/barcode?data=${JSON.stringify(listCode)}`;
      if (this.barCodeViewUrl === urlNew) {
        this.barCodeViewUrl = urlNew;
        (window as any).frames.barCodeViewPrint.print();
      } else {
        this.barCodeViewUrl = urlNew;
      }
    }
  }

  async printBarcodeLoading(): Promise<void> {
    if (!this.isLoadFirstIframe) {
      (window as any).frames.barCodeViewPrint.print();
    }
    this.isLoadFirstIframe = false;
  }

}
