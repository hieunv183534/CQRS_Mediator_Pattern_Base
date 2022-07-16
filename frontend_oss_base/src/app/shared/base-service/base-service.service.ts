import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AppConfigService} from '../../../app-config.service';
import {Constant} from '../constants/constant.class';
import { Api } from '../appConsts';

@Injectable()
export class BaseService {
  api: Api;

  constructor(
    public httpClient: HttpClient,
    protected configService: AppConfigService    
  ) {    
    this.api = this.configService.getConfig().api; // default api
  }

  protected setApi(apiName: string) {
    switch(apiName) {
      case Constant.API_BASE:
        this.api = this.configService.getConfig().api;
        break;
      case Constant.API_PMS_CORE:
        this.api = this.configService.getConfig().pmsCoreApi;
        break;
      default:        
        this.api = this.configService.getConfig().api;
        break;
    }
  }

  get(url: string, params?: {}, responseType?: string): Observable<any> {
    switch (responseType) {
      case 'text':
        return this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params,
          responseType: 'text',
        });
      case 'blob':
        return this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params,
          responseType: 'blob',
        });
      default:
        return this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params
        });
    }
  }

  async getWithAsync(url: string, params?: {}, responseType?: string) {
    switch (responseType) {
      case 'text':
        return await this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params,
          responseType: 'text',
        }).toPromise();
      case 'blob':
        return await this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params,
          responseType: 'blob',
        }).toPromise();
      case 'arraybuffer':
        return await this.httpClient.post(this.api.baseUrl + url, {
          headers: this.createHeaders() || {},
          responseType: 'arraybuffer',
          params
        }).toPromise();
      default:
        return await this.httpClient.get(this.api.baseUrl + url, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params
        }).toPromise();
    }
  }

  /**
   * Create a new entity.
   * @param url the api url
   * @param data the entity to create
   */
  post(url: string, data: any, params?: {}, responseType?: string): Observable<any> {
    switch (responseType) {
      case 'text':
        return this.httpClient.post(this.api.baseUrl + url, data, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          responseType: 'text',
          params
        });
      case 'blob':
        return this.httpClient.post(this.api.baseUrl + url, data, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          responseType: 'blob',
          params
        });
      default:
        return this.httpClient.post(this.api.baseUrl + url, data, {
          headers: this.createHeaders().set('skipLoading', 'true') || {},
          params
        });
    }
  }

  /**
   * Update an entity.
   * @param url the api url
   * @param data the entity to be updated
   */
  put(url: string, data: any, responseType?: string): Observable<any> {
    switch (responseType) {
      case 'text':
        return this.httpClient.put(this.api.baseUrl + url, data, {
          headers: this.createHeaders() || {},
          responseType: 'text'
        });
      default:
        return this.httpClient.put(this.api.baseUrl + url, data, {
          headers: this.createHeaders() || {},
        });
    }
  }

  /**
   * Delete an entity.
   * @param url the api url
   * @param id the entity id to be deleted
   */
  delete(url: string, id: any, responseType?: string): Observable<any> {
    switch (responseType) {
      case 'text':
        return this.httpClient.delete(this.api.baseUrl + url + "/" + id, {
          headers: this.createHeaders() || {},
          responseType: 'text'
        });
      default:
        return this.httpClient.delete(this.api.baseUrl + url + "/" + id, {
          headers: this.createHeaders() || {},
        });
    }
  }

  public createHeaders() {
    // Why "authorization": see CustomLogoutSuccessHandler on server
    return new HttpHeaders().set(Constant.AUTHORIZED_KEY.HEADER, this.getToken());
  }

  private getToken() {
    return localStorage.getItem(Constant.CACHE_KEY.TOKEN);
  }

}
