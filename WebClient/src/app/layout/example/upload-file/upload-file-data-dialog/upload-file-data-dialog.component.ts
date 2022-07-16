import { ExampleExampleFileCreateCommand, ExampleExampleFileFindOneQuery, ExampleExampleFileUpdateCommand, ExampleFileApi } from './../../../../_shared/bccp-api.services';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi, ExampleExampleBasicFindOneQuery, ExampleExampleBasicCreateCommand, ExampleExampleBasicUpdateCommand } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-upload-file-data-dialog',
  templateUrl: './upload-file-data-dialog.component.html',
  styleUrls: ['./upload-file-data-dialog.component.scss']
})
export class UploadFileDataDialogComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private exampleFileApi: ExampleFileApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      name: ['', [
        ValidatorExtension.required('Tên không được để trống'),
        ValidatorExtension.specialChar('Tên không được sử dụng ký tự đặc biệt')],
      ],
      oneFile: [null],
      multiFile: [null]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new ExampleExampleFileFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.exampleFileApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue(rs.result);
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
    this.formOrgin = JSON.stringify(this.myForm.getRawValue());
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
      const createBody = new ExampleExampleFileCreateCommand();
      createBody.init(body);
      const rs = await this.exampleFileApi.create(createBody).toPromise();
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
      const updateBody = new ExampleExampleFileUpdateCommand();
      updateBody.init({
        id: this.id,
        ... body
      });
      const rs = await this.exampleFileApi.update(updateBody).toPromise();
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
    if (this.formOrgin !== JSON.stringify(this.myForm.getRawValue())) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
