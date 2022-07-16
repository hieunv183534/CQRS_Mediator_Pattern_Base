import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { DialogMode, DialogService } from '../../../../_base/servicers/dialog.service';
import { MessageService } from '../../../../_base/servicers/message.service';
import {
  DanhMucDashboardPermisionCreateCommand,
  DanhMucDashboardPermisionGetPagingQueryResult,
  DanhMucDashboardSettingCreateCommand,
  DanhMucDashboardSettingFindOneQuery,
  DanhMucPOSGetPagingQueryResult,
  DimDashboardApi
} from '../../../../_shared/bccp-api.services';
import { PagingModel } from '../../../../_base/models/response-model';


// tslint:disable-next-line:class-name
interface phanQuyenBieuDo {
  isPermissionAll: boolean;
  listPermisson: any[];
}


@Component({
  selector: 'app-bieudo-data-dialog',
  templateUrl: './bieudo-data-dialog.component.html',
  styleUrls: ['./bieudo-data-dialog.component.scss']
})

export class BieudoDataDialogComponent implements OnInit {

  // tslint:disable-next-line:no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line:no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public formThongTinCoBanBieuDoValue: any;
  public formThongTinCoBanBieuDoError: any;
  public formPhanQuyenBieuDoValue: any;

  public isLoading = true;
  public isSubmit = false;
  public formOrigin: string;

  // steps
  public current = 0;

  // đơn vị sử dụng
  public listOfData: DanhMucDashboardPermisionGetPagingQueryResult[] = [];
  public paging: PagingModel = {
    count: 0
  };

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    private dimDashboardApi: DimDashboardApi
  ) {
  }

  pre(): void {
    this.current -= 1;
  }

  next(): void {
    this.current += 1;
  }

  async ngOnInit(): Promise<void> {

    this.isLoading = true;
    if (this.id) {
      const params = new DanhMucDashboardSettingFindOneQuery({
        id: this.id
      });
      const rs = await this.dimDashboardApi.findOne(params).toPromise();
      if (rs.success) {
        this.formThongTinCoBanBieuDoValue = {
          ...this.formThongTinCoBanBieuDoValue,
          ...rs.result
        };
        this.formPhanQuyenBieuDoValue = {
          ...rs.result
        };
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') {
      // this.myForm.disable();
    }
    if (this.mode === 'edit') {
      // this.myForm.get('code').disable();
    }
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrigin = JSON.stringify({
      ...this.formThongTinCoBanBieuDoValue,
      ...this.formPhanQuyenBieuDoValue
    });
  }

  async formThongTinCoBanBieuDoSubmit(value): Promise<void> {
    this.formThongTinCoBanBieuDoValue = value;
    console.log(this.formThongTinCoBanBieuDoValue);
    this.current++;
    // this.stepCurent++;
  }

  async preStep(value: phanQuyenBieuDo): Promise<void> {
    this.formPhanQuyenBieuDoValue = value;
    this.current--;
  }

  async formPhanQuyenBieuDoSubmit(value: phanQuyenBieuDo): Promise<void> {
    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;

    this.formPhanQuyenBieuDoValue = value;

    // tslint:disable-next-line:no-debugger
    const listPer = [];
    for (const item of value.listPermisson) {
      listPer.push(new DanhMucDashboardPermisionCreateCommand({
        roleId: item.id
      }));
    }

    if (this.mode === DialogMode.add) {
      // add
      // giá trị form body
      const bodyCreate = new DanhMucDashboardSettingCreateCommand();
      bodyCreate.init({
        ...this.formThongTinCoBanBieuDoValue,
        dashboardPermision: listPer
      });

      const rs = await this.dimDashboardApi.create(bodyCreate).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(bodyCreate);
      } else {
        this.current = 0;
        this.formThongTinCoBanBieuDoError = rs.error;
        this.messageService.notiMessageError('Mã đã tồn tại');
      }
    } else {
      // giá trị form body
      const bodyUpdate = new DanhMucDashboardSettingCreateCommand();
      bodyUpdate.init({
        id: this.id,
        ...this.formThongTinCoBanBieuDoValue,
        dashboardPermision: listPer
      });

      const rs = await this.dimDashboardApi.update(bodyUpdate).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Cập nhật dữ liệu thành công');
        this.onClose.emit(bodyUpdate);
      } else {
        // this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    const formCurrentValue = {
      ...this.formThongTinCoBanBieuDoValue,
      ...this.formPhanQuyenBieuDoValue
    };
    if (this.mode !== DialogMode.view && this.formOrigin !== JSON.stringify(formCurrentValue)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) {
        return;
      }
    }
    this.onClose.emit();
  }

}
