import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import {
  ExampleBasicMultiKeyApi, ExampleExampleBasicMultiKeyFindOneQuery,
  ExampleExampleBasicMultiKeyCreateCommand, ExampleExampleBasicMultiKeyUpdateCommand, ExampleExampleBasicMultiKeyUpdateCommandKey, ExampleExampleBasicMultiKeyCreateCommandKey
} from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-crud-multi-key-data-dialog',
  templateUrl: './crud-multi-key-data-dialog.component.html',
  styleUrls: ['./crud-multi-key-data-dialog.component.scss']
})
export class CrudMultiKeyDataDialogComponent implements OnInit {

  @Input() id: ExampleExampleBasicMultiKeyUpdateCommandKey;
  @Input() mode: string;
  @Output() onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    public exampleBasicMultiKeyApi: ExampleBasicMultiKeyApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      id: this.fb.group({
        id1: ['', [ValidatorExtension.required('Ma ko duoc de trong')]],
        id2: ['', [ValidatorExtension.required('Ma ko duoc de trong')]]
      }),
      colText: ['', [
        ValidatorExtension.required('Ma ko duoc de trong'),
        ValidatorExtension.space('ko duoc dung dau cach'),
        ValidatorExtension.specialChar('ko dc co ky tu dc biet')],
      ],
      colNumber: [null],
      colFloat: [null],
      colCheckBox: [false],
      colRadioBox: [1],
      colDate: [null],
      colDateTime: [null, [ValidatorExtension.required()]],
      colDateString: [null, [ValidatorExtension.required()]],
      colSelectSingle: [null],
      colTextArea: ['']
    });

    this.isLoading = true;
    if (this.id) {
      const params = new ExampleExampleBasicMultiKeyFindOneQuery({
        where: {
          and: [
            { 'id.id1': this.id.id1 },
            { 'id.id2': this.id.id2 }
          ]
        }
      });
      const rs = await this.exampleBasicMultiKeyApi.findOne(params).toPromise();
      if (rs.success) {
        if (rs.result.colDateString){
          // convert string date yyymmdd to date
          rs.result.colDateString = rs.result.colDateString.convertToISOTime();
        }
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
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
    // hi???n th??? to??n b??? l???i control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // gi?? tr??? form body
    const formData = this.myForm.getRawValue();
    // chuy???n datetime th??nh string yyyymmdd
    formData.colDateString = formData.colDateString.toDateYYYYMMDD();

    // b???t hi???u ???ng loading v?? disable n??t submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      // convert type
      // formData.id = new ExampleExampleBasicMultiKeyCreateCommandKey(formData.id);
      const body = new ExampleExampleBasicMultiKeyCreateCommand();
      body.init(formData);
      const rs = await this.exampleBasicMultiKeyApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Th??m d??? li???u th??nh c??ng');
        this.onClose.emit(body);
      } else {
        /* n???u l???i tr??? v??? c?? g???n v??o m???t control name tr??n form th??
        *  hi???n th??? l???i t???i control ????. c??n n???u kh??ng x??c ?????nh ???????c control
        *  hi???n th??? l???i th?? s??? show popup message th??ng b??o l???i
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const body = new ExampleExampleBasicMultiKeyUpdateCommand();
      body.init(formData);
      body.id = this.id;
      const rs = await this.exampleBasicMultiKeyApi.update(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('L??u d??? li???u th??nh c??ng');
        this.onClose.emit(body);
      } else {
        /* n???u l???i tr??? v??? c?? g???n v??o m???t control name tr??n form th??
        *  hi???n th??? l???i t???i control ????. c??n n???u kh??ng x??c ?????nh ???????c control
        *  hi???n th??? l???i th?? s??? show popup message th??ng b??o l???i
        */
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'B???n ???? thay ?????i d??? li???u. b???n mu???n h???y b??? kh??ng?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}

