import { Component, Input, OnInit } from '@angular/core';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi, ProvinceApi } from 'src/app/_shared/bccp-api.services';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-dbs-tile-toantrinh-noitinh3',
  templateUrl: './dbs-tile-toantrinh-noitinh3.component.html',
  styleUrls: ['./dbs-tile-toantrinh-noitinh3.component.scss']
})
export class DbsTileToantrinhNoitinh3Component implements OnInit {

  @Input() options: any;

  public province: string = null;

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
    public provinceApi: ProvinceApi,
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
    this.loading = true;
    this.data = [];
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({PosCode: this.posCode ? this.posCode : '-1', Province: this.province ? this.province: '-1'})
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success && rs.result.data.length > 0) {
      this.data = rs.result.data;
    } else {
      this.dialogService.error('Không có dữ liệu','Không tìm thấy dữ liệu tỉ lệ toàn trình nội tỉnh');
      return;
    }

    this.chartOptions = {
      title: {
        text: ''
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
        line: {
          dataLabels: {
            enabled: true
          },
          enableMouseTracking: false
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
          name: 'Đạt',
          yAxis: 0,
          color: Highcharts.getOptions().colors[2],
          data: [[this.data[0].Date, this.data[0].Dat], [this.data[1].Date, this.data[1].Dat], [this.data[2].Date, this.data[2].Dat]],
          tooltip: {
            valueSuffix: ' bưu gửi'
          }
        }, {
          type: 'column',
          name: 'Chưa đạt',
          yAxis: 0,
          color: Highcharts.getOptions().colors[5],
          data: [[this.data[0].Date, this.data[0].ChuaDat], [this.data[1].Date, this.data[1].ChuaDat], [this.data[2].Date, this.data[2].ChuaDat]],
          tooltip: {
            valueSuffix: ' bưu gửi'
          }
        },
        {
          type: 'spline',
          name: 'Thời gian phát trung bình',
          yAxis: 1,
          color: Highcharts.getOptions().colors[3],
          data: [
            [this.data[0].Date, +((this.data[0].ThoiGianPhat / (this.data[0].Dat + this.data[0].ChuaDat)).toFixed(2))],
            [this.data[1].Date, +((this.data[1].ThoiGianPhat / (this.data[1].Dat + this.data[1].ChuaDat)).toFixed(2))],
            [this.data[2].Date, +((this.data[2].ThoiGianPhat / (this.data[2].Dat + this.data[2].ChuaDat)).toFixed(2))]],
          marker: {
            lineWidth: 2,
            lineColor: Highcharts.getOptions().colors[0],
            fillColor: 'white'
          },
          tooltip: {
            valueSuffix: ' giờ'
          }
        }
      ]
    };

    this.bieudoTron();

    this.loading = false;
  }

  bieudoTron(index: number = 0) {
    // bieu do %
    const series = [];

    this.Highcharts2.setOptions({
      colors: ['#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4']
    });
    this.chartOptions2 = {
      chart: {
        type: 'pie'
      },
      title: {
        text: ''
      },

      accessibility: {
        announceNewData: {
          enabled: true
        },
        point: {
          valueSuffix: '%'
        }
      },

      plotOptions: {
        series: {
          dataLabels: {
            enabled: true,
            format: '{point.name}: {point.y:.1f} %'
          }
        }
      },

      tooltip: {
        headerFormat: '<span style="font-size:11px">{point.x}</span><br>',
        pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b><br/>'
      },

      series: [
        {
          type: 'pie',
          data: [
            ['Đạt',
              +((this.data[index].Dat * 100 / (this.data[index].Dat + this.data[index].ChuaDat)).toFixed(2))
              , false],
            ['Chưa đạt',
              +((this.data[index].ChuaDat * 100 / (this.data[index].Dat + this.data[index].ChuaDat)).toFixed(2))
              , false]
          ]
        }
      ]
    };
  }

  ngOnChanges(): void {

  }

  changePos(){
    this.ngOnInit();
  }

  selectData(event: any) {
    if(!event?.point?.category) return;
    const index = this.data.findIndex(x=> x.Date === event.point.category);
    if(index !== -1){
      this.bieudoTron(index);
    }
  }

}
