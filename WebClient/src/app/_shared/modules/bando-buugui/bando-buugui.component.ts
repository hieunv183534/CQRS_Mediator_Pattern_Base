import { PhatItemApi, PhatItemGetLocationQuery } from 'src/app/_shared/bccp-api.services';
import { Component, Input, OnInit } from '@angular/core';
import { SettingService } from '../../services/setting.service';

declare let L: any;
@Component({
  selector: 'app-bando-buugui',
  templateUrl: './bando-buugui.component.html',
  styleUrls: ['./bando-buugui.component.scss']
})
export class BandoBuuguiComponent implements OnInit {

  @Input() itemCode: string;
  noData: string;
  url: string;

  constructor(
    private phatItemApi: PhatItemApi,
    private settingService: SettingService,
  ) { }

  async ngOnInit() {
    const param = new PhatItemGetLocationQuery({ itemCode: this.itemCode });
    const rs = await this.phatItemApi.getLocation(param).toPromise();
    if (rs.success) {
      if (rs.result && rs.result.lat && rs.result.long) {
        this.url = `${this.settingService.data.path}/ban-do-buu-gui?itemCode=${this.itemCode}`;
        this.noData = '';
      } else {
        this.url = null;
        this.noData = 'Chưa có dữ liệu định vị';
      }
    }
  }

}
