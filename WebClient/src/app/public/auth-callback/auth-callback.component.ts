import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { UserService } from 'src/app/_shared/services/user.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { SettingService } from 'src/app/_shared/services/setting.service';
import { LocationStrategy } from '@angular/common';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  error: boolean;

  constructor(private authService: UserService,
    private settingService: SettingService,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: DialogService,
    private location: LocationStrategy) { }

  async ngOnInit() {
    // check for error
    if (this.route.snapshot.fragment.indexOf('error') >= 0) {
      this.error = true;
      return;
    }

    try {
      await this.authService.completeAuthentication();
      //logic ca
      let url = localStorage.getItem('loginCallBack');
      if (url) {
        // loai bo truong hop loop
        if (url.indexOf('/public/account/auth-callback') !== -1 || url.indexOf('/public/account/login') !== -1) {
          location.href = this.settingService.data.path;
          return;
        }
        let lo: any = this.location;
        let path_base = this.location.getBaseHref();
        if (path_base === '/') {
          path_base = '';
        }

        localStorage.removeItem('loginCallBack');
        localStorage.removeItem('loginCount');
        location.href = (lo._platformLocation.location.origin + path_base + url);
      } else {
        localStorage.removeItem('loginCallBack');
        localStorage.removeItem('loginCount');
        location.href = this.settingService.data.path;
      }

    } catch (error) {
      let mess: string = error.message;
      if (mess.toLowerCase() === 'iat is in the future') {
        mess = 'Th???i gian ????ng nh???p l?? th???i gian trong t????ng lai. Vui l??ng h??y ki???m tra th???i gian tr??n m??y t??nh chu???n v???i gi??? th??? gi???i. G???i ??: H??y n??n b???t "Set time automatically" trong c??i ?????t. Sau ???? t???t tr??nh duy???t v?? th???c hi???n l???i"';
      }
      this.dialog.error('L???i ????ng nh???p', mess);
    }

  }

}
