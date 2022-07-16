import { takeUntil, filter } from 'rxjs/operators';
import { DialogModal, DialogConfigModal } from './../models/dialog-model';
import { Injectable, TemplateRef, EventEmitter } from '@angular/core';
import { NzModalService, NzMessageService, ModalConfig, NzModalRef } from 'ng-zorro-antd';
import { Subject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DialogService {

  private listDialog: DialogModal<any>[] = [];

  constructor(private modalService: NzModalService
  ) { }

  public confirm(title: string, content: string) {
    return new Promise<boolean>((resolve, reject) => {
      this.modalService.confirm({
        nzTitle: title,
        nzContent: content,
        nzOnOk: () => resolve(true),
        nzOnCancel: () => resolve(false)
      });
    });
  }

  public error(title: string, content: string) {
    return new Promise<boolean>((resolve, reject) => {
      this.modalService.error({
        nzTitle: title,
        nzContent: content,
        nzClosable: false,
        nzKeyboard: false,
        nzOnOk: () => resolve(true)
      });
    });
  }

  public errorByApi(content: any) {
    return new Promise<boolean>((resolve, reject) => {

      if (typeof content === 'string') {
        this.modalService.error({
          nzTitle: '',
          nzContent: content,
          nzOnOk: () => resolve(true)
        });
      } else if (content instanceof Array) {
        const lstMessageAlert: string[] = [];
        for (const key of content) {
          // tslint:disable-next-line: prefer-for-of
          for (let index = 0; index < content[key].length; index++) {
            const value = content[key][index];
            lstMessageAlert.push(value);
          }
        }
        this.modalService.error({
          nzTitle: '',
          nzContent: lstMessageAlert.join('/n'),
          nzOnOk: () => resolve(true)
        });
      } else if (content instanceof Object) {
        const lstMessageAlert: string[] = [];
        for (const key in content) {
          // tslint:disable-next-line: prefer-for-of
          for (let index = 0; index < content[key].length; index++) {
            const value = content[key][index];
            lstMessageAlert.push(value);
          }
        }

        this.modalService.error({
          nzTitle: '',
          nzContent: lstMessageAlert.join('/n'),
          nzOnOk: () => resolve(true)
        });
      }
    });
  }

  public confirmDeleteMulti() {
    return new Promise<boolean>((resolve, _) => {
      this.modalService.confirm({
        nzTitle: 'Bạn có chắc chắn muốn xóa những dữ liệu mà bạn đã chọn không không',
        nzContent: 'Khi bạn nhấn OK, những dữ liệu này sẽ bị xóa khỏi hệ thống',
        nzOnOk: () => resolve(true),
        nzOnCancel: () => resolve(false)
      });
    });
  }

  public openDialog(options: (options: DialogConfigModal) => void, onEmitEvent: (eventName: string, eventValue: any) => void = null) {
    const modalConfig: DialogConfigModal = {
      size: DialogSize.medium,
      component: null,
      inputs: {},
      title: "",
      escClose: false
    };
    if (options) {
      options(modalConfig);
    }

    // create dialog
    const modal: NzModalRef<any> = this.modalService.create({
      nzTitle: modalConfig.title,
      nzContent: modalConfig.component,
      nzComponentParams: modalConfig.inputs,
      nzClosable: false,
      nzKeyboard: modalConfig.escClose,
      nzFooter: null,
      nzClassName: modalConfig.size
    });

    // create dialog data
    const guidId = Date.now();
    const dialogData = { id: guidId, dialog: modal };
    this.listDialog.push(dialogData);
    // subscribe Event
    if (onEmitEvent) {
      for (const keyName in modal.componentInstance) {
        if (modal.componentInstance[keyName] instanceof EventEmitter) {
          modal.componentInstance[keyName].subscribe((value: any) => {
            onEmitEvent(keyName, value);
          });
        }
      }
    }
    return dialogData;
  }

  public closeDialogById(id: number) {
    const index = this.listDialog.findIndex(x => x.id === id);
    if (index !== -1) {
      this.listDialog[index].dialog.destroy();
      this.listDialog.splice(index, 1);
    }
  }

  public closeDialog(component: any) {
    const index = this.listDialog.findIndex(x => x.dialog.getContentComponent() === component);
    if (index !== -1) {
      this.listDialog[index].dialog.destroy();
      this.listDialog.splice(index, 1);
    }
  }

  public closeAllDialog() {
    for (const dialog of this.listDialog) {
      dialog.dialog.destroy();
    }
    this.listDialog = [];
  }
}

export enum DialogSize {
  small = 'dialog-ms',
  medium = 'dialog-md',
  large = 'dialog-lg',
  xlarge = 'dialog-max-lg',
  full = 'dialog-full'
}

export enum DialogMode {
  view = 'view',
  add = 'add',
  edit = 'edit',
  modify = 'modify',
  apply = 'apply',
  confirm = 'dialog-full',
  next = 'next',
  accept = 'accept',
  cancel = 'cancel',
  delete = 'delete',
  destroy = 'destroy',
  print = 'print',
  dowload = 'dowload'
}