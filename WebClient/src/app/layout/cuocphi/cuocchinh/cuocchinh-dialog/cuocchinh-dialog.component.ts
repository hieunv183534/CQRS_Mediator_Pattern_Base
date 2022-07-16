import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DomesticDomesticFreightStepFindOneQuery,
  DomesticDomesticFreightRuleFindOneQuery,
  DomesticFreightStepApi,
  DomesticFreightRuleApi,
  ItemTypeApi,
  DomesticDomesticFreightStepCreateCommand,
  DomesticDomesticFreightStepUpdateCommand
} from '../../../../_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-cuocchinh-dialog',
  templateUrl: './cuocchinh-dialog.component.html',
  styleUrls: ['./cuocchinh-dialog.component.scss']
})
export class CuocChinhDialogComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleId') ruleId: number;
  // tslint:disable-next-line: no-output-rename no-output-on-prefix
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  private serviceCode: string;
  private domesticFreightRuleCode: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private domesticFreightStepApi: DomesticFreightStepApi,
    private domesticFreightRuleApi: DomesticFreightRuleApi,
    public itemTypeApi: ItemTypeApi,
    private dialogService: DialogService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      serviceCode: [null, [
        ValidatorExtension.required('Mã dịch vụ không được để trống')]
      ],
      domesticFreightRuleId: [null, [
        ValidatorExtension.required('Mã bảng cước không được để trống')]
      ],
      domesticFreightRuleCode: [null, [
        ValidatorExtension.required('Mã bảng cước không được để trống')]
      ],
      domesticFreightStepCode: ['', [
        ValidatorExtension.required('Mã không được để trống'),
        ValidatorExtension.space('Mã không được có khoảng trắng'),
        ValidatorExtension.specialChar('Mã không được có ký tự đặt biệt'),
        ValidatorExtension.maxLength(5, 'Mã không được nhập quá 5 ký tự')]
      ],
      fromWeight: [0, [
        ValidatorExtension.required('Từ khối lượng không được để trống')]
      ],
      toWeight: [0, [
        ValidatorExtension.required('Đến khối lượng không được để trống')]
      ],
      itemTypeCode: [null, [
        ValidatorExtension.required('Loại bưu gửi không được để trống')]
      ],
      calculationMethod: [0],
      freightStep: [0],
      isBatch: [false],
      internalProvinceFreight: [0],
      transportType: [0]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DomesticDomesticFreightStepFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.domesticFreightStepApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue(rs.result);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    } else if (this.ruleId){
      const params = new DomesticDomesticFreightRuleFindOneQuery({
        where: { and: [{ id: this.ruleId }] }
      });
      const rs = await this.domesticFreightRuleApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.get('serviceCode').setValue(rs.result.serviceCode);
        this.myForm.get('domesticFreightRuleCode').setValue(rs.result.domesticFreightRuleCode);
        this.myForm.get('domesticFreightRuleId').setValue(this.ruleId);
        this.serviceCode = rs.result.serviceCode;
        this.domesticFreightRuleCode = rs.result.domesticFreightRuleCode;
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    this.myForm.get('serviceCode').disable();
    this.myForm.get('domesticFreightRuleCode').disable();
    if (this.mode === 'view'){
      this.myForm.disable();
    }
    else if (this.mode === 'edit') {
      this.myForm.get('domesticFreightStepCode').disable();
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
    const formData: any = this.myForm.getRawValue();
    ///
    if(formData.fromWeight >= formData.toWeight)
    {
      this.messageService.notiMessageError('Từ khối lượng không được lớn hơn hoặc bằng Đến khối lượng.');
      return;
    }
    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const body = new DomesticDomesticFreightStepCreateCommand(this.myForm.value);
      body.serviceCode = this.serviceCode;
      body.domesticFreightRuleCode = this.domesticFreightRuleCode;
      const rs = await this.domesticFreightStepApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const body = new DomesticDomesticFreightStepUpdateCommand(this.myForm.value);
      body.id = this.id;
      const rs = await this.domesticFreightStepApi.update(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        this.onClose.emit(body);
      } else {
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
