import {Injectable, Inject, Optional} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {UrlConstant} from 'src/app/shared/constants/url.class';
import {EntityDto, EntityFilter} from "../model/entity.class";
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { AppConfigService } from 'src/app-config.service';

@Injectable()
export class EntityService extends BaseService {

  constructor(
    public httpClient: HttpClient,
    protected configService: AppConfigService,
      @Inject('apiName') @Optional() public apiName: string
      ) {
      super(httpClient, configService);
      this.apiName = apiName;
      this.setApi(this.apiName);
  }  

  filter(entityFilter: EntityFilter) {
    return this.post(UrlConstant.CONTROLLER.ENTITY + UrlConstant.COMMON_METHOD.FILTER, entityFilter);
  }

  getActiveEntity() {
    return this.get(UrlConstant.CONTROLLER.ENTITY + UrlConstant.COMMON_METHOD.ACTIVE);
  }

  getById(entityId: number) {
    return this.get(UrlConstant.CONTROLLER.ENTITY + "/" + entityId);
  }

  add(value): Observable<any> {
    return this.post(UrlConstant.CONTROLLER.ENTITY, value);
  }

  deleteEntity(entityId: number): Observable<any> {
    // Khi delete mot ban ghi thi ta update status = -1
    // Don gian chi goi lenh put
    return this.delete(UrlConstant.CONTROLLER.ENTITY, entityId);
  }

  updateEntity(value): Observable<any> {
    return this.put(UrlConstant.CONTROLLER.ENTITY, value);
  }

}

