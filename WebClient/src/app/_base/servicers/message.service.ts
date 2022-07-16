import { NzMessageService } from 'ng-zorro-antd/message';
import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(
    private message: NzMessageService,
    private notification: NzNotificationService
  ) { }



  public notiMessageSuccess(content: string): void {
    this.message.success(content);
  }

  public notiMessageError(content: any): void {
    if (typeof content === 'string') {
      if (!content) {
        return;
      }
      this.message.error(content);
    } else if (content instanceof Array) {
      const lstMessageAlert: string[] = [];
      for (const key of content) {
        // tslint:disable-next-line: prefer-for-of
        for (let index = 0; index < content[key].length; index++) {
          const value = content[key][index];
          lstMessageAlert.push(value);
        }
      }
      this.message.error(lstMessageAlert.join('/n'));
    } else if (content instanceof Object) {
      const lstMessageAlert: string[] = [];
      for (const key in content) {
        // tslint:disable-next-line: prefer-for-of
        for (let index = 0; index < content[key].length; index++) {
          const value = content[key][index];
          lstMessageAlert.push(value);
        }
      }
      this.message.error(lstMessageAlert.join('/n'));
    }
  }

  public notiMessageWarning(content: string): void {
    this.message.warning(content);
  }

  public showNotification(conent: string): void {
    this.notification.success('Thông báo', conent);
  }

}
