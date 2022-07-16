import { InputFilePreviewComponent } from './input-file-preview/input-file-preview.component';
import { DialogSize, DialogService } from './../../servicers/dialog.service';
import { FileApi, FileCloudFindOneQuery } from './../../../_shared/bccp-api.services';
import { InputFileModel } from './input-file.model';
import { Component, EventEmitter, forwardRef, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { NzUploadFile } from 'ng-zorro-antd';
import { environment } from 'src/environments/environment';
import { PL05_1Module } from 'src/app/layout/report/PL05_1/PL05_1.module';
import { SettingService } from 'src/app/_shared/services/setting.service';
import { UserService } from 'src/app/_shared/services/user.service';

const getBase64 = (file: File): Promise<string | ArrayBuffer | null> =>
  new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
  });

@Component({
  selector: 'input-file',
  templateUrl: './input-file.component.html',
  styleUrls: ['./input-file.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputFileComponent),
      multi: true,
    }
  ]
})
export class InputFileComponent implements OnInit, ControlValueAccessor {

  @Input() className: any = '';
  @Input() placeholder: any = 'Chọn file';
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() size = 8;
  @Input() folder: string;
  @Input() tempType = 1;

  @Output('onChange') eventOnChange = new EventEmitter<any>();

  public uploading = false;
  public controlValue: NzUploadFile[] = [];
  public showUploadList = {
    showDownloadIcon: true,
    showPreviewIcon: true,
    showRemoveIcon: !this.disabled,
  };
  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  constructor(private fileApi: FileApi,
    private settingService: SettingService,
    private dialogService: DialogService,
    private userService: UserService) { }

  ngOnInit() {

  }

  beforeUpload = (file: NzUploadFile): boolean => {
    this.fileApi.upload([{ fileName: file.name, data: file }], this.folder).subscribe(rs => {
      for (const item of rs.result) {
        this.controlValue =
          this.controlValue.concat({
            uid: item.fileNumber,
            name: item.fileName,
            status: 'done',
            size: item.fileSize,
            url: this.getPathUrl(item.fileUrl)
          });
      }

      this.eventBaseChange(this.getControlValue());
      this.eventOnChange.emit(this.getControlValue());
    });
    return false;
  };

  changeFile() {
    this.eventBaseChange(this.getControlValue());
    this.eventOnChange.emit(this.getControlValue());
  }

  async writeValue(obj: any): Promise<void> {
    if (obj) {
      if (typeof (obj) === 'string') {
        this.controlValue = JSON.parse(obj).map(item => {
          return {
            uid: item.fileNumber,
            name: item.fileName,
            status: 'done',
            size: item.fileSize,
            url: this.setPathUrl(item.fileUrl)
          };
        });
      } else if (obj instanceof Array) {
        this.controlValue = obj.map(item => {
          return {
            uid: item.fileNumber,
            name: item.fileName,
            status: 'done',
            size: item.fileSize,
            url: this.setPathUrl(item.fileUrl)
          };
        });
        this.eventBaseChange(this.getControlValue());
      }
    }
  }

  registerOnChange(fn: any) {
    this.eventBaseChange = fn;
  }

  registerOnTouched(fn: any) {
    this.eventBaseTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
    this.showUploadList.showRemoveIcon = !isDisabled;
  }

  getControlValue() {
    const result = this.controlValue.filter(x => x.status === 'done').map(x => {
      return {
        fileNumber: x.uid,
        fileName: x.name,
        fileSize: x.size,
        fileExtension: x.name.substring(x.name.lastIndexOf('.')),
        fileUrl: x.url
      };
    })
    return JSON.stringify(result);
  }

  setPathUrl(url: string) {
    return `${this.settingService.data.path}${url}&access_token=${this.userService.authorizationHeaderValue.replace('Bearer ','')}`;
  }

  getPathUrl(url: string) {
    return url.replace(this.settingService.data.path, '');
  }

  // customer
  previewImage: string | undefined = '';
  previewVisible = false;
  handlePreview = async (file: NzUploadFile) => {
    // debugger;
    // if (!file.url && !file.preview) {
    //   file.preview = await getBase64(file.originFileObj!);
    // }
    // this.previewImage = file.url || file.preview;
    this.previewVisible = true;

    const dialog = this.dialogService.openDialog(option => {
      option.title = file.name;
      option.size = DialogSize.medium;
      option.component = InputFilePreviewComponent;
      option.inputs = {
        url: file.url
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });

  };
}
