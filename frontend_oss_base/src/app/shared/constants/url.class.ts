export class UrlConstant {
  public static readonly LOGIN = '/login';
  public static readonly LOGOUT = '/oauth/logout';
  public static readonly LIST_USER = '/users/filter';
  public static readonly DETAIL_USER = '/users';
  public static readonly ADD_USER = '/users/add';
  public static readonly UPDATE_USER = '/users/update';
  public static readonly ADD_USER_SYNC = '/users/add-user-sync';
  public static readonly REPORT_USER = '/reportUser';  
  public static readonly LIST_ROLE = '/roles';
  public static readonly SEARCH_ROLE = '/roles/search';
  public static readonly FILTER_ROLE = '/roles/filter';

  public static readonly LIST_GROUP = '/groups';
  // public static readonly LIST_ACTION =  '/action';
  public static readonly ACTION = '/actions';
  public static readonly LIST_ACTION = '/actions';
  public static readonly LIST_MENU = '/menus';
  public static readonly REPORT_ROLE = '/reportRole';
  public static readonly REPORT_GROUP = '/reportGroup';
  public static readonly REPORT_MENU = '/reportMenu';

  public static readonly UPDATE_PROFILE = '/users/updateprofile';
  public static readonly CHANGE_PASSWORD = '/users/changepassword';
  public static readonly UPLOAD_AVATAR = '/uploadFile';

  public static readonly USER_READ_SHEETS = '/users/read-sheets';
  public static readonly USER_ROLES_PARTNER = '/users/roles-partner';
  public static readonly USER_PARTNER_VALIDATE = '/users/validateImportFile';
  public static readonly USER_VALIDATE_EXPORT_FILE = '/users/downloadValidateImport';
  public static readonly USER_IMPORT_FILE = '/users/import-partner';
  public static readonly USER_SYNC_USER = '/users/sync-user';
  public static readonly OTP = 'otp';
  public static readonly TOTP = 'totp';
  public static readonly SEND_TOTP_CODE = '/totp/send-mail-totp/';


  public static readonly BUSINESS_UNIT = '/users/business-unit';


  public static readonly ADD_ACTION =  '/actions/add';
  public static readonly SEARCH_ACTION =  '/actions/search';

  public static readonly LIST_SYSTEMS = '/systems';
  public static readonly DETAIL_SYSTEM = '/systems';
  public static readonly ADD_SYSTEM = '/systems';
  public static readonly UPDATE_SYSTEM = '/systems';

  public static readonly RESET_PASSWORD = {
    SEND_EMAIL_RESER_PW: '/core/reset-password/send-mail-reset',
    CHECK_TOKEN: '/core/reset-password/check-token',
    RESET_PW: '/core/reset-password/reset'
  };
  public static readonly CONTROLLER = {
    USER: '/users',
    ENTITY: '/entities',
    GROUP: '/groups',
    ROLE: '/roles',
    MENU: '/menus',
    ACTION: '/actions'
  };
  public static readonly COMMON_METHOD = {
    GET_LIST: '/list',
    FILTER: '/filter',
    ACTIVE: '/active'
  };

}

