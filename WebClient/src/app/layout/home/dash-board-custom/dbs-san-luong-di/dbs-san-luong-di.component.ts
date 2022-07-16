import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi, ProvinceApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dbs-san-luong-di',
  templateUrl: './dbs-san-luong-di.component.html',
  styleUrls: ['./dbs-san-luong-di.component.scss']
})
export class DbsSanLuongDiComponent implements OnInit {

  @Input() options: any;

  public date: Date[] = [];
  public total:number = 0;

  public listPos: any[] = [
    { value: ',BDTW,%', text: 'Cả cục' },
    { value: ',BDTW,CP16,%', text: 'CP16' },
    { value: ',BDTW,T26,%', text: 'T26' },
    { value: ',BDTW,T78,%', text: 'T78' }
  ];
  public posCode: string = ',BDTW,%';

  loading = true;
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options;

  constructor(
    private dimDashboardApi: DimDashboardApi,
    public provinceApi: ProvinceApi,
    private dialogService: DialogService
  ) { 
    let endDate = new Date();
    let startDate = new Date();
    startDate.setDate(startDate.getDate()-7);
    this.date = [startDate,endDate];
  }

  // getRandomColor() {
  //   var letters = '0123456789ABCDEF';
  //   var color = '#';
  //   for (var i = 0; i < 6; i++) {
  //     color += letters[Math.floor(Math.random() * 16)];
  //   }
  //   return color;
  // }

  async ngOnInit(): Promise<void> {
    this.loading = true;
    let colors = ['#2196F3','#ffe565', '#f44336','#009688'];
   
    let data: any[] = [];
    let startDate = this.date[0].toDateYYYYMMDD();
    let endDate = this.date[1].toDateYYYYMMDD();
    
    let dateDiff = Math.floor((this.date[1].getTime() - this.date[0].getTime()) / (24 * 3600 * 1000));
    if(dateDiff < 0){
      await this.dialogService.error('','Ngày bắt đầu phải lớn hơn ngày kết thúc');
      return;
    }
    if(dateDiff > 31){
      await this.dialogService.error('','Thời gian bắt đầu và kết thúc không được quá 1 tháng');
      return;
    }
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({PosCode: this.posCode, StartDate: startDate, EndDate: endDate})
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success) {
      data = rs.result.data;

      this.total = 0;
      for (const item of rs.result.data) {
        this.total += item.yValue;
      }
    } else {
      return;
    }

    const category = [];
    for (const item of data) {
      const checkIndex = category.findIndex(x => x === item.xValue);
      if (checkIndex === -1) {
        category.push(item.xValue);
      }
    }

    const series = [];
    let i = 0;
    for (const item of data) {
      if (!item.zValue) {
        continue;
      }
      const checkIndex = series.findIndex(x => x.name === item.zValue);
      if (checkIndex === -1) {
        series.push({
          type: 'column',
          name: item.zValue,
          color: colors[i],
          data: []
        });
        i++;
      }
    }

    if (series.length > 1) {
      series.push({
        //type: 'spline',
        type: 'line',
        name: 'Tổng',
        data: [],
        color: colors[3],
        marker: {
          lineWidth: 2,
          lineColor: colors[3],
          fillColor: 'white'
        }
      });
    }

    let listTotal: any[] = [];
    for (const groupItem of series.filter(x => x.name !== 'Tổng')) {
      groupItem.data = [];
      for (const d of category) {
        let totalJobInDate = 0;
        const listData = data.filter(x => d === x.xValue && x.zValue === groupItem.name);
        for (const item of listData) {
          let countJob = item.yValue;
          if (!countJob) { countJob = '0'; }
          totalJobInDate += +countJob;
        }
        groupItem.data.push([d, totalJobInDate]);
        if (series.length > 1) {
          let totalDay = listTotal.find((x: any) => x.length > 0 && x[0] === d);
          if (totalDay) {
            totalDay[1] += totalJobInDate;
          } else {
            listTotal.push([d, totalJobInDate])
          }
        }

      }
    }
    if (series.length > 1) {
      series.find(x => x.name === 'Tổng').data = listTotal;
    }
    this.chartOptions = {
      title: {
        text: ''//this.options ? this.options.name : ''
      },
      xAxis: {
        categories: category,
        crosshair: true
      },
      yAxis: {
        min: 0,
        title: {
          text: ''
        }
      },
      tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
          '<td style="padding:0"><b>{point.y:.1f} </b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
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
      series
    };
    this.loading = false;
  }

  ngOnChanges(): void {

  }

  changePos(){
    this.ngOnInit();
  }

}
