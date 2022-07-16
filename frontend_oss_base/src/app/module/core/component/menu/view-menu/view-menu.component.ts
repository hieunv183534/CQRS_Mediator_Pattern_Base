import {Component, OnDestroy, OnInit} from '@angular/core';
import {Menu} from '../../../model/menu.class';
import {TranslateService} from '@ngx-translate/core';
import {Constant} from 'src/app/shared/constants/constant.class';
import {MenuService} from '../../../service/menu.service';
import {Role} from '../../../model/role.class';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {RoleService} from "../../../service/role-service";
import {ConfirmationService, MessageService, TreeNode} from 'primeng/api';
import { SystemService } from '../../../service/system-service';
import { System } from '../../../model/system.class';

@Component({
  selector: 'app-view-menu',
  templateUrl: './view-menu.component.html',
  providers: [MessageService, ConfirmationService]
})
export class ViewMenuComponent implements OnInit, OnDestroy {
  public readonly DOWNLOAD_REPORT_URL = UrlConstant.LIST_MENU + UrlConstant.REPORT_MENU;
  public readonly REPORT_NAME = Constant.REPORT_NAME;

  menus: TreeNode [] = [];
  selectedMenus: TreeNode [] = [];  

  isVisibleUpdate: boolean;
  selectedMenu: Menu;

  isVisibleAdd: boolean;

  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;
  checkExport = true;

  data: any;
  cols: any[];
  systems: System [] = [];
  roles: Role [] = [];  
  constructor(    
    private messageService: MessageService,
    public translate: TranslateService,
    private menuService: MenuService,    
    private roleService: RoleService,
    private systemService: SystemService ,
    private confirmationService: ConfirmationService
  ) {    
  }

  ngOnDestroy(): void {
    
  }

  ngOnInit(): void {
    this.cols = [
      { field: 'name', header: 'Code' },      
      { field: 'url', header: 'Description' },
      { field: 'role', header: 'Role' },
      { field: 'status', header: 'Status' },
    ];

    this.getMenuData();

    this.roleService.getActiveRoles().subscribe((res) => {
      this.roles = res;
    });
    
    this.systemService.getAll().subscribe((res) => {
      this.systems = res;
    });
  }

  getMenuData() {
    this.menuService.getAllMenuTree().subscribe(res => {
      this.menus = this.convertMenuDtoToTreeNode(res.menuDtoList, 0);
      // console.log(this.menus);
    });
  }

  convertMenuDtoToTreeNode(menuDtoList: Menu[], level: number) : TreeNode []  {
    let result : TreeNode[] = [];
    menuDtoList.forEach(element => {
      let treeNodeItem : TreeNode = {
        label: element.name, 
        data: {menuId: Number, name: String, url: String, level: String, role: {}, system: {}, description: String, parentId: Number, orderPriority: Number}, 
        icon: '', 
        expandedIcon: '', 
        collapsedIcon: '', 
        children: [],
        key: String(element.menuId),
      };
      treeNodeItem.data['menuId'] = element.menuId;
      treeNodeItem.data['name'] = element.name;
      treeNodeItem.data['url'] = element.url;
      treeNodeItem.data['level'] = level;
      treeNodeItem.data['roleDto'] = element.roleDto;
      treeNodeItem.data['systemDto'] = element.systemDto;
      treeNodeItem.data['description'] = element.description;
      treeNodeItem.data['parentId'] = element.parentId;
      treeNodeItem.data['orderPriority'] = element.orderPriority;
      treeNodeItem.children = this.convertMenuDtoToTreeNode(element.menuChildren, level + 1);
      result.push(treeNodeItem);
    });
    return result;
  }

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  // Show A Update Menu of Modal
  showModalUpdate(data) {
    this.isVisibleUpdate = true;
    this.selectedMenu = data;
    // console.log(this.selectedMenu);
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
        accept: () => this.deleteMenu()
    });     
  }

  deleteMenu() {
    let ids = [];
    this.selectedMenus.forEach((item) => {
      ids.push(item.key);
    });
    this.menuService.deleteMenu(ids).subscribe(res => {      
      this.messageService.add({key: "toastMenuView",severity:'success', summary: Constant.SUCCESS , detail: Constant.MESSAGE_DELETE_SUCCESS});
      this.getMenuData();
    }, (err) => {
      this.messageService.add({key: "toastMenuView",severity:'error', summary:'Xóa không thành công', detail: err.error});
      console.log(err)
    });
  }

  updateMenu(value) {
    this.isVisibleUpdate = false;
    if(value.parentId != null) {
      value.parentId = value.parentId.key;
    }
    this.menuService.updateMenu(value).subscribe(data => {
      if (data != null) {
        // Util.reloadCurrentRoute(this.router);
        this.getMenuData();
        this.messageService.add({key: "toastMenuView",severity:'success', summary: Constant.SUCCESS , detail: Constant.MESSAGE_UPDATE_SUCCESS});
      }
    }, (err) => {
      this.messageService.add({key: "toastMenuView",severity:'error', summary:'Cập nhật không thành công', detail: err.error});
      console.log(err)
    });
  }

  closeModalAdd(value: boolean) {
    this.isVisibleAdd = value;
  }

  closeModalUpdate(value: boolean) {
    this.isVisibleUpdate = value;
  }

  addMenu(value: any) {
    if(value.parentId != null) {
      value.parentId = value.parentId.key;
    }
    this.menuService.addMenu(value).subscribe(res => {
      if (res) {
        // Util.reloadCurrentRoute(this.router);
        this.getMenuData();
        this.messageService.add({key: "toastMenuView",severity:'success', summary: Constant.SUCCESS , detail: Constant.MESSAGE_ADD_SUCCESS});
        this.isVisibleAdd = false;        
      }
    }, (err) => {
      this.messageService.add({key: "toastMenuView",severity:'error', summary:'Thêm mới không thành công', detail: err.error});
      console.log(err)
    });
  }
}