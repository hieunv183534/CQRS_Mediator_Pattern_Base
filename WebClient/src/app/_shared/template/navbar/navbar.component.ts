import { ShiftHandoverStatus } from 'src/app/_shared/enums/khaithac/shifthandover';
import { BanGiaoCaShiftHandoverCheckOutOfDateQuery } from './../../bccp-api.services';
import { DanhMucPOSChangePosCommand, POSApi, BanGiaoCaShiftHandoverGetPagingQuery } from 'src/app/_shared/bccp-api.services';
import { PublicModule } from './../../../public/public.module';
import { LogoutModule } from './../../../public/account/logout/logout.module';
import { PublicComponent } from './../../../public/public.component';
import { CaLamViecComponent } from './../../../layout/calamviec/calamviec.component';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from '../../services/user.service';
// import { CompanyService } from '../services/company.service';
// import { SignalRHubService } from '../../_base/services/signalr.service';
// import { NzNotificationService } from 'ng-zorro-antd';
// import { NotificationService } from '../services/notification.service';
// import { NotificationStatusEnum } from 'src/app/_base/enums/notification-status.enum';
import { BanGiaoCaShiftHandoverCreateCommand, DanhMucShiftGetPagingQuery, ShiftHandoverApi, DimShiftApi } from '../../../_shared/bccp-api.services';
import { PagingModel } from 'src/app/_base/models/response-model';
import { Router } from '@angular/router';
import { ChiTietCaLamViecComponent } from 'src/app/layout/calamviec/chitietcalamviec/chitietcalamviec.component';
declare let $;

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NavbarComponent implements OnInit {

  public userName: Observable<string>;
  public listOffice: any[] = [];
  public curentOffice: any;
  public dropdownOpen: boolean;
  listOfNotification = [];
  hasNewNotification = true;
  whereParamPos = {};

  public myForm: FormGroup;

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private router: Router,
    private messageService: MessageService,
    public userService: UserService,
    public shiftHandoverApi: ShiftHandoverApi,
    public dimShiftApi: DimShiftApi,
    public posApi: POSApi
    // private authorizeService: AuthorizeService,
    // private officeService: CompanyService,
    // private signalRHubService: SignalRHubService,
    // private notification: NzNotificationService,
    // private notificationService: NotificationService
  ) { }

  async ngOnInit() {

    this.myForm = this.fb.group({
      posCode: [this.userService.userInfo?.postCode]
    });

    let areaPos = [];
    if (this.userService.userInfo?.areaPos) {
      areaPos = JSON.parse(this.userService.userInfo?.areaPos);
      if (areaPos.length == 1) {
        this.myForm.get('posCode').disable();
      } else if (areaPos.length > 1) {
        let whereLoopback = { where: { or: [] } };
        for (const item of areaPos) {
          whereLoopback.where.or.push({ POSCode: item });
        }
        this.whereParamPos = whereLoopback;
      }
    }

    // this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    // this.getOffice();
    // this.signalRHubService.notificationReceived
    //   .subscribe((notification: any) => {
    //     this.listOfNotification.splice(0, 0, notification);
    //     this.hasNewNotification = true;
    //     this.notification
    //       .blank(
    //         'Bạn có thông báo mới!',
    //         notification.data.message
    //       );
    //   });
    // const rs = await this.notificationService.getByReceiver();
    // if (rs.ok) {
    //   this.listOfNotification = rs.result.data;
    //   this.hasNewNotification = this.listOfNotification.some(x => x.status === NotificationStatusEnum.Unread);
    // }
    if (!this.userService.userInfo.shiftHandover) {

      // ko co buu cuc là tk khách hàng
      if (!this.userService.userInfo.postCode) {
        return;
      }
      // const result = await this.dialogService.confirm('Bạn có muốn khởi tạo ca làm việc mới không?', ' ');
      // if (!result) { 
      //   this.router.navigate(['/public/account/logout']);
      // }else{

      let paging: PagingModel = { page: 1, size: 100 };
      const where = { and: [] };
      const params = new DanhMucShiftGetPagingQuery({
        ...paging
      });

      where.and.push({ pOSCode: this.userService.userInfo.postCode });

      // where loopback
      if (where.and.length > 0) {
        params.where = where;
      }

      const shiftResult = await this.dimShiftApi.getPaging(params).toPromise();

      if (shiftResult.success) {
        if (shiftResult.result.data.length > 0) {
          const shiftHandover = new BanGiaoCaShiftHandoverCreateCommand({
            shiftCode: shiftResult.result.data[0].id.shiftCode,
            posCode: shiftResult.result.data[0].id.posCode
          });
          const shiftHandoverResult = await this.shiftHandoverApi.create(shiftHandover).toPromise();
          if (shiftHandoverResult.success) {
            this.userService.init();
          } else {
            const result = await this.dialogService.error('Lỗi hệ thống: Không tạo được ca làm việc ' + shiftHandoverResult.error, ' ');
            if (result) {
              this.router.navigate(['/public/account/logout']);
            }
          }
        } else {
          const result = await this.dialogService.error('Không xác định được danh mục ca làm việc của bưu cục. Yêu cầu liên hệ quản trị khai báo danh mục ca', ' ');
          if (result) {
            this.router.navigate(['/public/account/logout']);
          }
        }
      } else {
        const result = await this.dialogService.error('Lỗi hệ thống: ' + shiftResult.error, ' ');
        if (result) {
          this.router.navigate(['/public/account/logout']);
        }
      }
    } else {

      //Đã tồn tại ca làm việc: Trạng thái đã chốt ca
      if (this.userService.userInfo.shiftHandover.status !== ShiftHandoverStatus.DangKhoiTao) {

        let paging: PagingModel = { page: 1, size: 100 };
        const where = { and: [] };
        const params = new DanhMucShiftGetPagingQuery({
          ...paging
        });

        where.and.push({ pOSCode: this.userService.userInfo.postCode });

        // where loopback
        if (where.and.length > 0) {
          params.where = where;
        }

        const shiftResult = await this.dimShiftApi.getPaging(params).toPromise();

        if (shiftResult.success) {
          if (shiftResult.result.data.length > 0) {
            const shiftHandover = new BanGiaoCaShiftHandoverCreateCommand({
              shiftCode: shiftResult.result.data[0].id.shiftCode,
              posCode: shiftResult.result.data[0].id.posCode
            });
            const shiftHandoverResult = await this.shiftHandoverApi.create(shiftHandover).toPromise();
            if (shiftHandoverResult.success) {

              await this.userService.init();

              await this.confirmedShiftHandorver();

            } else {
              const result = await this.dialogService.error('Lỗi hệ thống: Không tạo được ca làm việc ' + shiftHandoverResult.error, ' ');
              if (result) {
                this.router.navigate(['/public/account/logout']);
              }
            }
          } else {
            const result = await this.dialogService.error('Không xác định được danh mục ca làm việc của bưu cục. Yêu cầu liên hệ quản trị khai báo danh mục ca', ' ');
            if (result) {
              this.router.navigate(['/public/account/logout']);
            }
          }
        } else {
          const result = await this.dialogService.error('Lỗi hệ thống: ' + shiftResult.error, ' ');
          if (result) {
            this.router.navigate(['/public/account/logout']);
          }
        }

      } else {
        //Đã tồn tại ca làm việc: Trạng thái chưa chốt ca

        const shiftHandover = new BanGiaoCaShiftHandoverCheckOutOfDateQuery({
          shiftHandoverID: this.userService.userInfo.shiftHandover.shiftHandoverID
        });
        const shiftHandoverResult = await this.shiftHandoverApi.checkOutOfDate(shiftHandover).toPromise();
        if (shiftHandoverResult.success) {
          if (shiftHandoverResult.result === 1) {
            const result = await this.dialogService.error('Ca làm việc đã quá thời gian quy định. Yêu cầu chốt ca để thực hiện ca làm việc mới', ' ');
            if (result) {

            }
          }

          await this.confirmedShiftHandorver();

        } else {
          const result = await this.dialogService.error('Lỗi hệ thống: Không xác định được ca làm việc ' + shiftHandoverResult.error, ' ');
          if (result) {
            this.router.navigate(['/public/account/logout']);
          }
        }
      }
    }
  }

  async confirmedShiftHandorver() {
    let paging: PagingModel = { page: 1, size: 10, order: { handoverIndex: false } };
    const where = { and: [] };
    const params = new BanGiaoCaShiftHandoverGetPagingQuery({
      ...paging
    });

    where.and.push({ pOSCode: this.userService.userInfo.postCode });
    where.and.push({ handoverIndex: this.userService.userInfo.shiftHandover.handoverIndex - 1 });

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    const shResult = await this.shiftHandoverApi.getPaging(params).toPromise();

    if (shResult.success) {
      if (shResult.result.data.length > 0) {
        if (shResult.result.data[0].status === 1) {

          const dialog = this.dialogService.openDialog(option => {
            option.title = 'Thông tin chi tiết bàn giao ca - xác nhận ca trước';
            option.size = DialogSize.xlarge;
            option.component = ChiTietCaLamViecComponent;
            option.inputs = {
              shiftHandover: shResult.result.data[0],
              mode: DialogMode.confirm
            };
          }, (eventName, eventValue) => {
            if (eventName === 'onClose') {
              this.dialogService.closeDialogById(dialog.id);
            }
          });
        }
      }
    } else {
      const result = await this.dialogService.error('Lỗi hệ thống: ' + shResult.error, ' ');
      if (result) {
        this.router.navigate(['/public/account/logout']);
      }
    }

  }

  async onChangePos() {
    const result = await this.dialogService.confirm('', 'Bạn có chắc muốn chuyển bưu cục không?');
    if (!result) return;
    const postCode = this.myForm.get('posCode').value;
    // api gọi update postCode
    const rs = await this.posApi.changePos(new DanhMucPOSChangePosCommand({ posCode: postCode })).toPromise();
    if (rs.success) {
      await this.dialogService.error('Hệ thống', 'Chuyển bưu cục thành công! Ấn ok để đăng nhập lại');
      this.router.navigate(['/public', 'account', 'logout']);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

  resizeMenu() {
    if ($('body').hasClass('sidebar-xs')) {
      $('body').removeClass('sidebar-xs');
    } else {
      $('body').addClass('sidebar-xs');
    }
  }

  showMenuMobile() {
    if ($('body').hasClass('sidebar-mobile-main')) {
      $('body').removeClass('sidebar-mobile-main');
    } else {
      $('body').addClass('sidebar-mobile-main');
    }
  }

  // get notificationStatusEnum() {
  //   return NotificationStatusEnum;
  // }

  // async readNotification(notification: any) {
  //   if (notification.status === NotificationStatusEnum.Read) { return; }
  //   const rs = await this.notificationService.updateStatus(notification.id, NotificationStatusEnum.Read);
  //   if (rs.ok) {
  //     notification.status = NotificationStatusEnum.Read;
  //   }
  // }

  // async getOffice() {
  //   const rs = await this.officeService.get({ page: 1, where: { and: [{ typeId: 2 }] } });
  //   if (rs.ok) {
  //     this.listOffice = rs.result.data;
  //   }
  //   if (localStorage.getItem('curentOffice')) {
  //     this.curentOffice = JSON.parse(localStorage.getItem('curentOffice'));
  //   }
  // }

  // async chooseOffice(item: any) {
  //   this.curentOffice = item;
  //   this.dropdownOpen = false;
  //   localStorage.setItem('curentOffice', JSON.stringify(this.curentOffice));
  // }

  async viewShiftHandover(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Danh sách ca làm việc';
      option.size = DialogSize.xlarge;
      option.component = CaLamViecComponent;
      option.inputs = {
        mode: DialogMode.view
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

}
