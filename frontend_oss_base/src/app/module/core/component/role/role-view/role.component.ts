import {Component, OnDestroy, OnInit} from '@angular/core';
import {Role} from '../../../model/role.class';
import {TranslateService} from '@ngx-translate/core';
import {Constant} from 'src/app/shared/constants/constant.class';
import {RoleService} from '../../../service/role-service';
import {FormBuilder, FormGroup} from '@angular/forms';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {ActionService} from '../../../service/action.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { EntityDto } from '../../../model/entity.class';
import { EntityService } from '../../../service/entity.service';
import { Action } from 'src/app/module/core/model/action.model';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html'  ,
  providers: [ConfirmationService, ActionService, MessageService],
})
export class RoleComponent implements OnInit, OnDestroy {
  public readonly DOWNLOAD_REPORT_URL = UrlConstant.LIST_ROLE + UrlConstant.REPORT_ROLE;
  public readonly REPORT_NAME = Constant.REPORT_NAME;

  roles: Role[] = [];
  selectedRoles: Role[] = [];
  cols: any[];
  data: any;
  formSearch: FormGroup;
  isVisibleAdd: boolean;
  isVisibleUpdate: boolean;
  role: Role;  
  loading: boolean;
  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;  
  listPermission: any;  
  entities: EntityDto[] = [];
  actions: Action[] = [];

  statusOptions = Constant.statusOptions;
  statusOptionsAll = Constant.commonStatusOptionsAll;

  constructor(    
    public translate: TranslateService,    
    private roleService: RoleService,        
    private actionService: ActionService,
    private confirmationService: ConfirmationService,
    private entityService: EntityService,
    private messageService: MessageService,
    private fb: FormBuilder) {    

    this.cols = [      
      { field: 'name', header: 'Name' },
      { field: 'entity', header: 'Entity' },
      { field: 'action', header: 'Action' },
      { field: 'status', header: 'Status' }
    ];
  }

  ngOnInit(): void {
    
    this.getListPermission();
    this.getListRole();

    this.entityService.getActiveEntity().subscribe(res => {
      this.entities = res;
    });

    this.actionService.getListActiveAction().subscribe(res => {
      this.actions = res;
    });  
  }

  async getListPermission() {
    let arrayPermission: any;
    // await this.actionServices.getActionByScreen(Constant.SCREEN.ROLE).then(value => {
    //   arrayPermission = value;
    //   this.listPermission = new Set(arrayPermission);
    // });
    // this.checkAdd = this.listPermission.has(Constant.ACTION2.ADD);
    // this.checkDelete = this.listPermission.has(Constant.ACTION2.DELETE);
    // this.checkUpdate = this.listPermission.has(Constant.ACTION2.EDIT);    
  }

  ngOnDestroy(): void {    
  }

  getListRole(reset: boolean = false) {    
    this.loading = true;    
    this.roleService.getRole(1, 1).subscribe(res => {
      if (res !== null) {
        this.roles = res;
        this.loading = false;
        // this.total = res.totalElements;
      }
    });
  }

  get() {
    this.translate.use(this.translate.defaultLang).subscribe(data => {
      this.data = data;
    });
  }

  showConfirm(): void {
    this.get();
    this.confirmationService.confirm({
      header: this.data.title_confirm_delete,
      message: this.data.content_confirm_delete,
      acceptLabel: this.data.ok,
      rejectLabel: this.data.cancel,
      accept: () => this.deleteRole()
  });    
  }

  deleteRole() {
    let ids = [];
    this.selectedRoles.forEach(element => {
      ids.push(element.roleId);
    });
    this.roleService.deleteRole(ids).subscribe(res => {      
      this.messageService.add({key: "toastRoleView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_DELETE_SUCCESS});      
      this.selectedRoles = [];
      this.getListRole();
    }, error => {
      this.messageService.add({key: "toastRoleView",severity:'error', summary:'Xóa không thành công', detail: error.error});
      console.log(error)
    }); 
  }

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  showModalUpdate(data) {
    this.isVisibleUpdate = true;
    this.role = data;
  }

  closeModalAdd(value) {
    this.isVisibleAdd = value;
  }

  closeModalUpdate(value) {
    this.isVisibleUpdate = value;
  }

  updateRole(value) {
    this.roleService.updateRole(value).subscribe(res => {      
      this.messageService.add({key: "toastRoleView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_UPDATE_SUCCESS});
      this.isVisibleUpdate = false;
      this.getListRole();
    }, error => {
      this.messageService.add({key: "toastRoleView",severity:'error', summary:'Cập nhật không thành công', detail: error.error});
      console.log(error)
    });        
  }

  addRole(value) {
    // this.isVisibleAdd = ;
    this.roleService.addRole(value).subscribe(res => {
      this.isVisibleAdd = false;
      if (res) {
        this.messageService.add({key: "toastRoleView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        this.getListRole(); 
      } 
    }, error => {
      this.messageService.add({key: "toastRoleView",severity:'error', summary:'Thêm mới không thành công', detail: error.error});
      console.log(error)
    });
    
  }  

  searchRole() {    
    this.getListRole();    
  }  

  getStatus(status: number) {
    if (status === 0) {
      return Constant.IN_ACTIVE;
    } else if (status === 1) {
      return Constant.ACTIVE;
    } else if (status === 2) {
      return Constant.LOCK;
    }
    return Constant.DELETE_STATUS;
  }
}
