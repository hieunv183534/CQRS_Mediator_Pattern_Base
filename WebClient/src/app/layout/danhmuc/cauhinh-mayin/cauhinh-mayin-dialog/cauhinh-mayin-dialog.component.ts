import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DanhMucReportManagerPrinterCreateCommand, DanhMucReportManagerPrinterFindOneQuery, DanhMucReportManagerPrinterUpdateCommand, DeviceApi, DimReportManagePrinterCboApi, DimReportManagerApi, DimReportManagerPrinterApi, ExampleBasicApi, POSApi } from 'src/app/_shared/bccp-api.services';
import { PrinterService } from 'src/app/_shared/services/printer.service';
import { DanhSachMayInComponent } from './danh-sach-may-in/danh-sach-may-in.component';

@Component({
  selector: 'app-cauhinh-mayin-dialog',
  templateUrl: './cauhinh-mayin-dialog.component.html',
  styleUrls: ['./cauhinh-mayin-dialog.component.scss']
})
export class CauhinhMayinDialogComponent implements OnInit {
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
    public posApi: POSApi,
    private messageService: MessageService,
    private dialogService: DialogService,
    public dimReportManagerApi: DimReportManagerApi,
    private dimReportManagerPrinterApi: DimReportManagerPrinterApi,
    public dimReportManagePrinterCboApi: DimReportManagePrinterCboApi,
    private printerService: PrinterService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      printerID: [1],
      reportManagerID: [null, ValidatorExtension.required('Không được bỏ trống')],
      posCode: [null, ValidatorExtension.required('Không được bỏ trống')],
      printerName: [null, ValidatorExtension.required('Không được bỏ trống')],
      ip: [null],
      optionPrint: this.fb.group({
        groupName: [''],
        paperSize: [''],
        landscape: [false],
        duplex: [false]
      })
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DanhMucReportManagerPrinterFindOneQuery({
        where: { and: [{ printerID: this.id }] }
      });
      const rs = await this.dimReportManagerPrinterApi.findOne(params).toPromise();
      if (rs.success) {
        let dataFind: any = rs.result;
        if (dataFind.optionPrint) {
          dataFind.optionPrint = JSON.parse(dataFind.optionPrint);
        } else {
          dataFind.optionPrint = {
            paperSize: null, landscape: false, duplex: false
          }
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
    if (body.optionPrint) {
      body.optionPrint = JSON.stringify(body.optionPrint);
    }

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const addData = new DanhMucReportManagerPrinterCreateCommand();
      addData.init(body);

      const rs = await this.dimReportManagerPrinterApi.create(body).toPromise();
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
      const updateData = new DanhMucReportManagerPrinterUpdateCommand();
      updateData.init({
        id: this.id,
        ...body
      });
      const rs = await this.dimReportManagerPrinterApi.update(updateData).toPromise();
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

  chonMayIn() {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Danh sách máy in';
      option.size = DialogSize.large;
      option.component = DanhSachMayInComponent;
      option.inputs = {
        id: null,
        mode: DialogMode.add
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
      if (eventName === 'onSave') {
        this.myForm.get('printerName').setValue(eventValue);
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
