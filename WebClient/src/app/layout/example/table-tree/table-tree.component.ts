import { ProvinceApi, ExampleBasicApi } from './../../../_shared/bccp-api.services';
import { TableTreeConfigModel } from './../../../_base/models/table-tree-config-model';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { PagingResult } from 'src/app/_base/results/paing-result';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { CrudDataDialogComponent } from '../crud/crud-data-dialog/crud-data-dialog.component';

@Component({
  selector: 'app-table-tree',
  templateUrl: './table-tree.component.html',
  styleUrls: ['./table-tree.component.scss']
})
export class TableTreeComponent implements OnInit {

  public myForm: FormGroup;

  public listOfData: any[] = [];
  public isLoading = false;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public tableTreeConfig: TableTreeConfigModel = new TableTreeConfigModel({
    keyId: 'id',
    keyParentId: 'parentId',
    collapseDefault: false,
    mapOfExpandedData: {}
  });
  public checked = false;
  public loading = false;

  public lstStatus: any[] = [
    { value: 1, text: 'Đang sử dụng' },
    { value: 2, text: 'Đã xóa' },
  ];

  constructor(
    private dialogService: DialogService,
    private messageService: MessageService,
    private fb: FormBuilder,
    private religionService: ProvinceApi,
    private exampleService: ExampleBasicApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      keySearch: ['']
    });
    await this.getData();
  }

  async getData(): Promise<void> {
    this.isLoading = true;
    // const rs = await this.exampleService.getTree<any>();
    // if (rs.ok) {
    //   this.tableConfig.reset();
    //   this.listOfData = this.tableTreeConfig.convertDataRawToDataTree(rs.result);
    // }

    this.isLoading = false;
  }
}
