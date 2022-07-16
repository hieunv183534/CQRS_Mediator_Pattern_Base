import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {select, Store} from '@ngrx/store';
import * as fromAuth from '../redux/auth.reducer';
import {AuthModel, MenuLoginModel, UserInfo} from '../../../model/auth.model';
import {Observable, Subscription} from 'rxjs';
import {Constant} from 'src/app/shared/constants/constant.class';
import {AuthService} from '../../../service/auth.service';
import {User} from '../../../model/user.class';
import {TranslateService} from '@ngx-translate/core';
import {Util} from "src/app/shared/utils/util.class";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
 // styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  validateForm: FormGroup;
  messageError: string;
  sub: Subscription;
  user: User;
  auth: AuthModel;
  userInfo: UserInfo;
  menu: MenuLoginModel;
  submited: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private translate: TranslateService,
    private store: Store<fromAuth.AppState>,
    private route: ActivatedRoute,
    private authService: AuthService,
  ) {
  }

  ngOnDestroy(): void {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  ngOnInit(): void {

    // var data = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.USER_INFO));
    // if(data !== undefined){
    //   window.location.href = data.redirectUrl;
    // }
    this.validateForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
      loginType: 1,
      requestId: Util.genRequestId(),
      requestDate: Util.genRequestDate()
    });
    
    var token = this.route.snapshot.params["ticket"];
    //var token = this.route.snapshot.paramMap.get('ticket');
    let keyToken = localStorage.getItem(Constant.CACHE_KEY.TOKEN);
    if(keyToken != null && keyToken != undefined) {
      this.router.navigate(['/welcome']);
      return;

    }    
    // this.returnUrl = this.route.snapshot.queryParams.returnUrl || Constant.WELCOME;
    // const currentUser = localStorage.getItem(Constant.TOKEN);
    // if (currentUser) {
    //   this.router.navigate([Constant.WELCOME]);
    // }
  }

  get f() {
    return this.validateForm.controls;
  }

  submitForm(): void {        
    this.submited = true;
    if (this.validateForm.valid) {  
      this.sub = this.authService.login(this.validateForm.value).subscribe(res => {
        if (res !== null) {
          if (res.errorCode === Constant.LOGIN.ERROR_CODE.REDIRECT_TO_HOME) {
            this.userInfo = res.userInfo;
            this.menu = res.menuDtoList;
            localStorage.setItem(Constant.CACHE_KEY.TOKEN, res.token);
            localStorage.setItem(Constant.CACHE_KEY.USER_INFO, JSON.stringify(this.userInfo));
            localStorage.setItem(Constant.CACHE_KEY.MENU, JSON.stringify(this.menu));
            localStorage.setItem(Constant.CACHE_KEY.ROLES, JSON.stringify(this.userInfo.roles));

            this.auth = res;
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
        this.messageError = this.translate.instant(Constant.LOGIN.MSG_KEY.LOGIN_FAIL);
      });
    }
  }

  casLogin(): void {
    window.location.href = 'https://id.vnpt.com.vn/cas/login?service=http://localhost:4200/sso';
  }

}
