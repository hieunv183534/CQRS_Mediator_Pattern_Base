import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import {
  DanhMucDashboardSettingGetDataQuery,
  DanhMucDashboardSettingGetDataQueryResult,
  DimDashboardApi
} from '../../../_shared/bccp-api.services';

@Component({
  selector: 'app-dash-board-pie',
  templateUrl: './dash-board-pie.component.html',
  styleUrls: ['./dash-board-pie.component.scss']
})
export class DashBoardPieComponent implements OnInit {

  @Input() options: any;

  loading = true;
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options;

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
    // console.log('date:' , date);
    for (const item of data) {
      if (!item.zValue) {
        continue;
      }
      const checkIndex = series.findIndex(x => x.name === item.zValue);
      if (checkIndex === -1) {
        series.push({ name: item.zValue + '', y: 0, x: item.xValue });
      }
    }
    for (const groupItem of series) {
      groupItem.y = 0;
      for (const d of category) {
        let totalJobInDate = 0;
        const listData = data.filter(x => d === x.xValue && x.zValue === groupItem.name);
        for (const item of listData) {
          let countJob = item.yValue;
          if (!countJob) { countJob = '0'; }
          totalJobInDate += +countJob;
        }
        groupItem.y += +totalJobInDate;
      }
      // console.log('group item: ', groupItem)
    }
    // tính tỉ lệ
    const sum = series.reduce((a, b) => {
      return a + b.y;
    }, 0);

    for (const item of series) {
      item.y = (item.y / sum) * 100;
    }

    this.chartOptions = {
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
          data: series
        }
      ]
    };
    this.loading = false;
  }
}
