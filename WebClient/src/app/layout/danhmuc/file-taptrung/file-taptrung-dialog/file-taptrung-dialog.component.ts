import { DanhMucFileCreateCommand, DanhMucFileFindOneQuery, DanhMucFileUpdateCommand, DimFileApi } from './../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormGroup, FormBuilder } from "@angular/forms";
import { ValidatorExtension } from "src/app/_base/extensions/validator-extension";
import { DialogService, DialogMode } from "src/app/_base/servicers/dialog.service";
import { MessageService } from "src/app/_base/servicers/message.service";
import { POSApi, DeviceApi, ExampleBasicApi, DanhMucDeviceFindOneQuery, DanhMucDeviceCreateCommand, DanhMucDeviceUpdateCommand } from "src/app/_shared/bccp-api.services";

@Component({
  selector: 'app-file-taptrung-dialog',
  templateUrl: './file-taptrung-dialog.component.html',
  styleUrls: ['./file-taptrung-dialog.component.scss']
})
export class FileTaptrungDialogComponent implements OnInit {

  @Input() mode: string;
  @Input() id: number;
  // tslint:disable-next-line: no-output-rename
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  public lstType = [
    { text: 'Mobile App', value: 1 },
    { text: 'Máy in', value: 2 },
    { text: 'File hướng dẫn', value: 3 }
  ];

  constructor(
    private fb: FormBuilder,
    public posApi: POSApi,
    private messageService: MessageService,
    private dialogService: DialogService,
    private dimFileApi: DimFileApi
  ) { }
  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      id: [1],
      name: [null, ValidatorExtension.required('Không được bỏ trống')],
      type: [null, ValidatorExtension.required('Không được bỏ trống')],
      version: [null],
      attackFile: [[]]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DanhMucFileFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.dimFileApi.findOne(params).toPromise();
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
    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // giá trị form body
    const body = this.myForm.getRawValue();

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new DanhMucFileCreateCommand();
      addData.init(body);
      const rs = await this.dimFileApi.create(body).toPromise();
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
      const updateData = new DanhMucFileUpdateCommand();
      updateData.init({
        id: this.id,
        ...body
      });
      const rs = await this.dimFileApi.update(updateData).toPromise();
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
