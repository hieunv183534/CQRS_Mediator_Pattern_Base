import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';

@Injectable()
export class ActionService extends BaseService {
  getAction(pageSize: number, pageNum: number) {
    // return this.get(UrlConstant.LIST_ACTION + '/listAction?pageSize=' + pageSize + '&pageNum=' + pageNum);
    return this.get(UrlConstant.LIST_ACTION + '/list?pageSize=' + pageSize + '&pageNum=' + pageNum);
  }

  getListAction() {
    return this.get(UrlConstant.LIST_ACTION);
  }

  getListActiveAction() {
    return this.get(UrlConstant.LIST_ACTION + UrlConstant.COMMON_METHOD.ACTIVE);
  }

  getActionByScreen(screen: string) {
    return this.getWithAsync(UrlConstant.LIST_ACTION + '/list-action?screen=' + screen);
  }

  addActions(actionModel: any): Observable<any> {
    return this.post(UrlConstant.ADD_ACTION, actionModel);
  }

  deleteAction(actionModel: any): Observable<any> {
    // Khi delete mot ban ghi thi ta update status = -1
    // Don gian chi goi lenh put
    return this.put(UrlConstant.ACTION, actionModel);
  }

  updateActions(actionModel: any): Observable<any> {
    return this.put(UrlConstant.ACTION, actionModel);
  }

  searchAction(name: any): Observable<any> {
    return this.post(UrlConstant.SEARCH_ACTION, name);
  }
}

