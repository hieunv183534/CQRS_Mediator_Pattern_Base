import { BCCPDomainModelsUserModel, UserApi } from './../bccp-api.services';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { BehaviorSubject } from 'rxjs';
import { SettingService } from './setting.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public userInfo: BCCPDomainModelsUserModel;

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();
  private user: User | null;
  manager: UserManager;

  constructor(private userApi: UserApi,
    private settingService: SettingService,
     private rt: Router) { }

  public init(): Promise<void> {
    return new Promise<void>(async (resolve, reject) => {
      this.manager = new UserManager(this.getClientSettings());
      const user = await this.manager.getUser();
      this.user = user;
      this._authNavStatusSource.next(this.isAuthenticated());
      await this.initUserInfo();
      resolve();
    });
  }

  private async initUserInfo(): Promise<void> {
    if (this.settingService.data.login) {
      // check request ignor
      if (this.isAuthenticated()) {
        const rs = await this.userApi.getUserInfo().toPromise();
        if (rs.success) {
          this.userInfo = rs.result;
        }
      }
    } else {
      const rs = await this.userApi.getUserInfo().toPromise();
      if (rs.success) {
        this.userInfo = rs.result;
      }
    }
  }

  private getCookie(name: string) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  login() {
    return this.manager.signinRedirect();
  }

  async logout() {
    await this.manager.signoutRedirect();
  }

  async completeAuthentication() {

    this.user = await this.manager.signinRedirectCallback();
    this._authNavStatusSource.next(this.isAuthenticated());
  }

  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  getClientSettings(): UserManagerSettings {
    return {
      authority: this.settingService.data.identity.authority,
      client_id: this.settingService.data.identity.client_id,
      redirect_uri: this.settingService.data.identity.redirect_uri,
      response_type: this.settingService.data.identity.response_type,
      scope: this.settingService.data.identity.scope,
      post_logout_redirect_uri: this.settingService.data.identity.post_logout_redirect_uri
    };
  }
}
