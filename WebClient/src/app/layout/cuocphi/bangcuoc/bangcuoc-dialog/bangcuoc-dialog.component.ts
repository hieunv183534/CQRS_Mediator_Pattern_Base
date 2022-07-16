import { DomesticDomesticFreightRuleFindOneQuery,
  DomesticFreightRuleApi,
  ServiceApi,
  ProvinceApi,
  DomesticDomesticFreightRuleCreateCommand,
  DomesticDomesticFreightRuleUpdateCommand
} from './../../../../_shared/bccp-api.services';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';

@Component({
  selector: 'app-cuocphi-bangcuoc-dialog',
  templateUrl: './bangcuoc-dialog.component.html',
  styleUrls: ['./bangcuoc-dialog.component.scss']
})
export class BangCuocDialogComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-output-rename no-output-on-prefix
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public ruleCode: string;
  public serviceCode: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private domesticFreightRuleApi: DomesticFreightRuleApi,
    public serviceApi: ServiceApi,
    public provinceApi: ProvinceApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      serviceCode: [null, [
        ValidatorExtension.required('Mã dịch vụ không được để trống'),
        ValidatorExtension.maxLength(2, 'Mã dịch vụ không được nhập quá 2 ký tự')]
      ],
      domesticFreightRuleCode: ['', [
        ValidatorExtension.required('Mã không được để trống'),
        ValidatorExtension.space('Mã không được có khoảng trắng'),
        ValidatorExtension.specialChar('Mã không được có ký tự đặt biệt'),
        ValidatorExtension.maxLength(10, 'Mã không được nhập quá 10 ký tự')]
      ],
      valueDate: [null, [
        ValidatorExtension.required('Ngày hiệu lực không được để trống')]
      ],
      expiredDate: [null, [
        ValidatorExtension.required('Ngày hết hiệu lực không được để trống')]
      ],
      ruleNo: ['', [
        ValidatorExtension.maxLength(50, 'Số quyết định không được nhập quá 50 ký tự')]
      ],
      hasVAT: [false],
      vatPercent: [0],
      provinceCode: ['', [
        ValidatorExtension.maxLength(2, 'Mã tỉnh không được nhập quá 2 ký tự')]
      ],
      customerCode: ['', [
        ValidatorExtension.maxLength(17, 'Mã khách hàng không được nhập quá 17 ký tự')]
      ],
      commodityCalculationMethod: [0],
      fuelFreightCoefficient: [0],
      farRegionCoefficient: [20],
      batchCalculateMethod: [0],
    });
    this.serviceCode = "M"
    this.myForm.patchValue({serviceCode:"M"});
    this.isLoading = true;
    if (this.id) {
      const params = new DomesticDomesticFreightRuleFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.domesticFreightRuleApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue(rs.result);
        this.ruleCode = rs.result.domesticFreightRuleCode;
        this.serviceCode = rs.result.serviceCode;
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }
    
    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      this.myForm.get('serviceCode').disable();
      this.myForm.get('domesticFreightRuleCode').disable();
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
    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi-add
      const body = new DomesticDomesticFreightRuleCreateCommand(this.myForm.value);
      const rs = await this.domesticFreightRuleApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update-edit
      const body = new DomesticDomesticFreightRuleUpdateCommand(this.myForm.value);
      body.id = this.id;
      body.fuelFreightCoefficient = formData.fuelFreightCoefficient;
      debugger;
      const rs = await this.domesticFreightRuleApi.update(body).toPromise();
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
