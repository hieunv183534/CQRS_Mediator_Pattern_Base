import { Component, Input, OnInit } from '@angular/core';
import { DanhMucDashboardSettingGetDataQuery, DanhMucDashboardSettingGetDataQueryResult, DimDashboardApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dash-board-table-raw',
  templateUrl: './dash-board-table-raw.component.html',
  styleUrls: ['./dash-board-table-raw.component.scss']
})
export class DashBoardTableRawComponent implements OnInit {

  @Input() options: any;

  loading = true;
  data: any[] = [];
  colums: string[] = [];

  constructor(
    private dimDashboardApi: DimDashboardApi
  ) { }

  async ngOnInit(): Promise<void> {
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success && rs.result.data.length > 0) {
      for (const key in rs.result.data[0]) {
        this.colums.push(key);
      }
      this.data = rs.result.data;
      this.loading = false;
    } else {
      return;
    }
  }

}
