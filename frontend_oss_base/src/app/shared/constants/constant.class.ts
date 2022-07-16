export class Constant {

  public static API_BASE = "BASE_API";
  public static API_PMS_CORE = "PMS_CORE_API";  

  public static readonly DATE_FMT = 'dd/MM/yyyy';
  public static readonly MESSAGE_DELETE_SUCCESS = 'Xóa thành công';
  public static readonly MESSAGE_SUCCESS_SENT_TOTP_CODE = 'Gửi thành công';
  public static readonly MESSAGE_SERVER_ERROR = 'Lỗi server';
  public static readonly MESSAGE_ADD_SUCCESS = 'Created Success';
  public static readonly MESSAGE_UPDATE_SUCCESS = 'Cập nhật thành công';
  public static readonly SUCCESS = 'success';
  public static readonly ERROR = 'error';
  public static readonly TOKEN = 'token';
  public static readonly USER_INFO = 'user';
  public static readonly LOGIN_FAIL = 'login_failed';
  public static readonly DELETE = 'Xóa';
  public static readonly CREATE = 'Thêm';
  public static readonly UPDATE = 'Sửa';
  public static readonly ACTIVE = 'Active';
  public static readonly IN_ACTIVE = 'InActive';
  public static readonly LOCK = 'Lock';
  public static readonly DELETE_STATUS = 'Delete';
  public static readonly WELCOME = 'welcome';
  public static readonly OTP = 'otp';
  public static readonly TOTP = 'totp';

  //region config login
  public static readonly LOGIN = {
    MSG_KEY: {
      CAS_DISABLE: "login.message.cas_disable",
      LOGIN_FAIL: "login.message.login_failed",
      CAS_ERROR: "login.message.cas_error",
      LOGIN_SUCCESS: "login.message.login_success",
      NEED_GRANT_PERMISSION: "login.message.need_grant_permission"
    },
    ERROR_CODE: {
      INVALID_LOGIN_TYPE: -1,
      REDIRECT_TO_HOME: 1,
      VALIDATE_OTP: 2,
      GRANT_PERMISSION: 3,
    },
    PAGE: {
      INIT: '/login',
    },
    TYPE: {
      LOCAL: 1,
      CAS: 2,
    }
  };

  //endregion

  // FILE
  public static readonly REPORT_NAME = 'Report';
  // EXCEL
  public static readonly EXCEL_TYPE_1 = 'xls';
  public static readonly EXCEL_MIME_1 = 'application/vnd.ms-excel';

  public static readonly EXCEL_TYPE_2 = 'xlsx';
  public static readonly EXCEL_MIME_2 = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';

  // PDF
  public static readonly PDF_TYPE = 'pdf';
  public static readonly PDF_MIME = 'application/pdf';
  public static readonly SCREEN = {
    MENU: 'menu',
    ROLE: 'role',
    USER: 'user',
    GROUP: 'group',
  };
  public static readonly ACTION2 = {
    VIEW: 'VIEW',
    ADD: 'ADD',
    EDIT: 'EDIT',
    DELETE: 'DELETE',
    EXPORT: 'EXPORT',
    IMPORT: 'IMPORT',
    ADD_REVERT: 'ADD_REVERT',
    APPROVE: 'APPROVE',
    APPROVE_REVERT: 'APPROVE_REVERT',
    CREATE_BATCH: 'CREATE_BATCH',
    CREATE: 'CREATE',
    CONFIRM: 'CONFIRM',
  };

  public static readonly COMPONENT_TYPE = [
    {'key': 'TEXT', 'name': 'Text input', icon: 'fa fa-terminal'},
    {'key': 'NUMBER', 'name': 'Number input', icon: 'fa fa-hashtag'},
    {'key': 'RADIO', 'name': 'Radio', icon: 'fa fa-dot-circle'},
    {'key': 'SELECT', 'name': 'Dropdown', icon: 'fa fa-th-list'},
    {'key': 'DATE_TIME', 'name': 'Date-time', icon: 'fa fa-calendar-plus'},
  ];
  //region action
  public static readonly ACTION = {
    VIEW: 'VIEW',
    ADD: 'ADD',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    EXPORT: 'EXPORT',
    IMPORT: 'IMPORT'
  };
  //endregion

  public static readonly RECORD = {
    STATUS: {
      DELETE: -1,
      INACTIVE: 0,
      ACTIVE: 1,
      LOCKED: 2,
      FILTER_ALL: -99
    }
  };

  public static readonly statusOptions = [{label: "Active", value: 1}, {label: "Inactive", value: 0}];

  public static readonly commonStatusOptionsAll = [{label: "All", value: -99}, {label: "Active", value: 1}, {label: "Inactive", value: 0}, {label: "Deleted", value: -1}];
  public static readonly userStatusOptionsAll = [{label: "All", value: -99}, {label: "Active", value: 1}, {label: "Inactive", value: 0}, {label: "Deleted", value: -1}, {label: "Locked", value: 2}];

  // Upload Image
  public static readonly DEFAULT_IMG_WIDTH = 500;
  public static readonly DEFAULT_IMG_HEIGHT = 500;
  public static readonly DEFAULT_MIN_IMG_WIDTH = 10;
  public static readonly DEFAULT_MIN_IMG_HEIGHT = 10;
  public static readonly DEFAULT_MAX_IMG_WIDTH = 1024;
  public static readonly DEFAULT_MAX_IMG_HEIGHT = 1024;
  public static readonly DEFAULT_IMG_MAX_SIZE = 2048; // KB
  public static readonly DEFAULT_IMG_MIN_SIZE = 16; // KB
  public static readonly DEFAULT_IMG_TYPE = ['jpg', 'jpeg', 'png'];
  public static readonly DEFAULT_IMG_ICON_CLASS = 'upload';
  public static readonly DEFAULT_IMG_NAME = 'image';
  public static readonly DEFAULT_IMG_LABEL = 'image_label';


  public static readonly MONTH = [
    {'id': 1, 'name': 'Tháng 01'},
    {'id': 2, 'name': 'Tháng 02'},
    {'id': 3, 'name': 'Tháng 03'},
    {'id': 4, 'name': 'Tháng 04'},
    {'id': 5, 'name': 'Tháng 05'},
    {'id': 6, 'name': 'Tháng 06'},
    {'id': 7, 'name': 'Tháng 07'},
    {'id': 8, 'name': 'Tháng 08'},
    {'id': 9, 'name': 'Tháng 09'},
    {'id': 10, 'name': 'Tháng 10'},
    {'id': 11, 'name': 'Tháng 11'},
    {'id': 12, 'name': 'Tháng 12'},
  ];
  public static readonly CACHE_KEY = {
    USER_INFO: "USER_INFO",
    TOKEN: "TOKEN",
    MENU: "MENU",
    ROLES: "ROLES"
  }

  public static readonly AUTHORIZED_KEY = {
    HEADER: "Authorization",
    PREFIX: "Bearer "
  }
  public static readonly COMMON_MESSAGE = {
    CREATED: "Tạo mới thành công!",
    UPDATED: "Cập nhật thành công!",
    DELETED: "Xóa dữ liệu thành công!",
    INTERFACE: {},
  }
}
