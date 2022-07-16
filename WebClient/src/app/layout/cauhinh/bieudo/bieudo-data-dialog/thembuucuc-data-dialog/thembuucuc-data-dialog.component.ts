import { IdentityAspNetRoleGetPagingQuery, RoleApi } from 'src/app/_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MessageService } from '../../../../../_base/servicers/message.service';
import { DialogService } from '../../../../../_base/servicers/dialog.service';
import { DanhMucPOSGetPagingQuery, DanhMucPOSGetPagingQueryResult, POSApi } from '../../../../../_shared/bccp-api.services';
import { PagingModel } from '../../../../../_base/models/response-model';
import { TableConfigModel } from '../../../../../_base/models/table-config-model';


@Component({
  selector: 'app-thembuucuc-data-dialog',
  templateUrl: './thembuucuc-data-dialog.component.html',
  styleUrls: ['./thembuucuc-data-dialog.component.scss']
})
export class ThembuucucDataDialogComponent implements OnInit {

  // tslint:disable-next-line:no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line:no-input-rename
  @Input('selected') selected: any;
  // tslint:disable-next-line:no-input-rename
  @Input('listSelected') listSelected: any[];
  // tslint:disable-next-line:no-input-rename
  @Input('parentId') parentId: string;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrigin: string;
  public listPOSSelected: any[] = [];
  public setPOSSelected: Set<any> = new Set<any>();

  public listOfData: any[] = [];
  public paging: PagingModel = {
    count: 0
  };

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    private roleApi: RoleApi
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      posCode: [''],
      posName: [''],
    });
    //
    this.isLoading = true;
    if (this.selected) {
      this.tableConfig.itemSelected = this.selected;
    }
    if (this.listSelected) {
      this.listPOSSelected = this.listSelected;
    }
    this.isLoading = false;
    this.saveHistoryForm();
    this.getData();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrigin = JSON.stringify(this.myForm.value);
  }
  //
  async save(): Promise<void> {
    this.keepPos();
    this.onClose.emit(this.listPOSSelected);
  }

  async keepPos(): Promise<void> {

    const listAdd = [...this.tableConfig.itemSelected].filter(x => !this.setPOSSelected.has(x));
    const listRemove = [...this.setPOSSelected].filter(x => !this.tableConfig.itemSelected.has(x));

    // remove item
    this.listPOSSelected = this.listPOSSelected.filter(x => !listRemove.includes(x.id));

    // add item
    const itemAdd = this.listOfData.filter(x => listAdd.includes(x.id));
    this.listPOSSelected = [
      ...this.listPOSSelected,
      ...itemAdd
    ];

    this.setPOSSelected = new Set(this.tableConfig.getItemSelectedArray());
  }

  async getData(paging: PagingModel = {page: 1, size: 10}): Promise<void> {
    this.keepPos();
    // this.formSearch.textTrim();

    const formData = this.myForm.value;

    const where = { and: [] };
    const params = new IdentityAspNetRoleGetPagingQuery({
      ...paging
    });

    if (formData.posCode) {
      where.and.push({ id: { like: formData.posCode } });
    }

    if (formData.posName) {
      where.and.push({ name: { like: formData.posName } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.roleApi.getPaging(params).toPromise();
    if (rs.success) {
      // this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }
}
