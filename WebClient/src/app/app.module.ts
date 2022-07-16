import { API_BASE_URL_REPORT } from './_shared/report-api.services';
import { SettingService } from './_shared/services/setting.service';
import { ErrorInterceptor } from './_base/interceptors/error.interceptor';
import { AuthorizeInterceptor } from './_base/interceptors/authorize.interceptor';
import { AuthGuard } from './_shared/services/auth.guard';
import { UserService } from './_shared/services/user.service';
import { LocationStrategy, PathLocationStrategy, registerLocaleData, DatePipe, PlatformLocation, CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';
import { HttpClientModule, HttpClient, HttpBackend, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgZorroAntdModule, NZ_I18N, vi_VN, NzConfig, NZ_CONFIG } from 'ng-zorro-antd';
// import { NgxPermissionsService, NgxPermissionsModule } from 'ngx-permissions';
import vi from '@angular/common/locales/vi';
// import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
// import { environment } from 'src/environments/environment';
// import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
// import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
// import { AuthorizeService } from 'src/api-authorization/authorize.service';
// import { filter, first, mergeMap } from 'rxjs/operators';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { API_BASE_URL } from './_shared/bccp-api.services';
import { environment } from 'src/environments/environment';
import { DragDropModule } from '@angular/cdk/drag-drop';
// import { API_BASE_URL } from './_shared/services/identity-api';
// import { ApplicationPaths } from 'src/api-authorization/api-authorization.constants';

declare var App: any;

// const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
//   suppressScrollX: true
// };

registerLocaleData(vi);

const ngZorroConfig: NzConfig = {
  message: {
    nzTop: 50,
    nzDuration: 5000
  },
  notification: {
    nzTop: 50,
    nzDuration: 5000
  },
  table: {
    nzBordered: true,
    nzHideOnSinglePage: true,
    nzSize: 'small'
  },
  tabs: {
    nzType: 'card'
  },
  modal: {
    nzMaskClosable: false
  }
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    NgZorroAntdModule,
    // NgxPermissionsModule.forRoot(),
    HttpClientModule,
    BrowserAnimationsModule,
    // ApiAuthorizationModule,
    AppRoutes,
    DragDropModule
  ],
  providers: [
    Location,
    { provide: LocationStrategy, useClass: PathLocationStrategy },
    { provide: NZ_I18N, useValue: vi_VN },
    { provide: NZ_CONFIG, useValue: ngZorroConfig },
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: loadPermissions,
    //   deps: [HttpClient, AuthorizeService, NgxPermissionsService],
    //   multi: true
    // },
    // {
    //   provide: PERFECT_SCROLLBAR_CONFIG,
    //   useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    // },
    UserService,
    SettingService,
    AuthGuard,
    { provide: APP_INITIALIZER, useFactory: initializeApp, deps: [UserService, SettingService], multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: API_BASE_URL, useFactory: getUrl, deps: [LocationStrategy], multi: true },
    { provide: API_BASE_URL_REPORT, useFactory: getUrlReport, deps: [LocationStrategy], multi: true},
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

// tslint:disable-next-line: typedef
export function initializeApp(userService: UserService, settingService: SettingService) {
  return (): Promise<any> => {
    return new Promise<void>(async (resolve) => {
      await settingService.init();
      await userService.init();
      resolve();
    });
  };
}

export function getUrl(location: LocationStrategy) {
  let lo: any = location;
  let path_base = location.getBaseHref();
  if (path_base === '/') {
    path_base = '';
  }
  return lo._platformLocation.location.origin + path_base;
}

export function getUrlReport(location: LocationStrategy) {
  let lo: any = location;
  return lo._platformLocation.location.origin + '/report';
}