import { DanhMucTransportFindOneQuery } from './../../../bccp-api.services';
import { forkJoin } from 'rxjs';
import { UserService } from './../../../../_shared/services/user.service';
import { LazyLoadScriptService } from './../../../../_base/servicers/lazy-load-script.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PhatDeliveryPointApi, PhatDeliveryPointGetByMailtripQuery, POSApi, DanhMucPOSFindOneQuery, DeliveryApi, PhatDeliveryGetByMailtripQuery, PhatMailtripDeliveryApi, PhatMailtripDeliveryFindOneQuery, DimTransportApi, UserApi } from 'src/app/_shared/bccp-api.services';
import { title } from 'process';
import { SettingService } from 'src/app/_shared/services/setting.service';
declare let L: any;
@Component({
  selector: 'app-bandodp-page',
  templateUrl: './bandodp-page.component.html',
  styleUrls: ['./bandodp-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class BandodpPageComponent implements OnInit, OnDestroy {
  public data = [];
  public dataDelivery = [];
  public postCode: string;

  lat: number;
  long: number;
  marker1: any;
  interval1: any;
  transportCode: string;
  transportName: string;

  constructor(
    private settingService: SettingService,
    private deliveryPointApi: PhatDeliveryPointApi,
    private deliveryApi: DeliveryApi,
    private phatMailtripDeliveryApi: PhatMailtripDeliveryApi,
    private dimTransportApi: DimTransportApi,
    private posApi: POSApi,
    private userService: UserService,
    private ar: ActivatedRoute,
    private lazyLoadService: LazyLoadScriptService,
    private userApi: UserApi
  ) { }
  private mailtripID: number;
  async ngOnInit() {
    // load all file thu vien goc
    forkJoin([
      this.lazyLoadService.loadStyles(`${this.settingService.data.path}/assets/module/map/leaflet.css`),
      this.lazyLoadService.loadStyles(`${this.settingService.data.path}/assets/module/map/dist/leaflet-routing-machine.css`),
      this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/leaflet.js`),
      this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/dist/leaflet-routing-machine.js`)
    ]).subscribe(x => {
      // sau do moi load 2 file custome de len code base
      forkJoin([
        this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/Control.Geocoder.js`),
        this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/dist/lrm-vmap.js`)
      ]).subscribe(x2 => {
        this.mailtripID = Number(this.ar.snapshot.queryParams.id);
        if (this.ar.snapshot.queryParams.postCode) {
          this.postCode = this.ar.snapshot.queryParams.postCode;
        } else {
          this.postCode = this.userService.userInfo.postCode;
        }
        setTimeout(() => {
          this.initMap();
        }, 500)
      })
    });

  }

  ngOnDestroy(): void {
    if (this.interval1) {
      clearInterval(this.interval1);
    }
  }

  async initMap() {
    let map = L.map('map');
    let apikey = '457756595ea907a5ed7dbc62fdda85852a1736e04f258c47';
    L.tileLayer(`https://maps.vnpost.vn/api/tm/{z}/{x}/{y}@2x.png?apikey=${apikey}`, {
      maxZoom: 20,
      attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    let option = {
      lineOptions: {
        styles: [{ color: "blue", opacity: 1, weight: 3 }],
      },
      altLineOptions: {
        styles: [
          { color: 'black', opacity: 0.15, weight: 9 },
          { color: 'white', opacity: 0.8, weight: 6 },
          { color: 'blue', opacity: 0.5, weight: 2 }
        ]
      },
      geocoder: L.Control.Geocoder.vmap(apikey),
      router: L.Routing.vmap(apikey),
      routeWhileDragging: false
    };
    let control = L.Routing.control(option).addTo(map);
    const where = { and: [] };
    const params = new PhatDeliveryPointGetByMailtripQuery({});
    params.mailtripID = this.mailtripID;
    // where loopback
    if (where.and.length > 0) {
      params.where = where;
    }
    const rs = await this.deliveryPointApi.getByMailtrip(params).toPromise();
    if (rs.success) {
      //data = [];
      this.data = rs.result;
    }

    //DUCNV thêm tọa độ xe oto
    const paramMt = new PhatMailtripDeliveryFindOneQuery({});
    paramMt.where = { and: [{ MailtripID: this.mailtripID }] }
    let rsMailtrip = await this.phatMailtripDeliveryApi.findOne(paramMt).toPromise();

    if (rsMailtrip.success) {
      //data = [];
      let paramTransport = new DanhMucTransportFindOneQuery({});
      paramTransport.where = { and: [{ transportCode: rsMailtrip.result.transportCode }] };
      this.transportCode = rsMailtrip.result.transportCode;

      let result: any = (await [rsMailtrip.result].getMapingCombobox('createdBy','transportName',this.userApi,'getComboboxFullName'))[0];
      this.transportName = result.transportName;
      const rsTransport = await this.dimTransportApi.findOne(paramTransport).toPromise();
      if (rsTransport.success) {
        var RIcon = L.icon({
          iconUrl: `${this.settingService.data.path}/assets/images/oto.png`,
          iconSize: [40, 40]
        });
        this.lat = rsTransport.result.lat;
        this.long = rsTransport.result.long;
        if (rsTransport.result.speed) {
          rsTransport.result.speed = +(rsTransport.result.speed/3.6).toFixed(2);
        }
        this.marker1 = L.marker([rsTransport.result.lat, rsTransport.result.long], { icon: RIcon }).addTo(map)
          .bindPopup(`Biển số: ${rsTransport.result.transportCode} <br/> Tốc độ: ${rsTransport.result.speed ? rsTransport.result.speed: 'không có dữ liệu'} km/h <br/> Người lái: ${this.transportName}`)
          .openPopup();

        this.interval1 = setInterval(() => {
          this.refeshLocation();
        }, 3000);
      }
    }

    //thêm thông tin phát    
    const paramsDelivery = new PhatDeliveryGetByMailtripQuery({});
    paramsDelivery.mailtripID = this.mailtripID;
    const rsDelivery = await this.deliveryApi.getByMailtrip(paramsDelivery).toPromise();
    if (rsDelivery.success) {
      this.dataDelivery = rsDelivery.result;
    }
    const paramsPOS = new DanhMucPOSFindOneQuery({ where: { and: [{ posCode: this.postCode }] } });
    const rsPOS = await this.posApi.findOne(paramsPOS).toPromise();
    if (rsPOS.success) {
      if (rsPOS.result.lat !== null && rsPOS.result.long !== null) {
        this.data.splice(0, 0, { title: 'Bưu cục phát:' + this.postCode, lat: rsPOS.result.lat, lng: rsPOS.result.long, description: 'Bưu cục phát' })
      }
    }
    control.setWaypoints(this.data);

    for (let item of this.data) {
      let marker1 = L.marker([item.lat, item.lng],).addTo(map)
        .bindPopup(item.title)
        .openPopup();

    }

    var RIcon = L.icon({
      iconUrl: `${this.settingService.data.path}/assets/images/red_marker_icon.png`,
      iconSize: [40, 40]
    });
    for (let item of this.dataDelivery) {
      let marker1 = L.marker([item.lat, item.lng], { icon: RIcon }).addTo(map)
        .bindPopup(item.title)
        .openPopup();
    }
  }

  async refeshLocation() {
    let paramTransport = new DanhMucTransportFindOneQuery({});
    paramTransport.where = { and: [{ transportCode: this.transportCode }] };
    const rs = await this.dimTransportApi.findOne(paramTransport).toPromise();
    if (rs.success) {
      if (rs.result && rs.result.lat && rs.result.long) {
        if (this.lat !== rs.result.lat || this.long !== rs.result.long) {
          this.lat = rs.result.lat;
          this.long = rs.result.long;

          let newLatLng = new L.LatLng(rs.result.lat, rs.result.long);
          this.marker1.setLatLng(newLatLng);
          if (rs.result.speed) {
            rs.result.speed = +(rs.result.speed/3.6).toFixed(2);
          }
          this.marker1.bindPopup(`Biển số: ${rs.result.transportCode} <br/> Tốc độ: ${rs.result.speed ? rs.result.speed: 'không có dữ liệu'} km/h <br/> Người lái: ${this.transportName}`);
        }
      }
    }
  }
}
