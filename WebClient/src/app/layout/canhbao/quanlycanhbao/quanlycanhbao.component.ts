import { WarningApi,
  HoTroWarningGetPagingQuery,
  HoTroWarningGetPagingQueryResult
} from 'src/app/_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../_shared/services/user.service';
import { QuanlycanhbaoDataDialogComponent } from './quanlycanhbao-data-dialog/quanlycanhbao-data-dialog.component';
@Component({
 selector: 'app-quanlycanhbao',
 templateUrl: './quanlycanhbao.component.html',
 styleUrls: ['./quanlycanhbao.component.scss']
})
export class QuanlycanhbaoComponent implements OnInit {

 public formSearch: FormGroup;

 public isLoading = false;
 public paging: PagingModel = {
  page: 1,
  count: 100, 
  size: 10
 };
 public listOfData = [];

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
   private warningApi: WarningApi,
   private userService: UserService
 ) { }

 async ngOnInit(): Promise<void> {
   this.formSearch = this.fb.group({
     WarningContent: null,
     WarningType: null,
     fromDateCreated: null,
     toDateCreated: null
   });
   await this.getData();
 }

 async getData(paging: PagingModel = { order: { dateCreated: false } }): Promise<void> {
   const formData = this.formSearch.value;

   const where = { and: [] };
   const params = new  HoTroWarningGetPagingQuery({
     ...paging
   });
   debugger;
   if (formData.WarningContent) {
     where.and.push({ warningContent: { like: formData.WarningContent } });
   }
   if (formData.WarningType !==null) {
    where.and.push({ warningType: formData.WarningType });
   }
  
   if (formData.fromDateCreated) {
    params.dateFrom = formData.fromDateCreated;
   }

  if (formData.toDateCreated) {
    params.dateTo = formData.toDateCreated;
  }

   where.and.push({ pOSCode: this.userService.userInfo.postCode });
   // where loopback
   if (where.and.length > 0) {
     params.where = where;
   }
   this.isLoading = true;
   const rs = await this.warningApi.getPaging(params).toPromise();
   if (rs.success) {
     this.tableConfig.reset();
     this.listOfData = rs.result.data;
     this.paging = rs.result.paging;
   } else {
     this.messageService.notiMessageError(rs.error);
   }

   this.isLoading = false;
 }

 async showDataDialog(id: number): Promise<void> {
   const dialog = this.dialogService.openDialog(option => {
     option.title = 'Xem thông tin cảnh báo';
     option.size = DialogSize.medium;
     option.component = QuanlycanhbaoDataDialogComponent;
     option.inputs = {
       id: id,
       mode: DialogMode.view
     };
   }, (eventName) => {
     if (eventName === 'onClose') {
       this.dialogService.closeDialogById(dialog.id);
     }
   });
 } 
}
