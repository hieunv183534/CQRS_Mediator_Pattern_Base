import { IdentityAspNetUserGetPagingQuery, UserApi } from './../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';

@Component({
  selector: 'app-tai-khoan-select',
  templateUrl: './tai-khoan-select.component.html',
  styleUrls: ['./tai-khoan-select.component.scss']
})
export class TaiKhoanSelectComponent implements OnInit {

  @Input() itemSelected: any[];
  @Output() onSubmit = new EventEmitter<any>();
  @Output() onClose = new EventEmitter<any>();

  public formSearch: FormGroup;

  public listOfData: any[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private userApi: UserApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      userName: [''],
      fullName: ['']
    });
    if(this.itemSelected){
      for (const item of this.itemSelected) {
        this.tableConfig.itemSelected.add(item);
      }
    }
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { userName: true } }): Promise<void> {
    const formData = this.formSearch.value;

    const where = { and: [] };
    const params = new IdentityAspNetUserGetPagingQuery({
      ...paging
    });

    if (formData.userName) {
      where.and.push({ userName: { like: formData.userName } });
    }

    if (formData.fullName) {
      where.and.push({ fullName: { like: formData.fullName } });
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.userApi.getPaging(params).toPromise();
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

  async submitForm(): Promise<void> {
    const itemSelected = this.tableConfig.getItemSelectedArray();
    this.onSubmit.emit(itemSelected);
  }

}
