import { Component, Input, OnInit } from '@angular/core';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi, ProvinceApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dbs-san-luong-tinh',
  templateUrl: './dbs-san-luong-tinh.component.html',
  styleUrls: ['./dbs-san-luong-tinh.component.scss']
})
export class DbsSanLuongTinhComponent implements OnInit {

  @Input() options: any;

  public province: string = null;

  public listPos: any[] = [
    { value: 'VNPOST', text: 'VNPOST' },
    { value: ',BDTW,%', text: 'Cả cục' },
    { value: ',BDTW,CP16,%', text: 'CP16' },
    { value: ',BDTW,T26,%', text: 'T26' },
    { value: ',BDTW,T78,%', text: 'T78' }
  ];
  public posCode: string = 'VNPOST';

  public loading: boolean;
  public tongquan: any;
  public lstColor = ['btn-warning', 'btn-success', 'btn-primary'];

  public data: any[] = [];
  public time: Date = new Date();

  constructor(
    private dimDashboardApi: DimDashboardApi,
    public provinceApi: ProvinceApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit() {
    this.loading = true;
    this.tongquan = undefined;
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({ PosCode: this.posCode ? this.posCode : '-1', Province: this.province ? this.province : '-1' })
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success && rs.result.data.length > 0) {

      this.data = rs.result.data;

      let tongDIN = 0;
      let tongDIO = 0;
      let tongTOIN = 0;
      let tongTOIO = 0;

      for (const item of this.data) {
        tongDIN += item.DIN;
        tongDIO += item.DIO;
        tongTOIN += item.TOIN;
        tongTOIO += item.TOIO;
      }
      this.tongquan = {
        DIN: tongDIN,
        DIO: tongDIO,
        TOIN: tongTOIN,
        TOIO: tongTOIO
      }
    } else {
      this.dialogService.error('Không có dữ liệu', 'Không tìm thấy dữ liệu sản lượng chấp nhận gửi theo tỉnh');
    }
    this.loading = false;
  }

  changePos() {
    this.ngOnInit();
  }

  getRandomColor() {
    let index = Math.floor(Math.random() * 3);
    return this.lstColor[index];
  }

  abs(value: any) {
    return Math.abs(value);
  }
}
