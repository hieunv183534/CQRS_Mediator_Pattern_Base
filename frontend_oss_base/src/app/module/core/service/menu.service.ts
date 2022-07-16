import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {Menu} from '../model/menu.class';
import {Constant} from "src/app/shared/constants/constant.class";

@Injectable()
export class MenuService extends BaseService {
  private readonly CONTROLLER_URL = UrlConstant.CONTROLLER.MENU;

  getMenu(): Observable<Menu[]> {
    return this.get(UrlConstant.LIST_MENU);
  }

  addMenu(menu: Menu): Observable<Menu> {
    return this.post(UrlConstant.LIST_MENU, menu);
  }

  deleteMenu(id: number[]): Observable<number[]> {
    return this.delete(UrlConstant.LIST_MENU , id);
  }

  updateMenu(menu: Menu): Observable<Menu> {
    return this.put(UrlConstant.LIST_MENU, menu);
  }

  getMenuByUser(): Observable<Menu[]> {
    return this.get(UrlConstant.LIST_MENU + '/username');
  }

  getMenuTreeByUser(username: string): Observable<Menu[]> {
    // return this.get(UrlConstant.LIST_MENU + '/getMenu?username=' + username);
    return this.get(UrlConstant.LIST_MENU + '/getMenu?username=' + username);
  }

  getMenusListReport(data: any) {
    return this.post(UrlConstant.LIST_MENU + '/reportMenu', data, null, 'blob');
  }

  getAll(): Observable<any> {
    var result = this.post(UrlConstant.LIST_MENU + '/filter', {status: Constant.RECORD.STATUS.FILTER_ALL});
    return result;
    // return this.get(UrlConstant.LIST_MENU + '/list', 'text');
  }

  getAllMenuTree(): Observable<any> {
    var result = this.post(UrlConstant.LIST_MENU + '/getMenuTree', {status: Constant.RECORD.STATUS.FILTER_ALL});
    return result;
    // return this.get(UrlConstant.LIST_MENU + '/list', 'text');
  }
}
