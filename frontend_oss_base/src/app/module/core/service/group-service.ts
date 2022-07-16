import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {Group} from '../model/group.class';
import { Constant } from 'src/app/shared/constants/constant.class';

@Injectable()
export class GroupService extends BaseService {
  /* getGroup(pageNum: number, pageSize: number) {
    return this.get( UrlConstant.LIST_GROUP + '/listGroup?pageSize=' + pageSize + '&pageNum=' + pageNum );
  } */

  getGroup(searchStr) {
    return this.post( UrlConstant.LIST_GROUP + '/filter', {name: searchStr, status: Constant.RECORD.STATUS.FILTER_ALL} );
  }

  deleteGroup(id: number[]): Observable<number> {
    return this.delete( UrlConstant.LIST_GROUP , id);
  }

  addGroup(group: Group): Observable<Group> {
    return this.post( UrlConstant.LIST_GROUP, group);
  }

  updateGroup(group: Group): Observable<Group> {
    return this.put( UrlConstant.LIST_GROUP, group);
  }

  setGroupRoles(groupId, roles) {
    return this.post(UrlConstant.LIST_GROUP + "/setGroupsRole", {groupId: groupId, roles: roles});
  }

  getGroupsListReport(data: any) {
    return this.post( UrlConstant.LIST_GROUP + '/reportGroup', data, null, 'blob');
  }
  getGroups(data: any): Observable<any> {
    return this.post( UrlConstant.LIST_GROUP + "/filter", data);
  }
}


