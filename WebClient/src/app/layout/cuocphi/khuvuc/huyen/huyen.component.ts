import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DomesticDistrictFreightRegionGetPagingQueryResult,
  DomesticDistrictFreightRegionGetPagingQuery,
  DistrictFreightRegionApi,
  DomesticDistrictFreightRegionDeleteCommand,
  DomesticFreightRegionFindOneQuery,
  FreightRegionApi,
  DomesticDistrictFreightRegionCreateCommand
} from '../../../../_shared/bccp-api.services';
@Component({
  selector: 'app-cuocphi-khuvuc-huyen',
  templateUrl: './huyen.component.html',
  styleUrls: ['./huyen.component.scss']
})
export class HuyenComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('khuVucId') khuVucId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticDistrictFreightRegionGetPagingQueryResult[] = [];
  public isLoading = false;
  public paging: PagingModel;

  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'id',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });
  public checked = false;
  public loading = false;
  private domesticFreightRuleCode;
  private freightRegionCode;
  private serviceCode;
  constructor(
    private dialogService: DialogService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private districtFreightRegionApi: DistrictFreightRegionApi,
    private freightRegionApi:FreightRegionApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      districtCode: [''],
      districtName: [''],
      province: [null],
      district: [null],
    });
    await this.getData();
  }
  async onChangeAreaPlace(value: any): Promise<void> {
    this.formSearch.patchValue({
      province: value.province,
      district: value.district
    });
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;
    const paramsdf = new DomesticFreightRegionFindOneQuery({
      where: { and: [{ id: this.khuVucId }] }
    });
    const rsrf = await this.freightRegionApi.findOne(paramsdf).toPromise();
    if (rsrf.success) {
           this.domesticFreightRuleCode= rsrf.result.domesticFreightRuleCode;
           this.serviceCode = rsrf.result.serviceCode;
           this.freightRegionCode = rsrf.result.freightRegionCode;
    }

    const params = new DomesticDistrictFreightRegionGetPagingQuery({
      ...paging,
    });

    const where = { and: [] };
    where.and.push({ freightRegionId:  this.khuVucId });
    if (formData.districtCode) {
      where.and.push({ districtCode: { like: formData.districtCode } });
    }
    if (formData.districtName) {
      where.and.push({ districtName: { like: formData.districtName } });
    }
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    this.isLoading = true;
    const rs = await this.districtFreightRegionApi.getPaging(params).toPromise();
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
   
    // c# readonly var formData = this.myForm.value; goi getRawValue s??? ????? d??? li???u h??n k??? c??? b??? disable control
    const formData: any = this.formSearch.getRawValue();
    debugger;
    if (formData.district === null ){      
      this.messageService.notiMessageError('Ch??a ch???n Qu??n huy???n!');
      return;
    }   
  
    const params = new DomesticDistrictFreightRegionGetPagingQuery({});

    const where = { and: [] };
    where.and.push({ freightRegionId: this.khuVucId });
    where.and.push({ districtCode: { like: formData.district } });
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }   
    const rscheck = await this.districtFreightRegionApi.getPaging(params).toPromise();
    if (rscheck.success) {
      if(rscheck.result.data.length>0)
      {
        this.messageService.notiMessageError('Qu???n huy???n n??y ???? c?? trong V??ng c?????c!');
        return;
      }
    }

    const body = new DomesticDistrictFreightRegionCreateCommand({
     freightRegionId: this.khuVucId,
     domesticFreightRuleCode: this.domesticFreightRuleCode,
     serviceCode: this.serviceCode,
     freightRegionCode:this.freightRegionCode,
     districtCode: formData.district
    });

    
      const rs = await this.districtFreightRegionApi.create(body).toPromise();
      if (rs.success) {    
        this.messageService.notiMessageSuccess('Th??m d??? li???u th??nh c??ng');        
        this.getData();     
      } else {
        /* n???u l???i tr??? v??? c?? g???n v??o m???t control name tr??n form th??
        *  hi???n th??? l???i t???i control ????. c??n n???u kh??ng x??c ?????nh ???????c control
        *  hi???n th??? l???i th?? s??? show popup message th??ng b??o l???i
        */
        this.messageService.notiMessageError(this.formSearch.bindError(rs.error));
      }
   
  }
  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('B???n c?? mu???n x??a nh???ng d??? li???u n??y kh??ng?', ' ');
    if (!result) { return; }

    const params = new DomesticDistrictFreightRegionDeleteCommand({
      id: listId
    });
    const rs = await this.districtFreightRegionApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('X??a d??? li???u th??nh c??ng');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
