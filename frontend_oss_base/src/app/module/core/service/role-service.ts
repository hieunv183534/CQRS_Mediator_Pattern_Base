import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {Role} from '../model/role.class';

@Injectable()
export class RoleService extends BaseService {
  private static readonly CONTROLLER_NAME = UrlConstant.CONTROLLER.ROLE;

  getRole(pageNum: number, pageSize: number) {
    // return this.get( UrlConstant.LIST_ROLE + '/listRole?pageSize=' + pageSize + '&pageNum=' + pageNum);
    return this.get(UrlConstant.LIST_ROLE + '?pageSize=' + pageSize + '&pageNum=' + pageNum);
  }

  deleteRole(roleId: number[]): Observable<number[]> {
    return this.delete( UrlConstant.LIST_ROLE, roleId);
  }

  addRole(role: Role): Observable<Role> {
    return this.post( UrlConstant.LIST_ROLE, role);
  }

  updateRole(role: Role): Observable<Role> {
    return this.put( UrlConstant.LIST_ROLE, role);
  }

  getRolesListReport(data: any) {
    return this.post( UrlConstant.LIST_ROLE + '/reportRole', data, null, 'blob');
  }

  getRoles(): Observable<Role[]> {
    // return this.get( UrlConstant.LIST_ROLE);
    return this.get(UrlConstant.LIST_ROLE + '?pageSize=1&pageNum=1');
  }

  searchRole(name: any): Observable<any> {
    // return this.post( UrlConstant.SEARCH_ROLE, name);
    return this.post( UrlConstant.FILTER_ROLE, name);    
  }

  getActiveRoles(): Observable<any> {
    return this.get(RoleService.CONTROLLER_NAME + UrlConstant.COMMON_METHOD.ACTIVE);
  }

  getRolesGroupByEntity(): Observable<any> {
    return this.get(RoleService.CONTROLLER_NAME + "/roleGroupByEntity");
  }

}
