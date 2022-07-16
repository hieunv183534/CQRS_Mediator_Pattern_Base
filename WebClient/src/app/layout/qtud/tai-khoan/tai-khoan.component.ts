import { SettingService } from 'src/app/_shared/services/setting.service';
import { UserService } from 'src/app/_shared/services/user.service';
import {
  ExampleBasicApi,
  ExampleExampleBasicDeleteCommand,
  ExampleExampleBasicGetPagingQuery,
  ExampleExampleBasicGetPagingQueryResult,
  IdentityAspNetUserAciticeUserActiveUserCommand,
  IdentityAspNetUserGetPagingQuery,
  UserApi,
} from "./../../../_shared/bccp-api.services";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { PagingModel } from "src/app/_base/models/response-model";
import { TableConfigModel } from "src/app/_base/models/table-config-model";
import {
  DialogService,
  DialogSize,
  DialogMode,
} from "src/app/_base/servicers/dialog.service";
import { MessageService } from "src/app/_base/servicers/message.service";
import { TaiKhoanDataDialogComponent } from "./tai-khoan-data-dialog/tai-khoan-data-dialog.component";
import { OptionModel } from 'src/app/_base/models/option-model';
import { DeviceStatusColor, UserStatusColor } from 'src/app/_shared/enums/tiepnhan/acceptance';

@Component({
  selector: "app-tai-khoan",
  templateUrl: "./tai-khoan.component.html",
  styleUrls: ["./tai-khoan.component.scss"],
})
export class TaiKhoanComponent implements OnInit {
  public formSearch: FormGroup;

  public listOfData: any[] = [];
  public isLoading = false;
  public paging: PagingModel;
  public lstStatus: OptionModel[] = [
    { value: 'false', text: 'Đang sử dụng', color: UserStatusColor.DangSuDung },
    { value: 'true', text: 'Không còn sử dụng', color: UserStatusColor.KhongSuDung }
  ];

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: "id",
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>(),
  });
  public checked = false;
  public loading = false;

  public lstType: any[] = [
    { value: 1, text: "Tài khoản hệ thống" },
    { value: 2, text: "Tài khoản khách hàng" },
  ];

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private exampleBasicApi: ExampleBasicApi,
    private userService: UserService,
    private userApi: UserApi,
    private settingService: SettingService
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      userName: [""],
      fullName: [""],
      userType: [1]
    });
    await this.getData();
  }

  async getData(
    paging: PagingModel = { order: { userName: true } }
  ): Promise<void> {
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

    switch (formData.userType) {
      case 1:
        where.and.push({ POSCode: { neq: null } });
        where.and.push({ CustomerCode: null });
        break;
      default:
        where.and.push({ POSCode: null });
        where.and.push({ CustomerCode: { neq: null } });
        break;
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    this.isLoading = true;
    const rs = await this.userApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(
      (option) => {
        option.title = "Thêm mới";
        option.size = DialogSize.large;
        option.component = TaiKhoanDataDialogComponent;
        option.inputs = {
          id: null,
          type: this.formSearch.get('userType').value,
          mode: DialogMode.add,
        };
      },
      (eventName, eventValue) => {
        if (eventName === "onClose") {
          this.dialogService.closeDialogById(dialog.id);
          if (eventValue) {
            this.getData({ ...this.paging, page: 1 });
          }
        }
      }
    );
  }

  async showDataDialog(id: string): Promise<void> {
    const dialog = this.dialogService.openDialog(
      (option) => {
        option.title = "Xem thông tin dữ liệu";
        option.size = DialogSize.large;
        option.component = TaiKhoanDataDialogComponent;
        option.inputs = {
          id,
          type: this.formSearch.get('userType').value,
          mode: DialogMode.view,
        };
      },
      (eventName) => {
        if (eventName === "onClose") {
          this.dialogService.closeDialogById(dialog.id);
        }
      }
    );
  }

  async editDataDialog(id: string): Promise<void> {
    const dialog = this.dialogService.openDialog(
      (option) => {
        option.title = "Sửa dữ liệu";
        option.size = DialogSize.large;
        option.component = TaiKhoanDataDialogComponent;
        option.inputs = {
          id,
          type: this.formSearch.get('userType').value,
          mode: DialogMode.edit,
        };
      },
      (eventName) => {
        if (eventName === "onClose") {
          this.dialogService.closeDialogById(dialog.id);
          this.getData(this.paging);
        }
      }
    );
  }

  async deleteData(listId: string[]): Promise<void> {
    this.dialogService.error("", "Chức năng đang phát triển");
    // const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    // if (!result) { return; }

    // const params = new ExampleExampleBasicDeleteCommand({
    //   id: listId
    // });
    // const rs = await this.exampleBasicApi.delete(params).toPromise();
    // if (rs.success) {
    //   this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
    //   this.getData(this.paging);
    // } else {
    //   this.messageService.notiMessageError(rs.error);
    // }
  }

  async activeUser(type: number, user: string): Promise<void> {

    const result = await this.dialogService.confirm(`Bạn có muốn ${type == 1 ? 'Khoá ' : 'Phê duyệt '} người dùng này không?`, ' ');
    if (!result) { return; }
    const params = new IdentityAspNetUserAciticeUserActiveUserCommand({
      username: user,
      lockoutEnabled: type === 1 ? true : false
    });
    const rs = await this.userApi.activeUseer(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess(`${type == 1 ? 'Khoá ' : 'Phê duyệt '} người dùng thành công`);
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

  exportData() {
    debugger;
    let reportCode = "DanhSachNguoiDung";
    let fileNameDownload = "DanhSachNguoiDung";

    let reportParams = JSON.stringify({
      Creater: this.userService.userInfo.fullName
    });

    location.href = `${this.settingService.data.reportApi}/api/ReportBi/Export?ReportCode=${reportCode}&FileName=${fileNameDownload}&Type=${2}&ReportParams=${reportParams}`;
  }
}
