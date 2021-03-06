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
    //         'B???n c?? th??ng b??o m???i!',
    //         notification.data.message
    //       );
    //   });
    // const rs = await this.notificationService.getByReceiver();
    // if (rs.ok) {
    //   this.listOfNotification = rs.result.data;
    //   this.hasNewNotification = this.listOfNotification.some(x => x.status === NotificationStatusEnum.Unread);
    // }
    if (!this.userService.userInfo.shiftHandover) {

      // ko co buu cuc l?? tk kh??ch h??ng
      if (!this.userService.userInfo.postCode) {
        return;
      }
      // const result = await this.dialogService.confirm('B???n c?? mu???n kh???i t???o ca l??m vi???c m???i kh??ng?', ' ');
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
            const result = await this.dialogService.error('L???i h??? th???ng: Kh??ng t???o ???????c ca l??m vi???c ' + shiftHandoverResult.error, ' ');
            if (result) {
              this.router.navigate(['/public/account/logout']);
            }
          }
        } else {
          const result = await this.dialogService.error('Kh??ng x??c ?????nh ???????c danh m???c ca l??m vi???c c???a b??u c???c. Y??u c???u li??n h??? qu???n tr??? khai b??o danh m???c ca', ' ');
          if (result) {
            this.router.navigate(['/public/account/logout']);
          }
        }
      } else {
        const result = await this.dialogService.error('L???i h??? th???ng: ' + shiftResult.error, ' ');
        if (result) {
          this.router.navigate(['/public/account/logout']);
        }
      }
    } else {

      //???? t???n t???i ca l??m vi???c: Tr???ng th??i ???? ch???t ca
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
              const result = await this.dialogService.error('L???i h??? th???ng: Kh??ng t???o ???????c ca l??m vi???c ' + shiftHandoverResult.error, ' ');
              if (result) {
                this.router.navigate(['/public/account/logout']);
              }
            }
          } else {
            const result = await this.dialogService.error('Kh??ng x??c ?????nh ???????c danh m???c ca l??m vi???c c???a b??u c???c. Y??u c???u li??n h??? qu???n tr??? khai b??o danh m???c ca', ' ');
            if (result) {
              this.router.navigate(['/public/account/logout']);
            }
          }
        } else {
          const result = await this.dialogService.error('L???i h??? th???ng: ' + shiftResult.error, ' ');
          if (result) {
            this.router.navigate(['/public/account/logout']);
          }
        }

      } else {
        //???? t???n t???i ca l??m vi???c: Tr???ng th??i ch??a ch???t ca

        const shiftHandover = new BanGiaoCaShiftHandoverCheckOutOfDateQuery({
          shiftHandoverID: this.userService.userInfo.shiftHandover.shiftHandoverID
        });
        const shiftHandoverResult = await this.shiftHandoverApi.checkOutOfDate(shiftHandover).toPromise();
        if (shiftHandoverResult.success) {
          if (shiftHandoverResult.result === 1) {
            const result = await this.dialogService.error('Ca l??m vi???c ???? qu?? th???i gian quy ?????nh. Y??u c???u ch???t ca ????? th???c hi???n ca l??m vi???c m???i', ' ');
            if (result) {

            }
          }

          await this.confirmedShiftHandorver();

        } else {
          const result = await this.dialogService.error('L???i h??? th???ng: Kh??ng x??c ?????nh ???????c ca l??m vi???c ' + shiftHandoverResult.error, ' ');
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
            option.title = 'Th??ng tin chi ti???t b??n giao ca - x??c nh???n ca tr?????c';
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
      const result = await this.dialogService.error('L???i h??? th???ng: ' + shResult.error, ' ');
      if (result) {
        this.router.navigate(['/public/account/logout']);
      }
    }

  }

  async onChangePos() {
    const result = await this.dialogService.confirm('', 'B???n c?? ch???c mu???n chuy???n b??u c???c kh??ng?');
    if (!result) return;
    const postCode = this.myForm.get('posCode').value;
    // api g???i update postCode
    const rs = await this.posApi.changePos(new DanhMucPOSChangePosCommand({ posCode: postCode })).toPromise();
    if (rs.success) {
      await this.dialogService.error('H??? th???ng', 'Chuy???n b??u c???c th??nh c??ng! ???n ok ????? ????ng nh???p l???i');
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
      option.title = 'Danh s??ch ca l??m vi???c';
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
