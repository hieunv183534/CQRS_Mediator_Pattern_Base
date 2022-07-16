import * as uuid from 'uuid';
import {formatDate} from '@angular/common';
import { Router } from '@angular/router';

export class Util {

  static genRequestId() {
    return uuid.v4();
  }

  static genRequestDate() {
    return formatDate(new Date(), 'yyyyMMddHHmmss', 'en_US');
  }

  static convertStatus(status: number) {
    if (status == -99) {
      return "Không xác định";
    } else if (status == 0) {
      return "Không hoạt động";
    } else if (status == 1) {
      return "Hoạt động";
    } else if (status == -1) {
      return "Đã xóa";
    } else {
      return "Không xác định";
    }
  }

  static reloadCurrentRoute(router: Router) {
    let currentUrl = router.url;
    router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        router.navigate([currentUrl]);
    });
  }
}
