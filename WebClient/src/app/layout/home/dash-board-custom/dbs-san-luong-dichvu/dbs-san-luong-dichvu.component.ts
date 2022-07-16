import { Component, Input, OnInit } from '@angular/core';
import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi } from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-dbs-san-luong-dichvu',
  templateUrl: './dbs-san-luong-dichvu.component.html',
  styleUrls: ['./dbs-san-luong-dichvu.component.scss']
})
export class DbsSanLuongDichvuComponent implements OnInit {

  @Input() options: any;

  loading = true;
  listOfData: any[] = [];

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
      // group
      let total = 0;
      for (const item of rs.result.data.filter(x => x.Type === 'Now')) {
        let dataNow = { name: item.Name, value: item.SL, persen: 0, change:0 };
        let dataOld = rs.result.data.find(x => x.Name === item.Name && x.Type === 'Old');
        if (dataOld && dataOld.SL > 0) {
          dataNow.change = (item.SL - dataOld.SL) * 100 / dataOld.SL;
        }
        data.push(dataNow);
        total+= item.SL;
      }

      for (const item of data) {
        if(total > 0){
          item.persen = item.value * 100 / total;
        }
      }

      this.listOfData = data;
    } else {
      return;
    }
    this.loading = false;
  }

}
