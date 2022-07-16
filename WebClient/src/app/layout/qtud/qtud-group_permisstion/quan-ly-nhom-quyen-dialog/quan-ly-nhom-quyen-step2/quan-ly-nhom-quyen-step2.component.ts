import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { TableTreeConfigModel } from 'src/app/_base/models/table-tree-config-model';
import { ApplicationApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-quan-ly-nhom-quyen-step2',
  templateUrl: './quan-ly-nhom-quyen-step2.component.html',
  styleUrls: ['./quan-ly-nhom-quyen-step2.component.scss']
})
export class QuanLyNhomQuyenStep2Component implements OnInit {

  @Input() formValue: any;
  @Output() onSubmit = new EventEmitter<any>();
  @Output() onCancel = new EventEmitter<void>();
  @Output() onClose = new EventEmitter<any>();

  public listOfMenu: any[] = [];
  public listOfTask: any[] = [];
  public listMatrixData: any[] = [];

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });

  public tableTreeConfig: TableTreeConfigModel = new TableTreeConfigModel({
    keyId: 'id',
    keyParentId: 'parentId',
    collapseDefault: true,
    mapOfExpandedData: {}
  });
  constructor(
    private applicationApi: ApplicationApi
  ) { }

  async ngOnInit(): Promise<void> {
    if (this.formValue) {
      this.listMatrixData = this.tableTreeConfig.convertDataRawToDataTree(this.formValue.listMatrixData);
      this.listOfTask = this.formValue.listOfTask;
    }
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit();
  }

  async cancelForm(): Promise<void> {
    // nên confirm trước khi trở về
    this.onCancel.emit();
  }

  changeCheckedTask(item: any, taskId: any): void {
    item[`task_${taskId}`] = !item[`task_${taskId}`];
  }

  async submitForm(): Promise<void> {
    this.formValue.mapOfExpandedData = [];
    for (const root in this.tableTreeConfig.mapOfExpandedData) {
      for (const item of this.tableTreeConfig.mapOfExpandedData[root]) {
        const listTask = [];
        for (const key of this.listOfTask) {
          if (item['task_' + key.taskId]) {
            listTask.push(key.taskId);
          }
        }
        if(listTask.length > 0){
          this.formValue.mapOfExpandedData.push({
            menuId: item.code,
            listTask: listTask
          })
        }
      }
    }
    this.onSubmit.emit(this.formValue);
  }
}
