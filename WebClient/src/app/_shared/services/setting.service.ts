import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SettingService {

  public data: SettingModel;
  constructor(private http: HttpClient) {
  }

  public init(): Promise<void> {
    return new Promise<void>(async (resolve, reject) => {
      if (this.data) {
        resolve();
      } else {
        this.http.get(environment.fileSetting).subscribe(res => {
          this.data = Object.setPrototypeOf(res, SettingModel.prototype)
          resolve();
        });
      }
    });
  }
}

export class SettingModel {
  login: boolean;
  urlApi: string;
  path: string;
  reportApi: string;
  realTimeApi: string;
  mobileApi: string;
  identity: SettingIdentityModel
}

export class SettingIdentityModel {
  authority: string;
  client_id: string;
  redirect_uri: string;
  response_type: string;
  scope: string;
  post_logout_redirect_uri: string;
  template_import_tiep_nhan_yeu_cau_url: string;
  template_import_chap_nhan_gui_url: string;
  import_tiep_nhan_yeu_cau_url: string;
  import_chap_nhan_gui_url: string;
}