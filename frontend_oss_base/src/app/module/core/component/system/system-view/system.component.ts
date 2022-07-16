import {Component, OnDestroy, OnInit} from '@angular/core';
import {System} from '../../../model/system.class';
import {FormBuilder} from '@angular/forms';
import {Constant} from 'src/app/shared/constants/constant.class';
import {TranslateService} from '@ngx-translate/core';
import {Subscription} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import { MessageService } from 'primeng/api';
import {ConfirmationService} from 'primeng/api';
import { SystemService } from '../../../service/system-service';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',  
  // styleUrls: ['src/app/shared/style/tablebasic.scss'],  
  providers: [MessageService, ConfirmationService, SystemService]
})

export class SystemComponent 
// extends TableSelectionAbstract 
implements OnInit, OnDestroy {
  public readonly DOWNLOAD_REPORT_URL = UrlConstant.DETAIL_USER + UrlConstant.REPORT_USER;
  public readonly REPORT_NAME = Constant.REPORT_NAME;

  systems: System [] = [];
  selectedSystems: System [] = [];
  cols: any[];
  loading = false;
  total: number;

  isVisible = false;
  isVisibleAdd = false;  
  data: any;
  sub: Subscription;
  system: System;
  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;  
  
  // Phân quyền  
  statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];
  // End Phân quyền

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private systemService: SystemService,
    private fb: FormBuilder,        
    public translate: TranslateService    
  ) {    
    
  }

  ngOnInit(): void {
    this.getListPermission();    
    this.searchData();    
    this.cols = [
      { field: 'code', header: 'Code' },
      { field: 'name', header: 'Name' },
      { field: 'description', header: 'Description' }
    ];
  }

  async getListPermission() {
    let arrayPermission: any;
    /* await this.actionServices.getActionByScreen(Constant.SCREEN.USER).then(value => {
      arrayPermission = value;
      this.listPermission = new Set(arrayPermission);
    });
    this.checkAdd = this.listPermission.has(Constant.ACTION2.ADD);
    this.checkDelete = this.listPermission.has(Constant.ACTION2.DELETE);
    this.checkUpdate = this.listPermission.has(Constant.ACTION2.EDIT);
    this.checkExport = this.listPermission.has(Constant.ACTION2.EXPORT);
    this.checkImport = this.listPermission.has(Constant.ACTION2.IMPORT); */

  }

  ngOnDestroy(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  get() {
    this.translate.use(this.translate.defaultLang).subscribe(data => {
      this.data = data;
    });
  }  

  searchData(reset: boolean = false): void {
    this.loading = true;
    this.systemService.getAll().subscribe((res) => {
      this.systems = res;
      this.total = res.length;
      this.loading = false;
    });
  } 

  showConfirm(): void {
    this.get();
    this.confirmationService.confirm({
        header: this.data.title_confirm_delete,
        message: this.data.content_confirm_delete,
        acceptLabel: this.data.ok,
        rejectLabel: this.data.cancel,
        accept: () => this.deleteSystem()
    });    
  }

  deleteSystem() {
    let selectedSystemId : number[] = [];
    this.selectedSystems.forEach(item => selectedSystemId.push(item.id));
    this.systemService.deleteSystem(selectedSystemId).subscribe(res => {
      this.messageService.add({key: "toastSystemView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_DELETE_SUCCESS});
      this.searchData(true);
      this.selectedSystems = [];
    });
  }

  showModal(data): void {
    this.isVisible = true;
    this.system = data;
  }

  closeModalUpdate(value) {
    this.isVisible = value;
  }  

  updateSystem(value) {    
    this.sub = this.systemService.updateSystem(value).subscribe((data) => {
      if (data != null) {
        this.messageService.add({key: "toastSystemView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        this.isVisible = false;
        this.searchData(true);
      }
    },
    (err) => {
      this.messageService.add({key: "toastSystemView",severity:'error', summary:'Cập nhật không thành công', detail: err.error});
      console.log(err)
    }
    );
  }

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  addSystem(value) {    
    this.sub = this.systemService.addSystem(value).subscribe((data) => {      
      if (data != null) {
        this.messageService.add({key: "toastSystemView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        this.isVisibleAdd = false;        
        this.searchData(true);
      }
    },
    (err) => {
      this.messageService.add({key: "toastSystemView",severity:'error', summary:'Thêm mới không thành công', detail: err.error});
      console.log(err)
    }
    );
  }

  closeModalAdd(value) {
    this.isVisibleAdd = value;
  }

  getRowIndex = (index, pageIndex, pageSize) => index + 1 + pageSize * (pageIndex - 1);
}
