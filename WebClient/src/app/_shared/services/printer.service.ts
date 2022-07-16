import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { LocationStrategy } from '@angular/common';
import { ResponseModel } from '../../_base/models/response-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrinterService {
  localApiBase = 'http://127.0.0.1:6711';

  constructor(
    private http: HttpClient
  ) {
  }

  public printToPrinter<T>(params: { url: string, printerName: string, optionPrint: any }): Promise<ResponseModel<T>> {
    const api = this.http.get<T>(this.localApiBase + `/print`, {params: this.stringifyParams(params)});
    return this.bindResponseApi(api);
  }

  public getIp<T>(): Promise<any> {
    return new Promise((resolve, reject) => {
      const api = this.http.get<any>(this.localApiBase + `/getIp`, { params: {} })
        .subscribe(data => {
          resolve(data.data);
        });
    });
  }

  public getPrinters<T>(): Promise<any> {
    return new Promise((resolve, reject) => {
      const api = this.http.get<any>(this.localApiBase + `/getPrinters`, { params: {} })
        .subscribe(data => {
          resolve(data.data);
        });
    });
  }

  public getPcName<T>(): Promise<any> {
    return new Promise((resolve, reject) => {
      const api = this.http.get<any>(this.localApiBase + `/getPcName`, { params: {} })
        .subscribe(data => {
          resolve(data.data);
        });
    });
  }

  public async bindResponseApi<T>(api: Observable<T>): Promise<ResponseModel<T>> {
    const data = new ResponseModel<T>();
    await api.toPromise()
      .then(value => data.result = value)
      .catch((err: any) => {
        if (err instanceof HttpErrorResponse) {
          data.error = err.error.errors;
        } else {
          data.error = {'': ['notFound']};
          console.log('notFound', err);
        }
      });
    return data;
  }

  protected stringifyParams(params: any): any {
    if (!params) {
      return undefined;
    }
    const paramsCopy = JSON.parse(JSON.stringify(params, (key, value) => {
      if (value !== null) {
        return value;
      } else {
        return '';
      }
    }));
    Object.keys(paramsCopy).forEach(key => {
      if (typeof paramsCopy[key] === 'object') {
        paramsCopy[key] = JSON.stringify(paramsCopy[key], (k, value) => {
          if (value !== null) {
            return value;
          } else {
            return '';
          }
        });
      }
    });
    return paramsCopy;
  }
}
