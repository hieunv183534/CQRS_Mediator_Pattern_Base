import { DanhMucHolidayCreateCommand, DanhMucHolidayUpdateCommand, HolidayApi } from './../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DimTransportApi, DimTransportGroupApi, ExampleExampleBasicFindOneQuery } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-ngay-nghi-data',
  templateUrl: './ngay-nghi-data.component.html',
  styleUrls: ['./ngay-nghi-data.component.scss']
})
export class NgayNghiDataComponent implements OnInit {

  @Input() mode: string;
  @Input() id: number;
  // tslint:disable-next-line: no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    private dimTransportApi: DimTransportApi,
    public dimTransportGroupApi: DimTransportGroupApi,
    private holidayApi: HolidayApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      holidayCode: [null, ValidatorExtension.required('không được để trống')],
      holidayName: [null, ValidatorExtension.required('không được để trống')],
      holidayDate: [null, ValidatorExtension.required('không được để trống')]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new ExampleExampleBasicFindOneQuery({
        where: { and: [{ holidayCode: this.id }] }
      });
      const rs = await this.holidayApi.findOne(params).toPromise();
      if (rs.success) {
        let dataFind: any = rs.result;
        this.myForm.patchValue(dataFind);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      this.myForm.get('holidayCode').disable();
    }
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // giá trị form body
    const body = this.myForm.getRawValue();

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new DanhMucHolidayCreateCommand();
      addData.init(body);
      const rs = await this.holidayApi.create(body).toPromise();
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
      const updateData = new DanhMucHolidayUpdateCommand();
      updateData.init({
        holidayCode: this.id,
        ...body
      });
      const rs = await this.holidayApi.update(updateData).toPromise();
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
