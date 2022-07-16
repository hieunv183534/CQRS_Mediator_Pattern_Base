import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';

@Injectable()
export class NotificationService {
  constructor(private messageService: MessageService) {    
  }

  showMessage(type: string, message: string) {
    this.messageService.add({severity:'success', summary: 'Success', detail: message});
  }

  showNotification(type: string, message: string, widthClazz?) {
    this.messageService.add({severity:'info', summary: 'Info', detail: message});
  }

  showNotificationError(type: string, message: string) {
    this.messageService.add({severity:'error', summary: 'Error', detail: message});
  }
}
