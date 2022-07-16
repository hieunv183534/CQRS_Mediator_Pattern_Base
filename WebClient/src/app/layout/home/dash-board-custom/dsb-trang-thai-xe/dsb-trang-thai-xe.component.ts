import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { DanhMucDashboardSettingGetDataQuery, DimDashboardApi } from 'src/app/_shared/bccp-api.services';
import { SettingService } from 'src/app/_shared/services/setting.service';
import { DongchuyenthuDataDialogComponent } from 'src/app/layout/phatbuugui/thongtinphat/dongchuyenthu-data-dialog/dongchuyenthu-data-dialog.component';

@Component({
  selector: 'app-dsb-trang-thai-xe',
  templateUrl: './dsb-trang-thai-xe.component.html',
  styleUrls: ['./dsb-trang-thai-xe.component.scss']
})
export class DsbTrangThaiXeComponent implements OnInit, OnDestroy {

  @Input() options: any;

  public listData: any[] = [
    { value: '100903', text: 'CP16' },
    { value: '550901', text: 'T26' },
    { value: '700903', text: 'T78' }
  ]

  public url: string;

  public posCode: string = '100903';
  public transportCode: string = '';
  public userName: string = '';
  public fullName: string = '';

  public listOfData: any[] = [];
  public listMore: any[] = [];
  isLoading = true;
  isLoadIframe = true;
  isLoadMore = true;
  nIntervId: any;
  constructor(
    private settingService: SettingService,
    private dimDashboardApi: DimDashboardApi,
    private dialogService: DialogService
  ) { }

  async ngOnInit() {
    if (!this.nIntervId) {
      this.nIntervId = setInterval(() => {
        this.getData();
      }, 60000);
    }

    this.isLoading = true;
    await this.getData();
    this.isLoading = false;
  }

  ngOnDestroy(): void {
    if (this.nIntervId) {
      clearInterval(this.nIntervId);
      this.nIntervId = null;
    }
  }

  selectTran(item: any) {
    if (this.transportCode === item.TransportCode) {
      this.transportCode = '';
      this.userName = '';
      this.fullName = '';
      // let url = `${this.settingService.data.path}/ban-do-xe/?pos=${this.posCode}&fullName=${this.fullName}&userName=${this.userName}&transport=${this.transportCode}&data=${(this.listOfData.map(x => x.TransportCode)).join(',')}`;
      // if (this.url !== url) {
      //   this.isLoadIframe = true;
      //   this.url = url;
      // }
      // return;
    } else {
      this.transportCode = item.TransportCode;
      this.userName = item.CreatedBy;
      this.fullName = item.FullName;
    }

    // let url = `${this.settingService.data.path}/ban-do-dp?id=${item.MailtripID}`;
    // if (this.url !== url) {
    //   this.isLoadIframe = true;
    //   this.url = url;
    // }
    let url = `${this.settingService.data.path}/ban-do-xe/?pos=${this.posCode}&fullName=${this.fullName}&userName=${this.userName}&transport=${this.transportCode}&data=${(this.listOfData.map(x => x.TransportCode)).join(',')}`;
    if (this.url !== url) {
      this.isLoadIframe = true;
      this.url = url;
    }
    this.getDuongThu();
  }

  async changePos() {
    this.isLoading = true;
    await this.getData();
    this.isLoading = false;
  }

  async getData() {
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: this.options.datasetId,
      params: JSON.stringify({ PosCode: this.posCode })
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success) {
      for (const item of rs.result.data) {
        if (item.MailTripData) {
          let jsonData: any[] = JSON.parse(item.MailTripData);
          if (jsonData.length > 0) {
            item.ApprovedDate = jsonData[0].ApprovedDate;
            item.MailtripID = jsonData[0].MailtripID;
          }
        }
      }
      this.listOfData = rs.result.data;

      if (this.transportCode) {
        // let url = `${this.settingService.data.path}/ban-do-dp?id=${item.MailtripID}`;
        // if (this.url !== url) {
        //   this.isLoadIframe = true;
        //   this.url = url;
        // }
        this.getDuongThu();
        //return;
      }

      let url = `${this.settingService.data.path}/ban-do-xe/?pos=${this.posCode}&fullName=${this.fullName}&userName=${this.userName}&transport=${this.transportCode}&data=${(this.listOfData.map(x => x.TransportCode)).join(',')}`;
      if (this.url !== url) {
        this.isLoadIframe = true;
        this.url = url;
      }
    } else {
      return;
    }
  }

  async getDuongThu() {
    if (!this.userName) {
      this.listMore = [];
    }

    this.isLoadMore = true;
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: 6546596515300903,
      params: JSON.stringify({ CreatedBy: this.userName })
    });
    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success) {
      for (const item of rs.result.data) {
        if (item.DataJson) {
          let jsonData: any[] = JSON.parse(item.DataJson);
          if (jsonData.length > 0) {
            item.DaPhat = jsonData[0].DaPhat;
            item.SoLuong = jsonData[0].SoLuong;
          }
        }
      }
      this.listMore = rs.result.data;
    }
    this.isLoadMore = false;
  }

  async viewDataDialog(id: number): Promise<void> {
   
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Xem thông tin chuyến thư đi phát';
      option.size = DialogSize.full;
      option.component = DongchuyenthuDataDialogComponent;
      option.inputs = {
        id,
        mode: DialogMode.view
      };
    }, (eventName) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
      }
    });
  }
}
