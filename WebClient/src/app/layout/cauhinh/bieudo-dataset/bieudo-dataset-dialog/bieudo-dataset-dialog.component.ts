import { DanhMucDashboardDatasetCreateCommand, DanhMucDashboardDatasetFindOneQuery, DanhMucDashboardDatasetUpdateCommand, DimDashboardDatasetApi } from './../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi, ExampleExampleBasicFindOneQuery, ExampleExampleBasicUpdateCommand } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-bieudo-dataset-dialog',
  templateUrl: './bieudo-dataset-dialog.component.html',
  styleUrls: ['./bieudo-dataset-dialog.component.scss']
})
export class BieudoDatasetDialogComponent implements OnInit {

  @Input() mode: string;
  @Input() id: number;
  // tslint:disable-next-line: no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  listConnection: any[] = [
    {
      value: 'DefaultConnection',
      text: 'KT1'
    },
    {
      value: 'DataWareHouse',
      text: 'DataWareHouse'
    }
  ];

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    public dimDashboardDatasetApi: DimDashboardDatasetApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      name: [null, ValidatorExtension.required('Không được để trống')],
      sourceType: [1],
      dataType: [6],
      connectString: ['DefaultConnection'],
      dataValue: [null, ValidatorExtension.required('Không được để trống')],
      cache:[0]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DanhMucDashboardDatasetFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.dimDashboardDatasetApi.findOne(params).toPromise();
      if (rs.success) {
        let dataFind: any = rs.result;
        this.myForm.patchValue(dataFind);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      // logic view edit in here
    }
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {

    const body = this.myForm.getRawValue();

    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new DanhMucDashboardDatasetCreateCommand();
      addData.init(body);
      const rs = await this.dimDashboardDatasetApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        /* nếu lỗi trả về có gắn vào một control name trên form thì
        *  hiển thị lỗi tại control đó. còn nếu không xác định được control
        *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const updateData = new DanhMucDashboardDatasetUpdateCommand();
      updateData.init({
        id: this.id,
        ...body
      });
      const rs = await this.dimDashboardDatasetApi.update(updateData).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        /* nếu lỗi trả về có gắn vào một control name trên form thì
        *  hiển thị lỗi tại control đó. còn nếu không xác định được control
        *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
