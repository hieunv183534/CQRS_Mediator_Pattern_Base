import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DomesticPOSFreightRegionGetPagingQueryResult,
  DomesticPOSFreightRegionGetPagingQuery,
  POSFreightRegionApi,
  DomesticPOSFreightRegionDeleteCommand,
  DomesticPOSFreightRegionCreateCommand,
  POSApi,FreightRegionApi,
  DomesticFreightRegionFindOneQuery,

} from '../../../../_shared/bccp-api.services';
@Component({
  selector: 'app-cuocphi-khuvuc-buucuc',
  templateUrl: './buucuc.component.html',
  styleUrls: ['./buucuc.component.scss']
})
export class BuuCucComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('khuVucId') khuVucId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticPOSFreightRegionGetPagingQueryResult[] = [];
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
    private posFreightRegionApi: POSFreightRegionApi,
    public posApi: POSApi,
    private freightRegionApi:FreightRegionApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      posCode: [''],
      posName: [''],
      pos: null
    });
    await this.getData();
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

    const params = new DomesticPOSFreightRegionGetPagingQuery({
      ...paging,
    });

    const where = { and: [] };
    where.and.push({ freightRegionId: this.khuVucId });
    if (formData.posCode) {
      where.and.push({ posCode: { like: formData.posCode } });
    }
    if (formData.posName) {
      where.and.push({ posName: { like: formData.posName } });
    }
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    this.isLoading = true;
    const rs = await this.posFreightRegionApi.getPaging(params).toPromise();
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
    debugger;
    if (formData.pos === null ){      
      this.messageService.notiMessageError('Chưa chọn Bưu cục!');
      return;
    }   
  
    const params = new DomesticPOSFreightRegionGetPagingQuery({});

    const where = { and: [] };
    where.and.push({ freightRegionId: this.khuVucId });
    where.and.push({ posCode: { like: formData.pos } });
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }   
    const rscheck = await this.posFreightRegionApi.getPaging(params).toPromise();
    if (rscheck.success) {
      if(rscheck.result.data.length>0)
      {
        this.messageService.notiMessageError('Bưu cục này đã có trong Vùng cước!');
        return;
      }
    }

    const body = new DomesticPOSFreightRegionCreateCommand({
     freightRegionId: this.khuVucId,
     domesticFreightRuleCode: this.domesticFreightRuleCode,
     serviceCode: this.serviceCode,
     freightRegionCode:this.freightRegionCode,
     posCode: formData.pos
    });

    
      const rs = await this.posFreightRegionApi.create(body).toPromise();
      if (rs.success) {    
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');        
        this.getData();     
      } else {
        /* nếu lỗi trả về có gắn vào một control name trên form thì
        *  hiển thị lỗi tại control đó. còn nếu không xác định được control
        *  hiển thị lỗi thì sẽ show popup message thông báo lỗi
        */
        this.messageService.notiMessageError(this.formSearch.bindError(rs.error));
      }
   
  }
  async deleteData(listId: number[]): Promise<void> {
    const result = await this.dialogService.confirm('Bạn có muốn xóa những dữ liệu này không?', ' ');
    if (!result) { return; }

    const params = new DomesticPOSFreightRegionDeleteCommand({
      id: listId
    });
    const rs = await this.posFreightRegionApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
