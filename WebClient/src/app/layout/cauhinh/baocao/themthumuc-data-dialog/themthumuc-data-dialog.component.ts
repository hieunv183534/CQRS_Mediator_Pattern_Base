import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DialogMode, DialogService } from '../../../../_base/servicers/dialog.service';
import { MessageService } from '../../../../_base/servicers/message.service';
import {
  DanhMucReportManagerCreateCommand,
  DanhMucReportManagerFindOneQuery,
  DanhMucReportManagerRenameCommand,
  DimReportManagerApi
} from '../../../../_shared/bccp-api.services';
import { ValidatorExtension } from '../../../../_base/extensions/validator-extension';

@Component({
  selector: 'app-career-data-dialog',
  templateUrl: './themthumuc-data-dialog.component.html',
  styleUrls: ['./themthumuc-data-dialog.component.scss']
})
export class ThemthumucDataDialogComponent implements OnInit {

  // tslint:disable-next-line:no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line:no-input-rename
  @Input('id') id: string;
  // tslint:disable-next-line:no-input-rename
  @Input('parentId') parentId: string;
  // tslint:disable-next-line:no-output-on-prefix no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrigin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    private dimReportManagerApi: DimReportManagerApi
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      name: ['', ValidatorExtension.required()],
      parentId: [null],
      parentTag: [''],
      type: [1],
      fileTemplate: [null],
      dataSource: [''],
      dataType: [0],
      description: [''],
      params: this.fb.array([]),
      reportManagerDataSet: this.fb.array([]),
    });
    //
    this.isLoading = true;
    if (this.id) {
      const params = new DanhMucReportManagerFindOneQuery({
        where: {and: [{id: this.id}]}
      });
      const rs = await this.dimReportManagerApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue(rs.result);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }
    //
    // if (this.mode === 'view') {
    //   this.myForm.disable();
    // }
    // if (this.mode === 'edit') {
    //   this.myForm.get('customerCode').disable();
    // }
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrigin = JSON.stringify(this.myForm.value);
  }
  //
  async save(saveAndNew: boolean = false): Promise<void> {
    this.myForm.textTrim();

    // hi???n th??? to??n b??? l???i control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) {
      return;
    }

    // gi?? tr??? form body
    const body = this.myForm.getRawValue();

    // b???t hi???u ???ng loading v?? disable n??t submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) {
      // add
      const bodySend = new DanhMucReportManagerCreateCommand();
      bodySend.init({
        ...body,
        type: 1,
        parentId: this.parentId
      });
      const rs = await this.dimReportManagerApi.create(bodySend).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('L??u d??? li???u th??nh c??ng');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else {
      const bodySend = new DanhMucReportManagerRenameCommand({
        ...body,
        id: this.id
      });
      const rs = await this.dimReportManagerApi.rename(bodySend).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('L??u d??? li???u th??nh c??ng');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  // async saveAndNew(): Promise<void> {
  //   this.myForm.textTrim();
  //   this.myForm.textTrim();
  //
  //   // hi???n th??? to??n b??? l???i control
  //   this.myForm.markAllAsDirty();
  //   if (this.myForm.invalid) {
  //     return;
  //   }
  //
  //   // gi?? tr??? form body
  //   const body = this.myForm.value;
  //
  //   // b???t hi???u ???ng loading v?? disable n??t submit
  //   this.isSubmit = true;
  //   // add
  //   const rs = await this.unitApi.create(body).toPromise();
  //   if (rs.success) {
  //     this.messageService.notiMessageSuccess('Th??m d??? li???u th??nh c??ng');
  //     this.myForm.reset();
  //   } else {
  //     this.messageService.notiMessageError(this.myForm.bindError(rs.error));
  //   }
  //   this.isSubmit = false;
  // }

  async closeDialog(): Promise<void> {
    const formCurrentValue = this.myForm.value;
    // Object.keys(formCurrentValue).forEach((key) => (formCurrentValue[key] == null) && (formCurrentValue[key] = ''));
    if (this.formOrigin !== JSON.stringify(formCurrentValue)) {
      const rs = await this.dialogService.confirm('', 'B???n ???? thay ?????i d??? li???u. b???n mu???n h???y b??? kh??ng?');
      if (!rs) {
        return;
      }
    }
    this.onClose.emit();
  }

}
