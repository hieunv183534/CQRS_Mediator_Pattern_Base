import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DimDashboardApi, ProvinceApi, DanhMucDashboardSettingGetDataQuery } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dbs-canhbao-toantrinh',
  templateUrl: './dbs-canhbao-toantrinh.component.html',
  styleUrls: ['./dbs-canhbao-toantrinh.component.scss']
})
export class DbsCanhbaoToantrinhComponent implements OnInit {

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

  totalData: any = { sapCham: 0, daCham: 0 };
  listOfData1: any[] = [];
  listOfData2: any[] = [];

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

      if(data[0].tong_sap){
        this.totalData.sapCham = JSON.parse(data[0].tong_sap)[0].SL;
      }
      if(data[0].tong_cham){
        this.totalData.daCham = JSON.parse(data[0].tong_cham)[0].SL;
      }  
      if(data[0].sap_cham){
        this.listOfData1 = JSON.parse(data[0].sap_cham);
      }  
      if(data[0].da_cham){
        this.listOfData2 = JSON.parse(data[0].da_cham);
      }
    } else {
      this.dialogService.error('Không có dữ liệu', 'Không tìm thấy dữ liệu cảnh báo toàn trình');
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
