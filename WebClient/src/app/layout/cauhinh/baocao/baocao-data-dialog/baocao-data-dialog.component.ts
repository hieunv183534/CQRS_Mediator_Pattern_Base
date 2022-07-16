import { BaocaoDataTestDialogComponent } from './baocao-data-test-dialog/baocao-data-test-dialog.component';
import { DialogSize } from './../../../../_base/servicers/dialog.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { ValidatorExtension } from '../../../../_base/extensions/validator-extension';
import { DialogMode, DialogService } from '../../../../_base/servicers/dialog.service';
import { MessageService } from '../../../../_base/servicers/message.service';
import {
  DanhMucReportManagerCreateCommand, DanhMucReportManagerFindOneQuery,
  DanhMucReportManagerParamCreateCommand, DanhMucReportManagerUpdateCommand,
  DimReportManagerApi
} from '../../../../_shared/bccp-api.services';
import { NzUploadFile } from 'ng-zorro-antd';

interface ItemData {
  id: string;
  name: string;
  age: string;
  address: string;
}

@Component({
  selector: 'app-baocao-data-dialog',
  templateUrl: './baocao-data-dialog.component.html',
  styleUrls: ['./baocao-data-dialog.component.scss']
})
export class BaocaoDataDialogComponent implements OnInit {

  // tslint:disable-next-line:no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line:no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line:no-input-rename
  @Input('parentId') parentId: number;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrigin: string;
  public filePaperUpLoad: File = null;
  public listParamsFile: File[] = [];
  public listDataSet: any[] = [];

  // file
  fileList: NzUploadFile[] = [];

  i = 0;
  editId: number | null = null;
  listOfData: DanhMucReportManagerParamCreateCommand[] = [];
  listConnection: any[] = [
    {
      value: 'DefaultConnection',
      text: 'KT1'
    },
    {
      value: 'DataWareHouse',
      text: 'DataWareHouse'
    }
  ]

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    private dimReportManagerApi: DimReportManagerApi
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      name: ['', [ValidatorExtension.required(), ValidatorExtension.space()]],
      parentId: [null],
      parentTag: [''],
      type: [2],
      fileTemplate: [null],
      dataSource: [''],
      dataType: [2],
      description: [''],
      params: this.fb.array([]),
      reportManagerDataSet: this.fb.array([]),
      reportManagerGroupBy: this.fb.array([]),
    });

    this.isLoading = true;

    if (this.id) {
      const params = new DanhMucReportManagerFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.dimReportManagerApi.findOne(params).toPromise();
      if (rs.success) {
        let valueDefault: any = rs.result;
        for (const item of valueDefault.params) {
          this.addReportParamsFormArray();
          if (item.dataType === 3) {
            try {
              item.dataDefault = new Date(item.dataDefault);
            } catch (error) {
              item.dataDefault = null;
            }
          }
        }
        for (const item of valueDefault.reportManagerDataSet) {
          this.addReportDataSetFormArray();
        }
        for (const item of valueDefault.reportManagerGroupBy) {
          this.addReportGroupbyFormArray();
        }

        this.myForm.patchValue(valueDefault);
        this.setListReportDataSetFormArray();
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') {
      this.myForm.disable();
    }
    if (this.mode === 'edit') {
      // this.myForm.get('customerCode').disable();
    }
    this.isLoading = false;
    this.saveHistoryForm();

  }

  async saveHistoryForm(): Promise<void> {
    this.formOrigin = JSON.stringify(this.myForm.value);
  }

  get reportParamsFormArray(): FormArray {
    return (this.myForm.get('params') as FormArray);
  }

  get reportDataSetFormArray(): FormArray {
    return (this.myForm.get('reportManagerDataSet') as FormArray);
  }

  setListReportDataSetFormArray(): void {
    this.listDataSet = [];
    const result = [];
    const formArray = (this.myForm.get('reportManagerDataSet') as FormArray);
    for (let i = 0; i < formArray.length; i++) {
      const item = formArray.at(i) as FormGroup;
      if (item.get('name').value) {
        result.push({
          text: item.get('name').value,
          value: item.get('id').value
        })
      }
    }
    this.listDataSet = result;
  }

  get reportGroupByFormArray(): FormArray {
    return (this.myForm.get('reportManagerGroupBy') as FormArray);
  }

  async addReportParamsFormArray(): Promise<void> {
    const newItem = this.fb.group({
      id: [null],
      reportManagerId: [null],
      name: ['', ValidatorExtension.required()],
      dataType: [1],
      // inputType: [1],
      dataDefault: [null],
      dataFileDefault: [null]
    });
    this.reportParamsFormArray.push(newItem);
  }

  async addReportDataSetFormArray(): Promise<void> {
    const newItem = this.fb.group({
      id: [null],
      reportManagerId: [null],
      name: ['', ValidatorExtension.required()],
      dataType: [1],
      sourceType: [1],
      connectString: [null, ValidatorExtension.required()],
      dataValue: [null],
    });
    this.reportDataSetFormArray.push(newItem);
    this.setListReportDataSetFormArray();
  }

  async addReportGroupbyFormArray(): Promise<void> {
    const newItem = this.fb.group({
      id: [null],
      reportManagerId: [null],
      name: ['*', ValidatorExtension.required()],
      dataSetId: [null, ValidatorExtension.required()],
      key: [null, ValidatorExtension.required()],
    });
    this.reportGroupByFormArray.push(newItem);
  }

  async removeReportParamsFormArray(index: number): Promise<void> {
    this.reportParamsFormArray.removeAt(index);
  }

  async removeReportDataSetFormArray(index: number): Promise<void> {
    const dataSetId = this.reportDataSetFormArray.at(index).get('id').value;
    if (dataSetId) {
      const indexGroupBy = this.reportGroupByFormArray.value.findIndex(x => x.dataSetId === dataSetId);
      if (indexGroupBy !== -1) {
        this.removeReportGroupbyFormArray(indexGroupBy);
      }
    }
    this.reportDataSetFormArray.removeAt(index);
    this.setListReportDataSetFormArray();
  }

  async removeReportGroupbyFormArray(index: number): Promise<void> {
    this.reportGroupByFormArray.removeAt(index);
  }

  async handleFileInput(event: Event): Promise<void> {
    const target = event.target as HTMLInputElement;
    const files = target.files as FileList;
    this.filePaperUpLoad = files.item(0);
  }

  async save(saveAndNew: boolean = false): Promise<void> {
    this.myForm.textTrim();

    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) {
      return;
    }

    // giá trị form body
    const body = this.myForm.getRawValue();

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) {
      // add
      // const formData = new FormData();
      // formData.append('file[]', this.fileList[0]);
      const bodyCreate = new DanhMucReportManagerCreateCommand();
      bodyCreate.init({
        ...body,
        parentId: this.parentId
      });
      console.log('body', body);
      console.log(bodyCreate);

      const rs = await this.dimReportManagerApi.create(bodyCreate).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        // if (saveAndNew) {
        //   this.myForm.reset();
        // } else {
        //   this.onClose.emit(body);
        // }
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else {
      const bodyUpdate = new DanhMucReportManagerUpdateCommand();
      bodyUpdate.init({
        ...body,
        id: this.id
      });
      const rs = await this.dimReportManagerApi.update(bodyUpdate).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        //this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    const formCurrentValue = this.myForm.value;
    // Object.keys(formCurrentValue).forEach((key) => (formCurrentValue[key] == null) && (formCurrentValue[key] = ''));
    if (this.formOrigin !== JSON.stringify(formCurrentValue)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) {
        return;
      }
    }
    this.onClose.emit();
  }

  getValueReportParams() {
    const paramJson = this.reportParamsFormArray.value;
    const result = {};
    for (const item of paramJson) {
      if (item.dataType === 2) {
        result[item.name] = item.dataDefault ? parseInt(item.dataDefault) : null;
      } else {
        result[item.name] = item.dataDefault;
      }
    }
    return result;
  }

  async testDataSet(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      const reportCode = this.myForm.get('name').value;
      option.title = 'Test báo cáo';
      option.size = DialogSize.medium;
      option.component = BaocaoDataTestDialogComponent;
      option.inputs = {
        reportCode: reportCode,
        reportParams: JSON.stringify(this.getValueReportParams())
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }
}
