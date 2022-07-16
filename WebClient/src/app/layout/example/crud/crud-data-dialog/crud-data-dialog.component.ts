import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ExampleBasicApi, ExampleExampleBasicCreateCommand, ExampleExampleBasicFindOneQuery, ExampleExampleBasicUpdateCommand } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-crud-data-dialog',
  templateUrl: './crud-data-dialog.component.html',
  styleUrls: ['./crud-data-dialog.component.scss']
})
export class CrudDataDialogComponent implements OnInit {

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
    public exampleBasicApi: ExampleBasicApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      colText: ['', [
        ValidatorExtension.required('Ma ko duoc de trong'),
        ValidatorExtension.space('ko duoc dung dau cach'),
        ValidatorExtension.specialChar('ko dc co ky tu dc biet')],
      ],
      colNumber: [null],
      colFloat: [null],
      colSelectSingle: [null],
      colDateString: [new Date()],
      colDateTime: [new Date()]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new ExampleExampleBasicFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.exampleBasicApi.findOne(params).toPromise();
      if (rs.success) {
        let dataFind: any = rs.result;
        if(dataFind.colDateString){
          dataFind.colDateString = dataFind.colDateString.convertYYYYMMDDToDate();
        }
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
    body.colDateString = body.colDateString.toDateYYYYMMDD();
    
    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new ExampleExampleBasicCreateCommand();
      addData.init(body);
      const rs = await this.exampleBasicApi.create(body).toPromise();
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
      const updateData = new ExampleExampleBasicUpdateCommand();
      updateData.init({
        id: this.id,
        ...body
      });
      const rs = await this.exampleBasicApi.update(updateData).toPromise();
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
