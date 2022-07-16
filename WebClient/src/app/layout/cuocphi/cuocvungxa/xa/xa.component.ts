import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { PagingModel } from 'src/app/_base/models/response-model';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DomesticDomesticFarRegionCommuneGetPagingQueryResult, 
  DomesticDomesticFarRegionCommuneGetPagingQuery,
  DomesticFarRegionCommuneApi,
  DomesticDomesticFarRegionCommuneDeleteCommand,  
  DomesticDomesticFarRegionCommuneCreateCommand
} from '../../../../_shared/bccp-api.services';
@Component({
  selector: 'app-cuocphi-cuocvungxa-xa',
  templateUrl: './xa.component.html',
  styleUrls: ['./xa.component.scss']
})
export class XaComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleId') ruleId: number;
  public formSearch: FormGroup;

  public listOfData: DomesticDomesticFarRegionCommuneGetPagingQueryResult[] = [];
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
    private dmesticFarRegionCommuneApi: DomesticFarRegionCommuneApi,
  ) { }

  async ngOnInit(): Promise<void> {
    this.formSearch = this.fb.group({
      commnuneCode: [''],
      commnuneName: [''],
      province: [null],
      district: [null],
      commune: [null],
    });
    await this.getData();
  }
  async onChangeAreaPlace(value: any): Promise<void> {
    debugger;
    this.formSearch.patchValue({
      province: value.province,
      district: value.district,
      commune: value.commune
    });
  }

  async getData(paging: PagingModel = { order: { id: false } }): Promise<void> {
    const formData = this.formSearch.value;  

    const params = new DomesticDomesticFarRegionCommuneGetPagingQuery({
      ...paging,
    });

    const where = { and: [] };
    where.and.push({ domesticFreightRuleId:  this.ruleId });
    if (formData.districtCode) {
      where.and.push({ communeCode: { like: formData.commnuneCode } });
    }
    if (formData.districtName) {
      where.and.push({ commnuneName: { like: formData.commnuneName } });
    }
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    this.isLoading = true;
    const rs = await this.dmesticFarRegionCommuneApi.getPaging(params).toPromise();
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
    if (formData.commune === null ){      
      this.messageService.notiMessageError('Chưa chọn Quân huyện!');
      return;
    }   
  
    const params = new DomesticDomesticFarRegionCommuneGetPagingQuery({});

    const where = { and: [] };
    where.and.push({ domesticFreightRuleId:  this.ruleId });
    where.and.push({ communeCode: { like: formData.commune } });
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }   
    const rscheck = await this.dmesticFarRegionCommuneApi.getPaging(params).toPromise();
    if (rscheck.success) {
      if(rscheck.result.data.length>0)
      {
        this.messageService.notiMessageError('Quận huyện này đã có trong Vùng cước!');
        return;
      }
    }

    const body = new DomesticDomesticFarRegionCommuneCreateCommand({
      domesticFreightRuleId: this.ruleId,
      communeCode: formData.commune
    });

    
      const rs = await this.dmesticFarRegionCommuneApi.create(body).toPromise();
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

    const params = new DomesticDomesticFarRegionCommuneDeleteCommand({
      id: listId
    });
    const rs = await this.dmesticFarRegionCommuneApi.delete(params).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Xóa dữ liệu thành công');
      this.getData(this.paging);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }

}
