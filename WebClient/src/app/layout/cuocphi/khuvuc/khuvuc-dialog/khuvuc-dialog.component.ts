import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DomesticFreightRegionFindOneQuery,
  DomesticDomesticFreightRuleFindOneQuery,
  FreightRegionApi,
  DomesticFreightRuleApi,
  DomesticFreightRegionCreateCommand,
  DomesticFreightRegionUpdateCommand
} from '../../../../_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-khuvuc-dialog',
  templateUrl: './khuvuc-dialog.component.html',
  styleUrls: ['./khuvuc-dialog.component.scss']
})
export class KhuVucDialogComponent implements OnInit {

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
    private freightRegionApi: FreightRegionApi,
    private domesticFreightRuleApi: DomesticFreightRuleApi,
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
      freightRegionCode: ['', [
        ValidatorExtension.required('Mã khu vực không được để trống'),
        ValidatorExtension.space('Mã khu vực không được có khoảng trắng'),
        ValidatorExtension.specialChar('Mã khu vực không được có ký tự đặt biệt'),
        ValidatorExtension.maxLength(2, 'Mã khu vực không được nhập quá 2 ký tự')]
      ],
      freightRegionName: ['', [
        ValidatorExtension.required('Tên khu vực không được để trống'),
        ValidatorExtension.maxLength(100, 'Tên khu vực không được nhập quá 100 ký tự')]
      ],
      description: ['', [
        ValidatorExtension.maxLength(500, 'Mô tả không được nhập quá 500 ký tự')]
      ],
      isSpecial: [false]
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DomesticFreightRegionFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.freightRegionApi.findOne(params).toPromise();
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
    if (this.mode === 'edit') {
      this.myForm.get('freightRegionCode').disable();
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

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const body = new DomesticFreightRegionCreateCommand(this.myForm.value);
      body.serviceCode = this.serviceCode;
      body.domesticFreightRuleCode = this.domesticFreightRuleCode;
      const rs = await this.freightRegionApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const body = new DomesticFreightRegionUpdateCommand(this.myForm.value);
      body.id = this.id;
      const rs = await this.freightRegionApi.update(body).toPromise();
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
