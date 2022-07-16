import { Component, OnInit } from '@angular/core';
import {
  DanhMucDashboardSettingGetListUseQuery,
  DanhMucDashboardSettingGetListUseQueryResult,
  DanhMucDashboardSettingGetPagingQuery,
  DimDashboardApi
} from '../../_shared/bccp-api.services';
import { MessageService } from '../../_base/servicers/message.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  isLoading = true;
  listDashboard: DanhMucDashboardSettingGetListUseQueryResult[] = [];

  constructor(
    private dimDashboardApi: DimDashboardApi,
    private messageService: MessageService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.getData();
  }

  async getData(): Promise<void> {
    this.isLoading = true;
    const params = new DanhMucDashboardSettingGetListUseQuery();
    const rs = await this.dimDashboardApi.getListUse(params).toPromise();
    if (rs.success) {
      this.listDashboard = rs.result;
      console.log('listDashboard:',this.listDashboard);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
    this.isLoading = false;
  }

}
