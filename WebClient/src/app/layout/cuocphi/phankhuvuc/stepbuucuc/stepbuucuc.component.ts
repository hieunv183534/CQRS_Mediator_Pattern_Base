import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { POSFreightRegionApi, DomesticPOSFreightRegionGetByFreightRuleQuery,
  DomesticPOSFreightRegionGetByFreightRuleQueryResult, DomesticPOSFreightRegionCreateUpdateCommand,
  FreightRegionApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-phankhuvuc-stepbuucuc',
  templateUrl: './stepbuucuc.component.html',
  styleUrls: ['./stepbuucuc.component.scss']
})
export class StepBuuCucComponent implements OnInit {
// tslint:disable-next-line: no-input-rename
@Input('mode') mode: string;
// tslint:disable-next-line: no-input-rename
@Input('ruleCode') ruleCode: string;
// tslint:disable-next-line: no-input-rename
@Input('serviceCode') serviceCode: string;
// tslint:disable-next-line: no-input-rename
@Input('lstDistrictCode') lstDistrictCode: string[];
// tslint:disable-next-line: no-ouput-rename no-output-on-prefix
@Output() onPre = new EventEmitter<void>();
public formSearch: FormGroup;
public myForm: FormGroup;

public listOfData: DomesticPOSFreightRegionGetByFreightRuleQueryResult[] = [];
public paging: PagingModel;
public isLoading = false;
public isSubmit = false;

public tableConfig: TableConfigModel = new TableConfigModel({
  keyId: 'posCode',
  isAllChecked: false,
  indeterminate: false,
  itemSelected: new Set<any>()
});

public checked = false;
public loading = false;

constructor(
  private fb: FormBuilder,
  private messageService: MessageService,
  private posFreightRegionApi: POSFreightRegionApi,
  public freightRegionApi: FreightRegionApi,
) { }

async ngOnInit(): Promise<void> {
  this.formSearch = this.fb.group({
    posCode: [''],
    posName: [''],
    freightRegionId: [],
  });
  this.myForm = this.fb.group({
    freightRegionId: [null, ValidatorExtension.required('Khu vực không được để trống')],
    domesticFreightRuleCode: [this.ruleCode],
    serviceCode: [this.serviceCode],
    lstPOSCode: [null, ValidatorExtension.required('Chưa chọn bưu cục')],
  });
  await this.getData();
}

async getData(paging: PagingModel = { order: { posCode: true } }): Promise<void> {
  const formData = this.formSearch.value;

  const where = { and: [] };
  const params = new DomesticPOSFreightRegionGetByFreightRuleQuery({
    ...paging,
    domesticFreightRuleCode: this.ruleCode,
    lstDistrictCode: this.lstDistrictCode,
  });

  if (formData.posCode) {
    where.and.push({ posCode: { like: formData.posCode } });
  }
  if (formData.posName) {
    where.and.push({ posName: { like: formData.posName } });
  }
  if (formData.freightRegionId || formData.freightRegionId === 0) {
    where.and.push({ freightRegionId: formData.freightRegionId });
  }

  // where loopback
  if (where.and.length > 0) {
    params.where = where;
  }

  this.isLoading = true;
  const rs = await this.posFreightRegionApi.getByFreightRule(params).toPromise();
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
    this.myForm.get('lstPOSCode').setValue(this.tableConfig.getItemSelectedArray());
  }else{
    this.myForm.get('lstPOSCode').setValue(null);
    this.messageService.notiMessageError('Chưa chọn bưu cục');
    return;
  }
  if (this.myForm.invalid) { return; }
  // bật hiệu ứng loading và disable nút submit
  this.isSubmit = true;
  const params = new DomesticPOSFreightRegionCreateUpdateCommand(this.myForm.value);
  const rs = await this.posFreightRegionApi.createUpdate(params).toPromise();
  if (rs.success) {
    this.messageService.notiMessageSuccess('Cập nhật thành công');
    this.getData({...this.paging, page: 1});
  } else {
    this.messageService.notiMessageError(rs.error);
  }
  this.isSubmit = false;
}
async preStep(): Promise<void> {
  this.onPre.emit();
}


}
