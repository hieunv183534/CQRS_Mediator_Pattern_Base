import {Injectable} from '@angular/core';
import {
  CanLoad,
  CanActivate,
  Router,
  Route,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';
import {Constant} from '../constants/constant.class';
import {Cookie} from 'ng2-cookies/ng2-cookies';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
  constructor(private router: Router) {
  }

  canLoad(route: Route): boolean {
    if (this.isLoggedIn()) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    // check authentication
    return this.isLoggedIn(state.url);
  }

  isLoggedIn(url?: string): boolean {
    const token = localStorage.getItem(Constant.CACHE_KEY.TOKEN);
    const currentUser = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.USER_INFO));
    if (currentUser && token) {
      return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/login'], {queryParams: {returnUrl: url}});
    return false;
  }

  static checkRole(role: string): boolean {
    const roles = JSON.parse(localStorage.getItem(Constant.CACHE_KEY.ROLES));
    return roles.includes(role);
  }
}
