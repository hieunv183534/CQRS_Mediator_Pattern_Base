import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DomesticProvinceFreightRegionGetPagingQueryResult,
  DomesticProvinceFreightRegionGetPagingQuery,
  ProvinceFreightRegionApi,
  DomesticProvinceFreightRegionDeleteCommand,
  DomesticProvinceFreightRegionCreateCommand,
  ProvinceApi,
  FreightRegionApi,
  DomesticFreightRegionFindOneQuery,
} from '../../../../_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-khuvuc-tinh',
  templateUrl: './tinh.component.html',
  styleUrls: ['./tinh.component.scss']
})
export class TinhComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('khuVucId') khuVucId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticProvinceFreightRegionGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel;
  private domesticFreightRuleCode;
  private freightRegionCode;
  private serviceCode;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;

  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private provinceFreightRegionApi: ProvinceFreightRegionApi,
    public provinceApi:ProvinceApi,
    private freightRegionApi:FreightRegionApi,
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      provinceCode: [''],
      provinceName: [''],
      province: null,
    });
    await this.getData();
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;

    const params = new DomesticProvinceFreightRegionGetPagingQuery({
      ...paging,
    });

    const paramsdf = new DomesticFreightRegionFindOneQuery({
      where: { and: [{ id: this.khuVucId }] }
    });
    const rsrf = await this.freightRegionApi.findOne(paramsdf).toPromise();
    if (rsrf.success) {
           this.domesticFreightRuleCode= rsrf.result.domesticFreightRuleCode;
           this.serviceCode = rsrf.result.serviceCode;
           this.freightRegionCode = rsrf.result.freightRegionCode;
    }

    const where = { and: [] };
    where.and.push({ freightRegionId: this.khuVucId });
    if (formData.provinceCode) {
      where.and.push({ provinceCode: { like: formData.provinceCode } });
    }
    if (formData.provinceName) {
      where.and.push({ provinceName: { like: formData.provinceName } });
    }
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    this.isLoading = true;
    const rs = await this.provinceFreightRegionApi.getPaging(params).toPromise();
    if (rs.success) {
      this.tableConfig.reset();
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging; 
    } else {
      this.messageService.notiMessageError(rs.error);
    }

    this.isLoading = false;
  }
  async addDataDialog(): Promise<void> {
   
    // c# readonly var formData = this.myForm.value; goi getRawValue sẽ đủ dữ liệu hơn kể cả bị disable control
    const formData: any = this.formSearch.getRawValue();
    if (formData.province === null ){      
      this.messageService.notiMessageError('Chưa chọn Tỉnh!');
      return;
    }   
    for(let item of formData.province)
    {
      const params = new DomesticProvinceFreightRegionGetPagingQuery({});
      const where = { and: [] };
      where.and.push({ freightRegionId: this.khuVucId });
      where.and.push({ provinceCode: { like: item } });
      // where loopback
      if (where.and.length > 0) {
        params.where = where;
      }   
      const rscheck = await this.provinceFreightRegionApi.getPaging(params).toPromise();
      if (rscheck.success) {
        if(rscheck.result.data.length>0)
        {
          this.messageService.notiMessageError('Tỉnh này đã có trong Vùng cước!');
          return;
        }
      }
    }
    var isSuccess = true;
    for(let item of formData.province)
    {
      const body = new DomesticProvinceFreightRegionCreateCommand({
        freightRegionId: this.khuVucId,
        domesticFreightRuleCode: this.domesticFreightRuleCode,
        serviceCode: this.serviceCode,
        freightRegionCode:this.freightRegionCode,
        provinceCode: item
        });    
        const rs = await this.provinceFreightRegionApi.create(body).toPromise();
        if (rs.success) {    
          
        } else {   
          isSuccess = false;    
          this.messageService.notiMessageError(this.formSearch.bindError(rs.error));
        }
    }
    if(isSuccess)
    {
      this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');        
      this.getData();    
    }
   
  }
  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new DomesticProvinceFreightRegionDeleteCommand({
      id: listId
    });
    const rs = await this.provinceFreightRegionApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
