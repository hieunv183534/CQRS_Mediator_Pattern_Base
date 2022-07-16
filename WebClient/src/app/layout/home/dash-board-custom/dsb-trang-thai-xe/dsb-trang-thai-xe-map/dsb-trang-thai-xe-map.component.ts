import { DanhMucPOSFindOneQuery, POSApi, DimTransportApi, DanhMucTransportFindOneQuery, DanhMucDashboardSettingGetDataQuery, DimDashboardApi } from 'src/app/_shared/bccp-api.services';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { LazyLoadScriptService } from 'src/app/_base/servicers/lazy-load-script.service';
import { SettingService } from 'src/app/_shared/services/setting.service';

declare let L: any;
@Component({
  selector: 'app-dsb-trang-thai-xe-map',
  templateUrl: './dsb-trang-thai-xe-map.component.html',
  styleUrls: ['./dsb-trang-thai-xe-map.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DsbTrangThaiXeMapComponent implements OnInit {

  pos: string;
  transport: string;
  data: string[] = [];
  posData: any;
  mymap: any;
  token: string;
  fullName: string;
  userName: string;

  listTranport: any[] = [];
  lisPoint: any[] = [];
  tranPortSelect: any;

  constructor(
    private settingService: SettingService,
    private ar: ActivatedRoute,
    private lazyLoadService: LazyLoadScriptService,
    private posApi: POSApi,
    private transportApi: DimTransportApi,
    private dimDashboardApi: DimDashboardApi
  ) { }

  ngOnInit() {
    forkJoin([
      this.lazyLoadService.loadStyles(`${this.settingService.data.path}/assets/module/map/leaflet.css`),
      this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/leaflet.js`)
    ]).subscribe(async (x) => {
      this.pos = this.ar.snapshot.queryParams.pos;
      this.transport = this.ar.snapshot.queryParams.transport;
      this.data = this.ar.snapshot.queryParams.data.split(',');
      this.token = this.ar.snapshot.queryParams.access_token;
      this.fullName = this.ar.snapshot.queryParams.fullName;
      this.userName = this.ar.snapshot.queryParams.userName;

      let pos = await this.posApi.findOne(new DanhMucPOSFindOneQuery({ where: { posCode: this.pos } })).toPromise()
      this.posData = pos.result;
      setTimeout(() => {
        this.initMap();
      }, 500);
    });
  }

  async initMap() {
    let lat = this.posData.lat;
    let long = this.posData.long;
    let zoom = 13;

    this.listTranport = [];
    for (let index = 0; index < this.data.length; index++) {
      const item = this.data[index];
      let tranportData = await this.transportApi.findOne(new DanhMucTransportFindOneQuery({ where: { transportCode: item } })).toPromise();
      if (tranportData.success) {
        if (tranportData.result.speed) {
          tranportData.result.speed = +(tranportData.result.speed * 3.6).toFixed(2);
        }
        this.listTranport.push({
          marker: null,
          transportGroup: tranportData.result.transportGroup,
          transportCode: item,
          lat: tranportData.result.lat,
          long: tranportData.result.long,
          speed: tranportData.result.speed,
          statusError: tranportData.result.statusError,
          noteError: tranportData.result.noteError,
        })
      }
    }

    if (this.transport) {
      this.tranPortSelect = this.listTranport.find(x => x.transportCode === this.transport);
      if (this.tranPortSelect) {
        lat = this.tranPortSelect.lat;
        long = this.tranPortSelect.long;
        zoom = 16;
      }
    }

    this.mymap = L.map('map').setView([lat, long], zoom);
    L.tileLayer('https://maps.vnpost.vn/api/tm/{z}/{x}/{y}@2x.png?apikey=457756595ea907a5ed7dbc62fdda85852a1736e04f258c47', {
      maxZoom: 20,
      minZoom: 5,
      maxNativeZoom: zoom
    }).addTo(this.mymap);

    let posMarker = L.marker([this.posData.lat, this.posData.long]).addTo(this.mymap)
      .bindPopup(`Bưu cục: [${this.posData.posCode}] ${this.posData.posName}`);
    if (!this.transport) {
      posMarker.openPopup();
    }

    for (const item of this.listTranport) {
      var RIcon = L.icon({
        iconUrl: `${this.settingService.data.path}/assets/images/oto.png`,
        iconSize: [40, 40]
      });
      if (!item.lat) continue;
      let title = `Biển số: ${item.transportCode} <br/> Tốc độ: ${item.speed ? item.speed : 'không có dữ liệu'} km/h <br/> Lái xe: ${this.fullName}`;
      if (item.statusError) {
        title += `<br/>  Xe Hỏng: ${item.noteError}`;
      }
      item.marker = L.marker([item.lat, item.long], { icon: RIcon }).addTo(this.mymap)
        .bindPopup(title);
    }

    if (this.tranPortSelect) {
      this.tranPortSelect.marker.openPopup();
      this.getDiemPhat();
      setInterval(() => {
        this.getDiemPhat();
      }, 10000)
    }

    setInterval(() => {
      this.refeshData();
    }, 10000)
  }

  block = false;
  async refeshData() {
    if (this.block) return;
    this.block = true;
    for (let index = 0; index < this.listTranport.length; index++) {
      const item = this.listTranport[index];
      let tranportData = await this.transportApi.findOne(new DanhMucTransportFindOneQuery({ where: { transportCode: item.transportCode } })).toPromise();
      if (tranportData.success) {
        if (!tranportData.result.lat) {
          continue;
        }
        let newLatLng = new L.LatLng(tranportData.result.lat, tranportData.result.long);
        item.marker.setLatLng(newLatLng);
        if (tranportData.result.speed) {
          tranportData.result.speed = +(tranportData.result.speed * 3.6).toFixed(2);
        }

        let title = `Biển số: ${tranportData.result.transportCode} <br/> Tốc độ: ${tranportData.result.speed ? tranportData.result.speed : 'không có dữ liệu'} km/h <br/> Lái xe: ${this.fullName}`;
        if (item.statusError) {
          title += `<br/>  Xe Hỏng: ${item.noteError}`;
        }
        item.marker.bindPopup(title);

        if (this.tranPortSelect && this.tranPortSelect.transportCode === item.transportCode) {
          this.mymap.setView(new L.LatLng(tranportData.result.lat, tranportData.result.long), 16, { animation: true });
        }
      }
    }
    this.block = false;
  }

  block2 = false;
  async getDiemPhat() {
    if (this.block2) return;
    this.block2 = true;
    const params = new DanhMucDashboardSettingGetDataQuery({
      datasetId: 6553079626000901,
      params: JSON.stringify({ UserName: this.userName })
    });

    var RIcon = L.icon({
      iconUrl: `${this.settingService.data.path}/assets/images/red_marker_icon.png`,
      iconSize: [40, 40]
    });

    const rs = await this.dimDashboardApi.getData(params).toPromise();
    if (rs.success) {
      this.lisPoint = rs.result.data;

      for (const item of this.lisPoint) {
        if (!item.Lat) continue;
        if (!item.marker) {
          let title = `Điểm phát: ${item.DeliveryPointName} <br/> Địa chỉ: ${item.DeliveryPointAddress ?? 'Không có thông tin'}`;// <br/> Trạng thái: ${this.fullName}`;
          item.marker = L.marker([item.Lat, item.Long]).addTo(this.mymap)
            .bindPopup(title);
        }

        if (item.JsonDelivery && JSON.parse(item.JsonDelivery).length > 0) {
          let title2 = `Nơi phát: ${item.DeliveryPointName} <br/> Địa chỉ: ${item.DeliveryPointAddress ?? 'Không có thông tin'}`;// <br/> Trạng thái: ${this.fullName}`;
          if (!item.marker2) {
            const jsonPoint = JSON.parse(item.JsonDelivery)[0];
            if (jsonPoint.Lat) {
              item.marker2 = L.marker([jsonPoint.Lat, jsonPoint.Long], { icon: RIcon }).addTo(this.mymap)
                .bindPopup(title2);
            }
          }
        }
      }
    }
    this.block2 = false;
  }
}
