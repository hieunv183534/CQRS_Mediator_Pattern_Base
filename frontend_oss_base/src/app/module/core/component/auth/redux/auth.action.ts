import {Action} from '@ngrx/store';
import {User} from '../../../model/user.class';
import {AuthModel} from '../../../model/auth.model';

export enum AuthActionTypes {
  Login = '[User] Login',
  LoginSuccess = '[User] Login Success',
  LoginFail = '[User] Login Fail',
  Logout = '[User] Logout',
  LogoutSuccess = '[User] Logout Success',
  LogoutFail = '[User] Logout Fail'
}
export class Login implements Action {
  public readonly type = AuthActionTypes.Login;
  constructor(public payload: User) {}
}
export class LoginSuccess implements Action {
  public readonly type = AuthActionTypes.LoginSuccess;
  constructor(public payload: AuthModel) {}
}
export class LoginFail implements Action {
  public readonly type = AuthActionTypes.LoginFail;
  constructor(public err: string) {}
}
export class Logout implements Action {
  public readonly type = AuthActionTypes.Logout;
}
export class LogoutSuccess implements Action {
  public readonly type = AuthActionTypes.LogoutSuccess;
  constructor(public payload: any) {}
}
export class LogoutFail implements Action {
  public readonly type = AuthActionTypes.LogoutFail;
  constructor(public err: string) {}
}
export type AuthActions = Login | LoginSuccess | LoginFail | Logout | LogoutSuccess | LogoutFail;
