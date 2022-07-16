import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';

@Injectable()
export class SystemService  extends  BaseService {
  getAll(): Observable<any> {     
     return this.get(UrlConstant.LIST_SYSTEMS);
  }
  addSystem(system): Observable<any> {
     return this.post(  UrlConstant.ADD_SYSTEM , system);
  }
  deleteSystem(id: number[]): Observable<any> {
    return this.delete(UrlConstant.LIST_SYSTEMS, id);
  }
  updateSystem(system): Observable<any> {
    return this.put(  UrlConstant.UPDATE_SYSTEM , system);
  }  
}
