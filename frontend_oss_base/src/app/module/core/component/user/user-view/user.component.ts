import {Component, OnDestroy, OnInit} from '@angular/core';
import {UserService} from '../../../service/user-service';
import {User} from '../../../model/user.class';
import {SearchUser, SearchUserParam} from '../../../model/searchUser.class';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Constant} from 'src/app/shared/constants/constant.class';
import {TranslateService} from '@ngx-translate/core';
import {Subscription} from 'rxjs';
import {Role} from '../../../model/role.class';
import {Group} from '../../../model/group.class';
import * as XLSX from 'xlsx';
import jsPDF from "jspdf";
import autoTable from "jspdf-autotable";
import * as FileSaver from 'file-saver';
// import * as fromGroup from '../../group/redux/group.reducer';
import {AppConfigService} from 'src/app-config.service';
import {MenuService} from '../../../service/menu.service';
import {MenuRoles} from '../../../model/menuRoles.class';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {ActionService} from '../../../service/action.service';
import {RoleService} from '../../../service/role-service';
import {GroupService} from '../../../service/group-service';
import { MessageService } from 'primeng/api';
import {MenuItem} from 'primeng/api';
import {ConfirmationService} from 'primeng/api';
declare var google: any;
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  // styleUrls: ['src/app/shared/style/tablebasic.scss'],
  styles: [`
      :host ::ng-deep .p-dialog .product-image {
          width: 150px;
          margin: 0 auto 2rem auto;
          display: block;
      }

      @media screen and (max-width: 960px) {
          :host ::ng-deep .p-datatable.p-datatable-customers .p-datatable-tbody > tr > td:last-child {
              text-align: center;
          }

          :host ::ng-deep .p-datatable.p-datatable-customers .p-datatable-tbody > tr > td:nth-child(6) {
              display: flex;
          }
      }

      .active {
        background: #C8E6C9;
        color: #256029;
      }

      .inactive {
        background: #C8E6C9;
        color: #256029;
      }
  `],
  providers: [MessageService, ConfirmationService]
})

export class UserComponent
// extends TableSelectionAbstract
implements OnInit, OnDestroy {
  public readonly DOWNLOAD_REPORT_URL = UrlConstant.DETAIL_USER + UrlConstant.REPORT_USER;
  public readonly REPORT_NAME = Constant.REPORT_NAME;

  users: User [] = [];
  selectedUsers: User [] = [];
  cols: any[];
  loading = false;
  total: number;
  search: SearchUser = new SearchUser();
  formSearch: FormGroup;
  searchParam: SearchUserParam;

  isVisible = false;
  isVisibleAdd = false;
  isVisibleAuthen = false;
  data: any;
  sub: Subscription;
  user: User;
  roles: Role[] = [];
  groups: Group[] = [];
  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;
  checkAuthen = true;
  checkExport = true;
  a = new Set();
  pageSize: any;
  page: any;
  defaultPage: any;
  listPermission: any;
  nodes: MenuRoles[] = [];
  checkImport = false;
  isVisibleImport = false;

  // Phân quyền
  isVisibleRole = false;
  userStatusOptionsAll = Constant.userStatusOptionsAll;
  // statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];
  // End Phân quyền

  exportButtons: MenuItem[];

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private userService: UserService,
    private fb: FormBuilder,
    public translate: TranslateService,
    private configService: AppConfigService,
    private menuService: MenuService,
    private actionServices: ActionService,
    private roleService: RoleService,
    private groupService: GroupService
  ) {
    this.formSearch = this.fb.group({
      name: null,
      email: null,
      phoneNumber: null,
      groupId: null,
      status: null,
      username: null,
    });
  }
    options: any;

    overlays: any[];

    dialogVisible: boolean;

    markerTitle: string;

    selectedPosition: any;

    infoWindow: any;

    draggable: boolean;

    handleMapClick(event) {
        this.dialogVisible = true;
        this.selectedPosition = event.latLng;
    }

    handleOverlayClick(event) {
        let isMarker = event.overlay.getTitle != undefined;

        if (isMarker) {
            let title = event.overlay.getTitle();
            this.infoWindow.setContent('' + title + '');
            this.infoWindow.open(event.map, event.overlay);
            event.map.setCenter(event.overlay.getPosition());

            this.messageService.add({severity:'info', summary:'Marker Selected', detail: title});
        }
        else {
            this.messageService.add({severity:'info', summary:'Shape Selected', detail: ''});
        }
    }

    addMarker() {
        this.overlays.push(new google.maps.Marker({position:{lat: this.selectedPosition.lat(), lng: this.selectedPosition.lng()}, title:this.markerTitle, draggable: this.draggable}));
        this.markerTitle = null;
        this.dialogVisible = false;
    }

    handleDragEnd(event) {
        this.messageService.add({severity:'info', summary:'Marker Dragged', detail: event.overlay.getTitle()});
    }

    initOverlays() {
        if (!this.overlays||!this.overlays.length) {
            this.overlays = [
                new google.maps.Marker({position: {lat: 36.879466, lng: 30.667648}, title:"Konyaalti"}),
                new google.maps.Marker({position: {lat: 36.883707, lng: 30.689216}, title:"Ataturk Park"}),
                new google.maps.Marker({position: {lat: 36.885233, lng: 30.702323}, title:"Oldtown"}),
                new google.maps.Polygon({paths: [
                        {lat: 36.9177, lng: 30.7854},{lat: 36.8851, lng: 30.7802},{lat: 36.8829, lng: 30.8111},{lat: 36.9177, lng: 30.8159}
                    ], strokeOpacity: 0.5, strokeWeight: 1,fillColor: '#1976D2', fillOpacity: 0.35
                }),
                new google.maps.Circle({center: {lat: 36.90707, lng: 30.56533}, fillColor: '#1976D2', fillOpacity: 0.35, strokeWeight: 1, radius: 1500}),
                new google.maps.Polyline({path: [{lat: 36.86149, lng: 30.63743},{lat: 36.86341, lng: 30.72463}], geodesic: true, strokeColor: '#FF0000', strokeOpacity: 0.5, strokeWeight: 2})
            ];
        }
    }

    zoomIn(map) {
        map.setZoom(map.getZoom()+1);
    }

    zoomOut(map) {
        map.setZoom(map.getZoom()-1);
    }

    clear() {
        this.overlays = [];
    }

  ngOnInit(): void {

      this.options = {
          center: {lat: 36.890257, lng: 30.707417},
          zoom: 12
      };

      this.initOverlays();

      this.infoWindow = new google.maps.InfoWindow();


      this.getListPermission();
      this.pageSize = this.configService.getConfig().pageSize;
      this.page = this.configService.getConfig().page;
      this.defaultPage = this.configService.getConfig().defaultPage;
      this.search.page = this.page;
      this.search.pageSize = this.defaultPage;
      this.search.sortType = true;
      this.search.status = Constant.RECORD.STATUS.FILTER_ALL;
      this.searchData();
      this.getListRole();
      this.getListGroup();
      this.roleService.getRolesGroupByEntity().subscribe(res => {
          if(res != null && res != undefined)  {
              this.nodes = res
          }
      });
      this.cols = [
          { field: 'name', header: 'Name' },
          { field: 'email', header: 'email' },
          { field: 'phoneNumber', header: 'phoneNumber' },
          { field: 'group.name', header: 'group' },
          { field: 'status', header: 'status' },
          { field: 'userName', header: 'userName' }
      ];
      this.exportButtons = [
          {label: 'Export Excel', icon: 'pi pi-file-excel', command: () => {this.export('EXCEL');}},
          {label: 'Export PDF', icon: 'pi pi-file-pdf', command: () => {this.export('PDF');}}
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

  getListRole() {
    this.roleService.getRoles().subscribe((res) => {
      this.roles = res;
    });
  }

  getListGroup() {
    this.groupService.getGroups({status: Constant.RECORD.STATUS.FILTER_ALL}).subscribe((res) => {
      this.groups = res.groupDtoList;
    });
  }

  searchData(reset: boolean = false): void {
    // this.loading = true;
    if (reset) {
      this.search.page = 1;
    }

    this.userService.getUser(this.search).subscribe((res) => {
      this.users = res.userDtoList;
      this.total = res.totalRow;
      this.loading = false;
    });
  }

  onSearchSubmit() {
    this.search.email = this.formSearch.get('email').value;
    this.search.name = this.formSearch.get('name').value;
    this.search.phoneNumber = this.formSearch.get('phoneNumber').value;
    this.search.groupId = this.formSearch.get('groupId').value;
    this.search.status = this.formSearch.get('status').value;
    if(this.search.status == null)
      this.search.status = Constant.RECORD.STATUS.FILTER_ALL;
    this.search.userName = this.formSearch.get('username').value;

    this.searchParam = new SearchUserParam();
    this.searchParam.setUserNameParam(this.search.name);
    this.searchParam.setEmailParam(this.search.email);
    this.searchParam.setPhoneParam(this.search.phoneNumber);
    this.searchParam.setGroupParam(this.search.groupId);
    this.searchParam.setStatusParam(this.search.status);

    this.searchData(true);
  }

  showConfirm(): void {
    this.get();
    this.confirmationService.confirm({
        header: this.data.title_confirm_delete,
        message: this.data.content_confirm_delete,
        acceptLabel: this.data.ok,
        rejectLabel: this.data.cancel,
        accept: () => this.deleteUser()
    });
  }

  deleteUser() {
    let selectedUserId : number[] = [];
    this.selectedUsers.forEach(item => selectedUserId.push(item.userId));
    this.userService.deleteUser(selectedUserId).subscribe(res => {
      this.messageService.add({key: "toastUserView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_DELETE_SUCCESS});
      this.searchData(true);
    });
  }

  export(format: string) {
    if(format == 'EXCEL') {
      const worksheet = XLSX.utils.json_to_sheet(this.users);
      const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, "Users");

    }
    if(format == 'PDF') {
      let dataArray = [];
      this.users.forEach(item => dataArray.push({"name": item.name, "email": item.email, "phoneNumber": item.phoneNumber, "group.name": item.group.name, "status": this.getStatusUser(Number(item.status)), "userName": item.userName}));
      let exportColumns = [];
      this.cols.forEach(col => exportColumns.push({title: col.header, dataKey: col.field}));
      const doc = new jsPDF('p','pt');
      autoTable(doc, {
        columns: exportColumns,
        body: dataArray,
        didDrawPage: (dataArg) => {
         doc.text('Users', dataArg.settings.margin.left, 10);
        }
       });
      doc.save("Users.pdf");
    }
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }

  getStatusUser(status: number) {
    if (status === 0) {
      return Constant.IN_ACTIVE;
    } else if (status === 1) {
      return Constant.ACTIVE;
    } else if (status === 2) {
      return Constant.LOCK;
    }
    return Constant.DELETE_STATUS;
  }

  showModal(data): void {
    this.isVisible = true;
    this.user = data;
  }

  showModalAuthen(data): void {
    this.user = data;
    this.isVisibleRole = true;
  }

  closeModalUpdate(value) {
    this.isVisible = value;
  }

  closeModalAuthen(value) {
    // this.isVisibleAuthen = value;
    this.isVisibleRole = value;
  }

  updateUser(value) {
    this.sub = this.userService.updateUser(value).subscribe((data) => {
      if (data != null) {
        this.messageService.add({key: "toastUserView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_UPDATE_SUCCESS});
        this.isVisible = false;
        this.searchData(true);
      }
    },
    (err) => {
      this.messageService.add({key: "toastUserView",severity:'error', summary:'Cập nhật không thành công', detail: err.error});
      console.log(err)
    }
    );
  }

  authenUser(value) {
    this.isVisibleAuthen = false;
  }

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  addUser(value) {
    this.sub = this.userService.addUser(value).subscribe((data) => {
      if (data != null) {
        this.messageService.add({key: "toastUserView",severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        this.isVisibleAdd = false;
        this.searchData(true);
      }
    },
    (err) => {
      this.messageService.add({key: "toastUserView",severity:'error', summary:'Thêm mới không thành công', detail: err.error});
      console.log(err)
    }
    );
  }

  closeModalAdd(value) {
    this.isVisibleAdd = value;
  }

  getRowIndex = (index, pageIndex, pageSize) => index + 1 + pageSize * (pageIndex - 1);

  showModalImport() {
    this.isVisibleImport = true;
  }

  toggleModalImport(isVisible: boolean) {
    this.isVisibleImport = isVisible;
    this.searchData(true);
  }
}
