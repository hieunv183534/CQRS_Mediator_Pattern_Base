import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DomesticDetailRegionFreightFindOneQuery,
  DomesticDomesticFreightRuleFindOneQuery,
  DomesticFreightRuleApi,
  DetailRegionFreightApi,
  DomesticDetailRegionFreightCreateCommand,
  DomesticDetailRegionFreightUpdateCommand,
  FreightRegionApi
} from 'src/app/_shared/bccp-api.services';
@Component({
  selector: 'app-lienkhuvuc-dialog',
  templateUrl: './lienkhuvuc-dialog.component.html',
  styleUrls: ['./lienkhuvuc-dialog.component.scss']
})
export class LienKhuVucDialogComponent implements OnInit {
// tslint:disable-next-line: no-input-rename
@Input('mode') mode: string;
// tslint:disable-next-line: no-input-rename
@Input('id') id: number;
// tslint:disable-next-line: no-input-rename
@Input('ruleId') ruleId: number;
// tslint:disable-next-line: no-input-rename
@Input('stepId') stepId: number;
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
  private detailRegionFreightApi: DetailRegionFreightApi,
  private domesticFreightRuleApi: DomesticFreightRuleApi,
  public freightRegionApi: FreightRegionApi,
  private dialogService: DialogService,
) { }

async ngOnInit(): Promise<void> {
  this.myForm = this.fb.group({
    serviceCode: [null, [
      ValidatorExtension.required('Mã bảng cước không được để trống')]
    ], 
    domesticFreightRuleId: [null, [
      ValidatorExtension.required('Mã bảng cước không được để trống')]
    ],
    domesticFreightRuleCode: [null, [
      ValidatorExtension.required('Mã bảng cước không được để trống')]
    ],
    fromFreightRegionId: [null, [
      ValidatorExtension.required('Không được để trống')]
    ],
    toFreightRegionId: [null, [
      ValidatorExtension.required('Không được để trống')]
    ],
    domesticMainFreightPercent: [null, [
      ValidatorExtension.min(0, 'Không được nhỏ hơn 0'),
      ValidatorExtension.max(100, 'Không được lớn hơn 100')]
    ],
    domesticAirSurchargeFreightPercent: [null, [
      ValidatorExtension.min(0, 'Không được nhỏ hơn 0'),
      ValidatorExtension.max(100, 'không được lớn hơn 100')]
    ],
    freight: [null, [
      ValidatorExtension.min(0, 'Không được nhỏ hơn 0'),
      ValidatorExtension.required('Không được để trống')]
    ],
  });

  this.isLoading = true;
  if (this.id) {
    const params = new DomesticDetailRegionFreightFindOneQuery({
      where: { and: [{ id: this.id }] }
    });
    const rs = await this.detailRegionFreightApi.findOne(params).toPromise();
    if (rs.success) {
      this.myForm.patchValue(rs.result);
      this.ruleId = rs.result.domesticFreightRuleId;
      this.serviceCode = rs.result.serviceCode;
      this.domesticFreightRuleCode = rs.result.domesticFreightRuleCode;
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  } else if (this.ruleId){
    const params = new DomesticDomesticFreightRuleFindOneQuery({
      where: { and: [{ id: this.ruleId }] }
    });
    const rs = await this.domesticFreightRuleApi.findOne(params).toPromise();
    if (rs.success) {    
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
    const body = new DomesticDetailRegionFreightCreateCommand(this.myForm.value);
    body.serviceCode = this.serviceCode;
    body.domesticFreightRuleCode = this.domesticFreightRuleCode;
    body.toFreightRegionCode = 'kd';
    body.fromFreightRegionCode = 'kd';
    body.domesticFreightStepCode = 'kd';
    body.domesticFreightStepId = this.stepId;
    const rs = await this.detailRegionFreightApi.create(body).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
      this.onClose.emit(body);
    } else {
      this.messageService.notiMessageError(this.myForm.bindError(rs.error));
    }
  } else { // update
    // edit
    const body = new DomesticDetailRegionFreightUpdateCommand(this.myForm.value);
    body.id = this.id;
    body.serviceCode = "M";
    body.domesticFreightRuleCode = this.domesticFreightRuleCode;
    body.toFreightRegionCode = 'kd';
    body.fromFreightRegionCode = 'kd';
    body.domesticFreightStepCode = 'kd';
    body.domesticFreightStepId = this.stepId;
    const rs = await this.detailRegionFreightApi.update(body).toPromise();
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
