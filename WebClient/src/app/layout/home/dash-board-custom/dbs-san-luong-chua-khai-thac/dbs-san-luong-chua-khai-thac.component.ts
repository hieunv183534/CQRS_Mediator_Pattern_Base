import { Component, Input, OnInit } from '@angular/core';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DimDashboardApi, ProvinceApi, DanhMucDashboardSettingGetDataQuery } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dbs-san-luong-chua-khai-thac',
  templateUrl: './dbs-san-luong-chua-khai-thac.component.html',
  styleUrls: ['./dbs-san-luong-chua-khai-thac.component.scss']
})
export class DbsSanLuongChuaKhaiThacComponent implements OnInit {

  @Input() options: any;

  public province: string = null;

  public listPos: any[] = [
    { value: ',BDTW,CP16,%', text: 'CP16' },
    { value: ',BDTW,T26,%', text: 'T26' },
    { value: ',BDTW,T78,%', text: 'T78' }
  ];
  public posCode: string = null;

  loading = true;

  dateNow = new Date();

  totalData: any = { total: 0};
  listOfData: any[] = [];

  constructor(
    private dimDashboardApi: DimDashboardApi,
    public provinceApi: ProvinceApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.loading = true;

    let data: any[] = [];
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({ PosCode: this.posCode ? this.posCode : ',BDTW,%' })
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success && rs.result.data.length > 0) {
      data = rs.result.data;

      if(data[0].tong){
        this.totalData.total = JSON.parse(data[0].tong)[0].SL;
      }
      if(data[0].data){
        this.listOfData = JSON.parse(data[0].data);
      }  
    } else {
      this.dialogService.error('Không có dữ liệu', 'Không tìm thấy dữ liệu bưu gửi chưa khai thác');
      return;
    }

    this.loading = false;
  }

  ngOnChanges(): void {

  }

  changePos() {
    this.ngOnInit();
  }

}
