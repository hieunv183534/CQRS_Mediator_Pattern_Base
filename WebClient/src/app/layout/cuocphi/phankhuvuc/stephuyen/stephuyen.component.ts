import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DistrictFreightRegionApi, DomesticDistrictFreightRegionGetByFreightRuleQuery,
  DomesticDistrictFreightRegionGetByFreightRuleQueryResult, DomesticDistrictFreightRegionCreateUpdateCommand,
  FreightRegionApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-phankhuvuc-stephuyen',
  templateUrl: './stephuyen.component.html',
  styleUrls: ['./stephuyen.component.scss']
})
export class StepHuyenComponent implements OnInit {
// tslint:disable-next-line: no-input-rename
@Input('mode') mode: string;
// tslint:disable-next-line: no-input-rename
@Input('ruleCode') ruleCode: string;
// tslint:disable-next-line: no-input-rename
@Input('serviceCode') serviceCode: string;
// tslint:disable-next-line: no-input-rename
@Input('lstProvinceCode') lstProvinceCode: string[];
// tslint:disable-next-line: no-ouput-rename no-output-on-prefix
@Output() onNext = new EventEmitter<any[]>();
// tslint:disable-next-line: no-ouput-rename no-output-on-prefix
@Output() onPre = new EventEmitter<void>();
public formSearch: FormGroup;
public myForm: FormGroup;

public listOfData: DomesticDistrictFreightRegionGetByFreightRuleQueryResult[] = [];
public paging: PagingModel;
public isLoading = false;
public isSubmit = false;

public tableConfig: TableConfigModel = new TableConfigModel({
  keyId: 'districtCode',
  isAllChecked: false,
  indeterminate: false,
  itemSelected: new Set<any>()
});

public checked = false;
public loading = false;

constructor(
  private fb: FormBuilder,
  private messageService: MessageService,
  private districtFreightRegionApi: DistrictFreightRegionApi,
  public freightRegionApi: FreightRegionApi,
) { }

async ngOnInit(): Promise<void> {
  this.formSearch = this.fb.group({
    districtCode: [''],
    districtName: [''],
    freightRegionId: [],
  });
  this.myForm = this.fb.group({
    freightRegionId: [null, ValidatorExtension.required('Khu vực không được để trống')],
    domesticFreightRuleCode: [this.ruleCode],
    serviceCode: [this.serviceCode],
    lstDistrictCode: [null, ValidatorExtension.required('Chưa chọn huyện')],
  });
  await this.getData();
}

async getData(paging: PagingModel = { order: { districtCode: true } }): Promise<void> {
  const formData = this.formSearch.value;

  const where = { and: [] };
  const params = new DomesticDistrictFreightRegionGetByFreightRuleQuery({
    ...paging,
    domesticFreightRuleCode: this.ruleCode,
    lstProvinceCode: this.lstProvinceCode
  });

  if (formData.districtCode) {
    where.and.push({ districtCode: { like: formData.districtCode } });
  }
  if (formData.districtName) {
    where.and.push({ districtName: { like: formData.districtName } });
  }
  if (formData.freightRegionId || formData.freightRegionId === 0) {
    where.and.push({ freightRegionId: formData.freightRegionId });
  }

  // where loopback
  if (where.and.length > 0) {
    params.where = where;
  }

  this.isLoading = true;
  const rs = await this.districtFreightRegionApi.getByFreightRule(params).toPromise();
  if (rs.success) {
    this.tableConfig.reset();
    this.listOfData = rs.result.data;
    this.paging = rs.result.paging;
  } else {
    this.messageService.notiMessageError(rs.error);
  }

  this.isLoading = false;
}

async submitForm(): Promise<void> {
  // hiển thị toàn bộ lỗi control
  this.myForm.markAllAsDirty();
  if (this.tableConfig.itemSelected.size > 0){
    this.myForm.get('lstDistrictCode').setValue(this.tableConfig.getItemSelectedArray());
  }else{
    this.myForm.get('lstDistrictCode').setValue(null);
    this.messageService.notiMessageError('Chưa chọn huyện');
    return;
  }
  if (this.myForm.invalid) { return; }
  // bật hiệu ứng loading và disable nút submit
  this.isSubmit = true;
  const params = new DomesticDistrictFreightRegionCreateUpdateCommand(this.myForm.value);
  const rs = await this.districtFreightRegionApi.createUpdate(params).toPromise();
  if (rs.success) {
    this.messageService.notiMessageSuccess('Cập nhật thành công');
    this.getData({...this.paging, page: 1});
  } else {
    this.messageService.notiMessageError(rs.error);
  }
  this.isSubmit = false;
}
async nextStep(): Promise<void> {
  if (this.tableConfig.itemSelected.size === 0){
    this.messageService.notiMessageError('Chưa chọn huyện');
    return;
  }
  this.onNext.emit(this.tableConfig.getItemSelectedArray());
}
async preStep(): Promise<void> {
  this.onPre.emit();
}

}
