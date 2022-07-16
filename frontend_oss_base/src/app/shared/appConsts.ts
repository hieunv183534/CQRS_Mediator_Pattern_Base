export class AppConsts {
  static api: Api;
  static pmsCoreApi: Api;
  static pageSize: {
    size: any
  };
  static page: { basePage: number };
  static defaultPage: { defaultBasePage: number };  
}

export class Api {
  baseUrl: string; 
  partnerUrl: string; 
  assetCDNUrl: string;
  ossUserUrl: string;
  casUrl: string;
};