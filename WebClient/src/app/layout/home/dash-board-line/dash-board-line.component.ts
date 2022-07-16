import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import {
  DanhMucDashboardSettingGetDataQuery,
  DanhMucDashboardSettingGetDataQueryResult,
  DimDashboardApi
} from '../../../_shared/bccp-api.services';

@Component({
  selector: 'app-dash-board-line',
  templateUrl: './dash-board-line.component.html',
  styleUrls: ['./dash-board-line.component.scss']
})
export class DashBoardLineComponent implements OnInit {

  @Input() options: any;

  loading = true;
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options ;

  constructor(
    private dimDashboardApi: DimDashboardApi
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
    let data: any[] = [];
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success) {
      data = rs.result.data;
    } else {
      return ;
    }

    const category = [];
    for (const item of data) {
      const checkIndex = category.findIndex(x => x === item.xValue);
      if (checkIndex === -1) {
        category.push(item.xValue);
      }
    }

    const series = [];
    for (const item of data) {
      if (!item.zValue) {
        continue;
      }
      const checkIndex = series.findIndex(x => x.name === item.zValue);
      if (checkIndex === -1) {
        series.push({ 
          name: item.zValue, 
          color: this.getRandomColor(),
          data: [] });
      }
    }
    for (const groupItem of series) {
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
      }
    }
    this.chartOptions = {
      chart: {
        type: 'line'
      },
      title: {
        text: ''
      },
      // subtitle: {
      //   text: 'Source: WorldClimate.com'
      // },
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
        column: {
          pointPadding: 0.2,
          borderWidth: 0
        }
      },
      series
    };
    this.loading = false;
  }
}
