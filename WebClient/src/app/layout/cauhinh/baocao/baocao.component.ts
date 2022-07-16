import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';

import { BaocaoDataDialogComponent } from './baocao-data-dialog/baocao-data-dialog.component';
import { NzContextMenuService, NzDropdownMenuComponent, NzUploadChangeParam } from 'ng-zorro-antd';
import { ThemthumucDataDialogComponent } from './themthumuc-data-dialog/themthumuc-data-dialog.component';
import {
  DanhMucItemTypeDeleteCommand, DanhMucReportManagerChangeParentCommand,
  DanhMucReportManagerDeleteCommand,
  DanhMucReportManagerGetPagingQuery,
  DimReportManagerApi
} from '../../../_shared/bccp-api.services';
import { PagingModel } from '../../../_base/models/response-model';

export interface TreeNodeInterface {
  key: string;
  name: string;
  age?: number;
  level?: number;
  expand?: boolean;
  address?: string;
  children?: TreeNodeInterface[];
  parent?: TreeNodeInterface;
  parentTag?: string;
  fileTemplate?: string;
  isFile?: boolean;
}
@Component({
  selector: 'app-nationality',
  templateUrl: './baocao.component.html',
  styleUrls: ['./baocao.component.scss']
})

export class BaocaoComponent implements OnInit {
  public formSearch: FormGroup;
  // public listOfMapData: any[] = [
  //   {
  //     key: `1`,
  //     name: 'New folder',
  //     age: 60,
  //     address: '',
  //     isFile: false,
  //     children: [
  //       {
  //         key: `1-1`,
  //         name: 'file mẫu',
  //         age: 42,
  //         address: '',
  //         isFile: true
  //       },
  //       {
  //         key: `1-2`,
  //         name: 'Quản lý nhân viên',
  //         age: 30,
  //         address: 'Quản lý nhân viên',
  //         isFile: false,
  //         children: [
  //           {
  //             key: `1-2-1`,
  //             name: 'Danh sách nhân viên đang làm việc',
  //             age: 16,
  //             address: 'thống kê nhân viên',
  //             isFile: true
  //           }
  //         ]
  //       },
  //       {
  //         key: `1-3`,
  //         name: 'Đơn hàng',
  //         age: 72,
  //         address: 'Đơn hàng',
  //         isFile: false,
  //         children: [
  //           {
  //             key: `1-3-1`,
  //             name: 'Trong tỉnh',
  //             age: 42,
  //             address: 'Trong tỉnh',
  //             isFile: false,
  //             children: [
  //               {
  //                 key: `1-3-1-1`,
  //                 name: 'Đơn hàng trong tỉnh',
  //                 age: 25,
  //                 address: 'thống kê đơn hàng trong tỉnh theo thời gian',
  //                 isFile: true
  //               },
  //               {
  //                 key: `1-3-1-2`,
  //                 name: 'báo cáo mẫu',
  //                 age: 18,
  //                 address: '',
  //                 isFile: true
  //               }
  //             ]
  //           }
  //         ]
  //       }
  //     ]
  //   },
  //   {
  //     key: `2`,
  //     name: 'tổng thu nhập trong tháng',
  //     age: 32,
  //     address: '',
  //     isFile: true
  //   },
  //   {
  //     key: `2-3`,
  //     name: 'tổng thu nhập trong tháng',
  //     age: 32,
  //     address: '',
  //     isFile: true
  //   }
  // ];

  public listOfMapData: any[] = [];
  public mapOfExpandedData: { [key: string]: TreeNodeInterface[] } = {};
  public historyExpandNode: any = {};
  public i = 0;
  public contextMenuSelect = null;
  public contextMenuKeepItem = null;
  public isLoading = false;

  // fast edit name
  public editId: any | null = null;

  constructor(
    private dialogService: DialogService,
    private messageService: MessageService,
    private fb: FormBuilder,
    private nzContextMenuService: NzContextMenuService,
    private dimReportManagerApi: DimReportManagerApi
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      customerCode: [''],
      customerName: [''],
      posCode: ['']
    });
    // this.listOfMapData.forEach(item => {
    //   console.log('item', item);
    //   this.mapOfExpandedData[item.key] = this.convertTreeToList(item);
    // });
    // console.log('data final', this.listOfMapData);
    // console.log('data mapOfExpandedData', this.mapOfExpandedData);
    this.getData();
  }

  nest = (items, id = null, pKey = 'parentId') =>
    items
      .filter(item => item[pKey] === id)
      .map(item => ({ key: item.id, ...item, children: this.nest(items, item.id) }))

  async getData(paging: PagingModel = {page: 1, size: 99999}): Promise<void> {
    this.formSearch.textTrim();

    const params = new DanhMucReportManagerGetPagingQuery({
      ...paging
    });

    this.isLoading = true;
    const rs = await this.dimReportManagerApi.getPaging(params).toPromise();
    if (rs.success) {
      // lưu lại danh sách expand node
      this.historyExpandNode = this.getHistoryExpandNode();
      this.listOfMapData = this.nest(rs.result.data);
      this.listOfMapData.forEach(item => {
        this.mapOfExpandedData[item.key] = this.convertTreeToList(item);
      });
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  collapse(array: TreeNodeInterface[], data: TreeNodeInterface, $event: boolean): void {
    if (!$event) {
      if (data.children) {
        data.children.forEach(d => {
          // tslint:disable-next-line:no-non-null-assertion
          const target = array.find(a => a.key === d.key)!;
          target.expand = false;
          this.collapse(array, target, false);
        });
      } else {
        return;
      }
    }
  }

  convertTreeToList(root: TreeNodeInterface): TreeNodeInterface[] {
    const stack: TreeNodeInterface[] = [];
    const array: TreeNodeInterface[] = [];
    const hashMap = {};
    stack.push({
      ...root,
      level: 0,
      expand: this.historyExpandNode[root.key] ? this.historyExpandNode[root.key] : false
    });

    while (stack.length !== 0) {
      // tslint:disable-next-line:no-non-null-assertion
      const node = stack.pop()!;
      this.visitNode(node, hashMap, array);
      if (node.children) {
        for (let i = node.children.length - 1; i >= 0; i--) {
          // tslint:disable-next-line:no-non-null-assertion
          stack.push({
            ...node.children[i],
            // tslint:disable-next-line:no-non-null-assertion
            level: node.level! + 1,
            expand: this.historyExpandNode[node.children[i].key] ? this.historyExpandNode[node.children[i].key] : false,
            parent: node });
        }
      }
    }

    return array;
  }

  visitNode(node: TreeNodeInterface, hashMap: { [key: string]: boolean }, array: TreeNodeInterface[]): void {
    if (!hashMap[node.key]) {
      hashMap[node.key] = true;
      array.push(node);
    }
  }

  startEdit(id: any): void {
    this.editId = id;
  }

  stopEdit(): void {
    this.editId = null;
  }

  contextMenu($event: MouseEvent, menu: NzDropdownMenuComponent, item: TreeNodeInterface): void {
    this.nzContextMenuService.create($event, menu);
    this.contextMenuSelect = item;
  }

  stopContextMenuSelect(): void {
    this.contextMenuSelect = null;
    console.log('stop', this.contextMenuSelect);
  }

  funcSaoChep(): void {
    this.contextMenuKeepItem = this.contextMenuSelect;
  }

  funcDiChuyen(): void {
    this.contextMenuKeepItem = this.contextMenuSelect;
  }

  async funcDan(): Promise<void> {
    console.log('di chuyển: ', this.contextMenuKeepItem);
    console.log('đến: ', this.contextMenuSelect);
    const dataChangeParent = new DanhMucReportManagerChangeParentCommand();
    dataChangeParent.init({
      id: this.contextMenuKeepItem.id,
      idParent: this.contextMenuSelect ? this.contextMenuSelect.id : null
    });
    const rs = await this.dimReportManagerApi.changeParent(dataChangeParent).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Di chuyển thành công');
      this.getData();
    } else {
      this.messageService.notiMessageError('Di chuyển thất bại');
    }
    this.contextMenuKeepItem = null;
  }

  // upload file
  handleChange(info: NzUploadChangeParam): void {
    if (info.file.status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (info.file.status === 'done') {
      // this..success(`${info.file.name} file uploaded successfully`);
    } else if (info.file.status === 'error') {
      // this.msg.error(`${info.file.name} file upload failed.`);
    }
  }

  async addNewFolder(id: any = null): Promise<void> {
    let parentId = null;
    if (id) { parentId = id; }
    else {
      parentId = this.contextMenuSelect ? this.contextMenuSelect.id : null;
    }
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới thư mục';
      option.size = DialogSize.small;
      option.component = ThemthumucDataDialogComponent;
      option.inputs = {
        parentId,
        mode: DialogMode.add
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        if (value) {
          this.getData();
        }
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async RenameFolder(id: string): Promise<void> {
    console.log('item select context menu', this.contextMenuSelect);
    const dialog = this.dialogService.openDialog(option => {
      option.title = this.contextMenuSelect.type === 0 ? 'Đổi tên thư mục' : 'Đổi tên báo cáo';
      option.size = DialogSize.small;
      option.component = ThemthumucDataDialogComponent;
      option.inputs = {
        id: this.contextMenuSelect.id,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData();
      }
    });
  }

  async addNewReport(id: string): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới báo cáo';
      option.size = DialogSize.full;
      option.component = BaocaoDataDialogComponent;
      option.inputs = {
        parentId: this.contextMenuSelect ? this.contextMenuSelect.id : null,
        mode: DialogMode.add
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.getData();
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async editReport(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa báo cáo';
      option.size = DialogSize.full;
      option.component = BaocaoDataDialogComponent;
      option.inputs = {
        id: this.contextMenuSelect.id,
        mode: DialogMode.edit
      };
    }, (eventName, value: any) => {
      if (eventName === 'onClose') {
        this.getData();
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async delete(id: any = null): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa?', ' ');
    if (!result) { return; }
    // lấy list id cần xóa
    if (!id) {
      id = this.contextMenuSelect ? this.contextMenuSelect.id : null;
    }
    const params = new DanhMucReportManagerDeleteCommand();
    params.init({
      id: [id]
    });

    const rs = await this.dimReportManagerApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData();
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

  testContextMenu(object: any): void {
    console.log(object);
  }

  getHistoryExpandNode(): any {
    const objectExpand = {};
    // tslint:disable-next-line:forin
    for (const lv0 in this.mapOfExpandedData) {
      for (const item of this.mapOfExpandedData[lv0]) {
        objectExpand[item.key] = item.expand;
      }
    }
    return objectExpand;
  }

  search(): void {
    console.log(this.mapOfExpandedData);
    console.log(this.listOfMapData);
    const objectExpand = {};
    // tslint:disable-next-line:forin
    for (const lv0 in this.mapOfExpandedData) {
      console.log(this.mapOfExpandedData[lv0]);
      for (const item of this.mapOfExpandedData[lv0]) {
        objectExpand[item.key] = item.expand;
      }
    }
    console.log('data expand:', objectExpand);
  }

}
