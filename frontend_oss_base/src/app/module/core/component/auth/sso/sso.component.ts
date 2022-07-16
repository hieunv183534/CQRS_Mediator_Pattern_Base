import {Component, OnDestroy, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {TranslateService} from "@ngx-translate/core";
import {Constant} from "src/app/shared/constants/constant.class";
import {Subscription} from "rxjs";
import {User} from "../../../model/user.class";
import {AuthModel, LoginModel, MenuLoginModel, UserInfo} from "../../../model/auth.model";
import {AuthService} from "../../../service/auth.service";
import {Util} from "src/app/shared/utils/util.class";

@Component({
  selector: 'sso',
  templateUrl: './sso.component.html',
  styleUrls: ['./sso.component.scss']
})
export class SsoComponent implements OnInit, OnDestroy {
  sub: Subscription;
  user: User;
  auth: AuthModel;
  userInfo: UserInfo;
  menu: MenuLoginModel;

  constructor(private activatedRoute: ActivatedRoute,
              private router: Router,
              private translate: TranslateService,
              private authService: AuthService,
  ) {
  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      var ssoTicket = params['ticket'];
      if (ssoTicket === undefined || ssoTicket.length === 0) {
        alert(this.translate.instant(Constant.LOGIN.MSG_KEY.CAS_ERROR));
        window.location.href = Constant.LOGIN.PAGE.INIT;
        return;
      }
      var loginModel: LoginModel = {
        casTicket: ssoTicket,
        loginType: Constant.LOGIN.TYPE.CAS,
        requestDate: Util.genRequestDate(),
        requestId: Util.genRequestId(),
      };

      this.sub = this.authService.login(loginModel).subscribe(res => {
        if (res !== null) {
          if (res.errorCode === Constant.LOGIN.ERROR_CODE.REDIRECT_TO_HOME) {
            this.userInfo = res.userInfo;
            this.menu = res.menuDtoList;
            localStorage.setItem(Constant.CACHE_KEY.TOKEN, res.token);
            localStorage.setItem(Constant.CACHE_KEY.USER_INFO, JSON.stringify(this.userInfo));
            localStorage.setItem(Constant.CACHE_KEY.MENU, JSON.stringify(this.menu));
            localStorage.setItem(Constant.CACHE_KEY.ROLES, JSON.stringify(this.userInfo.roles));

            this.auth = res;
            // alert(this.translate.instant(Constant.LOGIN.MSG_KEY.LOGIN_SUCCESS));
            // setTimeout(() => { alert(this.translate.instant(Constant.LOGIN.MSG_KEY.LOGIN_SUCCESS)); }, 1000)
            this.router.navigate([res.userInfo.redirectUrl]);
            return;
          }
          if (res.errorCode === Constant.LOGIN.ERROR_CODE.GRANT_PERMISSION) {
            alert(this.translate.instant(Constant.LOGIN.MSG_KEY.NEED_GRANT_PERMISSION));
            window.location.href = Constant.LOGIN.PAGE.INIT;
            return;
          }
        }
      }, error => {
        alert(this.translate.instant(Constant.LOGIN.MSG_KEY.LOGIN_FAIL));
        window.location.href = Constant.LOGIN.PAGE.INIT;
        return;
      });

    });
  }

  ngOnDestroy(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

}
