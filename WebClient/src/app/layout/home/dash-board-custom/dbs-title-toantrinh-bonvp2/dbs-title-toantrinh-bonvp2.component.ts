import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi } from 'src/app/_shared/bccp-api.services';
import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { DialogService } from 'src/app/_base/servicers/dialog.service';

@Component({
  selector: 'app-dbs-tile-toantrinh-bonvp2',
  templateUrl: './dbs-title-toantrinh-bonvp2.component.html',
  styleUrls: ['./dbs-title-toantrinh-bonvp2.component.scss']
})
export class DbsTitleToantrinhBonvp2Component implements OnInit {

  @Input() options: any;

  public listPos: any[] = [
    { value: ',BDTW,%', text: 'Cả cục' },
    { value: ',BDTW,CP16,%', text: 'CP16' },
    { value: ',BDTW,T26,%', text: 'T26' },
    { value: ',BDTW,T78,%', text: 'T78' }
  ];
  public posCode: string = ',BDTW,%';

  loading = true;
  Highcharts: typeof Highcharts = Highcharts;
  Highcharts2: typeof Highcharts = Highcharts;

  chartOptions: Highcharts.Options;
  chartOptions2: Highcharts.Options;

  data: any[] = [];

  constructor(
    private dimDashboardApi: DimDashboardApi,
    private dialogService: DialogService
  ) { }

  getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }

  async ngOnInit(): Promise<void> {
    let colors = ['#42A5F5','#ff8a65','#f9f21e','#f44336'];
    this.loading = true;
    this.data = [];
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({ PosCode: this.posCode })
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success && rs.result.data.length > 0) {
      this.data = rs.result.data;
    } else {
      this.dialogService.error('Không có dữ liệu', 'Không tìm thấy dữ liệu thời gian trung bình toàn trình 4 văn phòng');
      return;
    }

    this.chartOptions = {
      title: {
        text: this.options?.name
      },
      xAxis: {
        categories: [this.data[0].Date, this.data[1].Date, this.data[2].Date],
        crosshair: true
      },
      yAxis: [{ // Primary yAxis
        title: {
          text: 'Sản lượng bưu gửi',
          style: {
            color: Highcharts.getOptions().colors[1]
          }
        },
        labels: {
          format: '{value}',
          style: {
            color: Highcharts.getOptions().colors[1]
          }
        }
      }, { // Secondary yAxis
        title: {
          text: 'Thời gian toàn trình trung bình',
          style: {
            color: Highcharts.getOptions().colors[0]
          }
        },
        labels: {
          format: '{value}',
          style: {
            color: Highcharts.getOptions().colors[0]
          }
        },
        opposite: true
      }],
      tooltip: {
        shared: true
      },
      plotOptions: {
        spline: {
          dataLabels: {
            enabled: true
          }
        },
        column: {
          dataLabels: {
            enabled: true
          },
          pointPadding: 0,
          borderWidth: 0
        }
      },
      series: [
        {
          type: 'column',
          name: 'Sản lượng',
          yAxis: 0,
          color: colors[0],
          data: [
            [this.data[0].Date, this.data[0].Dat + this.data[0].ChuaDat],
            [this.data[1].Date, this.data[1].Dat + this.data[0].ChuaDat], 
            [this.data[2].Date, this.data[2].Dat + this.data[0].ChuaDat]],
          tooltip: {
            valueSuffix: ' bưu gửi'
          }
        },
        {
          type: 'spline',
          name: 'Tổng',
          yAxis: 1,
          color: colors[1],
          data: [
            [this.data[0].Date, +((this.data[0].ThoiGianPhat / (this.data[0].Dat + this.data[0].ChuaDat)).toFixed(2))],
            [this.data[1].Date, +((this.data[1].ThoiGianPhat / (this.data[1].Dat + this.data[1].ChuaDat)).toFixed(2))],
            [this.data[2].Date, +((this.data[2].ThoiGianPhat / (this.data[2].Dat + this.data[2].ChuaDat)).toFixed(2))]],
          tooltip: {
            valueSuffix: ' giờ'
          }
        },
        {
          type: 'spline',
          name: 'KT1',
          yAxis: 1,
          color: colors[2],
          data: [
            [this.data[0].Date, +((this.data[0].ThoiGianPhat_KT1 / this.data[0].Phat_KT1).toFixed(2))],
            [this.data[1].Date, +((this.data[1].ThoiGianPhat_KT1 / this.data[1].Phat_KT1).toFixed(2))],
            [this.data[2].Date, +((this.data[2].ThoiGianPhat_KT1 / this.data[2].Phat_KT1).toFixed(2))]],
          tooltip: {
            valueSuffix: ' giờ'
          }
        },
        {
          type: 'spline',
          name: 'Khẩn',
          yAxis: 1,
          color: colors[3],
          data: [
            [this.data[0].Date, +((this.data[0].ThoiGianPhat_Khan / this.data[0].Phat_Khan).toFixed(2))],
            [this.data[1].Date, +((this.data[1].ThoiGianPhat_Khan / this.data[1].Phat_Khan).toFixed(2))],
            [this.data[2].Date, +((this.data[2].ThoiGianPhat_Khan / this.data[2].Phat_Khan).toFixed(2))]],
          tooltip: {
            valueSuffix: ' giờ'
          }
        }
      ]
    };

    this.loading = false;
  }

  ngOnChanges(): void {

  }

  changePos() {
    this.ngOnInit();
  }

}
