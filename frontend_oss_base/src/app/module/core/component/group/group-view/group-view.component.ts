import {Component, OnInit} from '@angular/core';
import {Group} from '../../../model/group.class';
import {Constant} from 'src/app/shared/constants/constant.class';
import {TranslateService} from '@ngx-translate/core';
import {GroupService} from '../../../service/group-service';
import {Role} from '../../../model/role.class';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {ActionService} from '../../../service/action.service';
import {RoleService} from '../../../service/role-service';
import { MenuRoles } from '../../../model/menuRoles.class';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { Util } from 'src/app/shared/utils/util.class';

@Component({
  selector: 'app-group-view',
  templateUrl: './group-view.component.html',
  providers: [MessageService, ConfirmationService]
})
export class GroupViewComponent implements OnInit {
  public readonly DOWNLOAD_REPORT_URL =  UrlConstant.LIST_GROUP + UrlConstant.REPORT_GROUP;
  public readonly REPORT_NAME = Constant.REPORT_NAME;

  groups: Group[] = [];
  searchGroups: Group[] = [];
  isVisibleAdd: boolean;
  isVisibleUpdate: boolean;
  group: Group;
  data: any;  
  roles: Role [] = [];
  loading: boolean;
  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;
  checkSetAuthen = true;
  checkExport = true;
  
  listPermission: any;  
  nodes: MenuRoles[] = [];
  cols: any[];

  selectedGroups: Group[] = [];
  // Phân quyền
  isVisibleRole = false;
  // End Phân quyền

  constructor(       
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    public translate: TranslateService,
    private groupService: GroupService,        
    private roleService: RoleService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.getListPermission();
    this.getListGroup();
    this.getListRole();
    this.cols = [
      { field: 'name', header: 'Code' },      
      { field: 'description', header: 'Description' },
      { field: 'roles', header: 'Roles' },
      { field: 'status', header: 'Status' },
    ];
    this.roleService.getRolesGroupByEntity().subscribe(res => {
      if(res != null && res != undefined)  {
        this.nodes = res;
        console.log(this.nodes)
      }
    });
  }

  async getListPermission() {
    // let arrayPermission: any;
    // await this.actionServices.getActionByScreen(Constant.SCREEN.GROUP).then(value => {
    //   arrayPermission = value;
    //   this.listPermission = new Set(arrayPermission);
    // });
    // this.checkAdd = this.listPermission.has(Constant.ACTION2.ADD);
    // this.checkDelete = this.listPermission.has(Constant.ACTION2.DELETE);
    // this.checkUpdate = this.listPermission.has(Constant.ACTION2.EDIT);
    // this.checkExport = this.listPermission.has(Constant.ACTION2.EXPORT);
  }

  getListRole() {
    this.roleService.getRoles().subscribe(res => {
      if (res !== null) {
        this.roles = res;
      }
    });
  }

  getListGroup(reset: boolean = false) {
    this.loading = true;
    this.groupService.getGroup("".trim().toLowerCase()).subscribe(res => {
      if (res !== null) {
        this.searchGroups = res.groupDtoList;        
        this.loading = false;
      }
    });
  }

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  showModalUpdate(data) {
    this.isVisibleUpdate = true;
    this.group = data;
  }

  showModalAuthen(data): void {
    // this.isVisibleAuthen = true;
    console.log(data);
    this.group = data;
    this.isVisibleRole = true;    
  }
  
  closeModalAuthen(value) {
    var success = value;
    if(success) {      
      Util.reloadCurrentRoute(this.router);
      this.messageService.add({key: "toastGroupView", severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
    }
    this.isVisibleRole = false;
  }   

  get() {
    this.translate.use(this.translate.defaultLang).subscribe(data => {
      this.data = data;
    });
  }

  showConfirm(): void { this.get();
    this.get();
    this.confirmationService.confirm({
        header: this.data.title_confirm_delete,
        message: this.data.content_confirm_delete,
        acceptLabel: this.data.ok,
        rejectLabel: this.data.cancel,
        accept: () => this.deleteGroup()
    }); 
  }

  deleteGroup() {
    let ids = [];
    this.selectedGroups.forEach((item) => {
      ids.push(item.groupId);
    });
    this.groupService.deleteGroup(ids).subscribe(res => {             
      this.messageService.add({key: "toastGroupView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_DELETE_SUCCESS});
      this.closeModalUpdate();
      this.getListGroup();
    }, error => {
      this.messageService.add({key: "toastGroupView",severity:'error', summary:'Xóa không thành công', detail: error.error});
      console.log(error)
    });
  }

  updateGroup(value) {
    this.groupService.updateGroup(value).subscribe(res => {
        if (res) {                    
          this.messageService.add({key: "toastGroupView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
          this.closeModalUpdate();
          this.getListGroup();
        }
      }, error => {
        this.messageService.add({key: "toastGroupView",severity:'error', summary:'Cập nhật không thành công', detail: error.error});
        console.log(error)
      });
  }

  closeModalUpdate() {
    this.isVisibleUpdate = false;
  }

  addGroup(value) {
    this.groupService.addGroup(value).subscribe(res => {
      if (res) {        
        this.messageService.add({key: "toastGroupView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        this.closeModalAdd();
        this.getListGroup();
      }
    }, error => {
      this.messageService.add({key: "toastGroupView",severity:'error', summary:'Thêm mới không thành công', detail: error.error});
      console.log(error)
    });
    
  }

  closeModalAdd() {
    this.isVisibleAdd = false;
  }

  getStatusGroup(status: number) {
    if (status === 0) {
      return Constant.IN_ACTIVE;
    } else if (status === 1) {
      return Constant.ACTIVE;
    } else if (status === 2) {
      return Constant.LOCK;
    }
    return Constant.DELETE_STATUS;
  }

  showListRoles(event: any, overlayPanel: any, group: Group, ) {
    this.group = group;
    overlayPanel.show(event);
  }
}
