import {User} from './user.class';
import {Action} from './action.model';

export interface LoginModel {
  userName?: string;
  password?: string;
  casTicket?: string;
  loginType: number;
  requestId: string;
  requestDate: string;
}

export interface AuthModel {
  id?: number;
  authId?: string;
  token?: string;
  user?: User;
  actions?: Action[];
  expiresIn?: number;
  requestId?: string;
  code?: number;
  message?: string;
}

export interface MenuLoginModel {
  menuId: number;
  parentId: number;
  name: string;
  url: string;
  orderPriority: number;
  icon: string;
  level: number;
  menuChildren: MenuLoginModel[];
}

export interface UserInfo {
  userName: string;
  email: string;
  phoneNumber: string;
  name: string;
  roles: string[];
  redirectUrl: string;
}
