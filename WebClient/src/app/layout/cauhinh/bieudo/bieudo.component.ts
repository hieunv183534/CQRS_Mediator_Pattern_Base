import { RoleApi } from 'src/app/_shared/bccp-api.services';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import {
  DanhMucDashboardSettingDeleteCommand,
  DanhMucDashboardSettingGetPagingQuery,
  DanhMucDashboardSettingGetPagingQueryResult, DanhMucDashboardSettingMoveCommand, DimDashboardApi
} from '../../../_shared/bccp-api.services';
import { BieudoDataDialogComponent } from './bieudo-data-dialog/bieudo-data-dialog.component';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-nationality',
  templateUrl: './bieudo.component.html',
  styleUrls: ['./bieudo.component.scss']
})

export class BieudoComponent implements OnInit {
  public formSearch: FormGroup;

  public listOfData: DanhMucDashboardSettingGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel = {
    count: 0
  };

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  public lstStatus: any[] = [
    {value: 0, text: 'Tất cả'},
    {value: 1, text: 'Đang sử dụng'},
    {value: 2, text: 'Đã xóa'}
  ];

  public lstType: any[] = [
    {value: 1, text: 'Biểu đồ cột dọc (có tổng)'},
    {value: 2, text: 'Biểu đồ cột ngang'},
    {value: 3, text: 'Biểu đồ tròn'},
    {value: 4, text: 'Biểu đồ đường'},
    {value: 5, text: 'Biểu đồ cột dọc'},
    {value: 6, text: 'Biểu đồ bảng'},
    {value: 7, text: 'Biểu đồ bảng (theo dữ liệu gốc)'},

    {value: 100, text: 'Biểu đồ Custom sản lượng dịch vụ'},
    {value: 101, text: 'Biểu đồ Custom kiểm soát xe'},
    {value: 102, text: 'Biểu đồ Custom sản lượng theo tỉnh'},
    {value: 103, text: 'Biểu đồ Custom sản lượng chiều đi'},
    {value: 104, text: 'Biểu đồ Custom sản lượng chiều đến'},
    {value: 105, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn trái'},
    {value: 106, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn phải'},
    {value: 107, text: 'Biểu đồ Custom cảnh báo chậm toàn trình'},
    {value: 108, text: 'Biểu đồ Custom sản lượng tồn chưa khai thác'},
    {value: 109, text: 'Biểu đồ Custom tỉ lệ toàn trình liên tỉnh 2'},
    {value: 110, text: 'Biểu đồ Custom tỉ lệ toàn trình nội tỉnh 2'},
    {value: 111, text: 'Biểu đồ Custom tỉ lệ toàn trình nội thành 2'},
    {value: 112, text: 'Biểu đồ Custom tỉ lệ toàn trình 4vp 2'},
    {value: 113, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn trái (Cục)'},
    {value: 114, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn phải (Cục)'},
  ];

  constructor(
    private dialogService: DialogService,
    private messageService: MessageService,
    private fb: FormBuilder,
    private dimDashboardApi: DimDashboardApi,
    public roleApi : RoleApi
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      code: [''],
      name: [''],
      type: [''],
      role: [null]
    });
    this.getData();
  }

  async getData(paging: PagingModel = {page: 1, size: 1000}): Promise<void> {
    this.formSearch.textTrim();

    const formData = this.formSearch.getRawValue();

    const where = {and: []};
    const params = new DanhMucDashboardSettingGetPagingQuery({
      ...paging
    });

    if (formData.code) {
      where.and.push({code: {like: formData.code}});
    }

    if (formData.name) {
      where.and.push({name: {like: formData.name}});
    }

    if (formData.type) {
      where.and.push({type: formData.type});
    }

    if (formData.role) {
      params.roleId = formData.role;
    }

    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }

    params.order = {
      index: true,
    };

    this.isLoading = true;
    const rs = await this.dimDashboardApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }

  async addDataDialog(): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Thêm mới biểu đồ';
      option.size = DialogSize.medium;
      option.component = BieudoDataDialogComponent;
      option.inputs = {
        data: null,
        mode: DialogMode.add
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          this.getData({...this.paging, page: 1});
        }
      }
    });
  }

  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) {
      return;
    }

    const params = new DanhMucDashboardSettingDeleteCommand({
      id: listId
    });
    const rs = await this.dimDashboardApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

  async show(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Chi tiết biểu đồ';
      option.size = DialogSize.medium;
      option.component = BieudoDataDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.view
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async edit(id: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Sửa thông tin biểu đồ';
      option.size = DialogSize.medium;
      option.component = BieudoDataDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.edit
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        this.getData(this.paging);
      }
    });
  }

  async editBtn(): Promise<void> {
    const arrSelected = this.tableConfig.getItemSelectedArray();
    if (arrSelected.length > 1) {
      this.messageService.notiMessageWarning('Chỉ được chọn 1 biểu đồ');
      return;
    } else if (arrSelected.length < 1) {
      this.messageService.notiMessageWarning('Chưa chọn biểu đồ');
      return;
    }
    this.edit(arrSelected[0]);
  }

  renderTextLoaiBieuDo(type: number): void {
    return this.lstType.find(x => x.value === type)?.text;
  }

  async onDrop(event: CdkDragDrop<string[]>): Promise<void> {
    const previousIndex = event.previousIndex;
    const currentIndex = event.currentIndex;

    if (previousIndex === currentIndex) {
      return ;
    }

    const subCurrentIndex = currentIndex > previousIndex ? currentIndex : currentIndex - 1;

    const beforeItem = this.listOfData[subCurrentIndex];
    const afterItem = this.listOfData[subCurrentIndex + 1];

    let beforeId: number = null;
    let afterId: number = null;

    if (currentIndex === 0) {
      beforeId = null;
      afterId = afterItem.id;
    } else if (currentIndex === this.listOfData.length - 1) {
      beforeId = beforeItem.id;
      afterId = null;
    } else {
      beforeId = beforeItem.id;
      afterId = afterItem.id;
    }

    const itemMove = this.listOfData[previousIndex];
    const itemMoveId = this.listOfData[previousIndex].id;

    this.listOfData.splice(currentIndex, 0, this.listOfData.splice(previousIndex, 1)[0]);

    const params = new DanhMucDashboardSettingMoveCommand({
      currentId: itemMoveId,
      beforeId,
      afterId
    });
    const rs = await this.dimDashboardApi.move(params).toPromise();
    if (rs.success) {
      this.listOfData.find(x => x.id === itemMoveId).index = rs.result;
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }
}
