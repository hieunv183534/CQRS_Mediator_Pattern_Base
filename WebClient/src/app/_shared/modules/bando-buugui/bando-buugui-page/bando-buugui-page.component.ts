import { LazyLoadScriptService } from './../../../../_base/servicers/lazy-load-script.service';
import { SettingService } from './../../../services/setting.service';
import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { PhatItemApi, PhatItemGetLocationQuery } from 'src/app/_shared/bccp-api.services';

declare let L: any;
@Component({
  selector: 'app-bando-buugui-page',
  templateUrl: './bando-buugui-page.component.html',
  styleUrls: ['./bando-buugui-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class BandoBuuguiPageComponent implements OnInit, OnDestroy {

  marker1: any;
  itemCode: string;
  lat: number;
  long: number;

  interval1: any;

  constructor(
    private settingService: SettingService,
    private ar: ActivatedRoute,
    private lazyLoadService: LazyLoadScriptService,
    private phatItemApi: PhatItemApi
  ) { }

  ngOnDestroy(): void {
    if (this.interval1) {
      clearInterval(this.interval1);
    }
  }

  async ngOnInit() {
    forkJoin([
      this.lazyLoadService.loadStyles(`${this.settingService.data.path}/assets/module/map/leaflet.css`),
      this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/leaflet.js`)
    ]).subscribe(x => {
      this.itemCode = this.ar.snapshot.queryParams.itemCode;
      setTimeout(() => {
        this.initMap();
      }, 500);
    });
  }

  async initMap() {
    const param = new PhatItemGetLocationQuery({ itemCode: this.itemCode });
    const rs = await this.phatItemApi.getLocation(param).toPromise();
    if (rs.success) {
      if (rs.result && rs.result.lat && rs.result.long) {
        this.lat = rs.result.lat;
        this.long = rs.result.long;
        let mymap = L.map('map').setView([rs.result.lat, rs.result.long], 15);
        L.tileLayer('https://maps.vnpost.vn/api/tm/{z}/{x}/{y}@2x.png?apikey=457756595ea907a5ed7dbc62fdda85852a1736e04f258c47', {
          maxZoom: 20,
          minZoom: 5,
          maxNativeZoom: 15
        }).addTo(mymap);

        var RIcon = L.icon({
          iconUrl: `${this.settingService.data.path}/assets/images/red_marker_icon.png`,
          iconSize: [40, 40]
        });
        if (rs.result.type === 1) {
          RIcon = L.icon({
            iconUrl: `${this.settingService.data.path}/assets/images/oto.png`,
            iconSize: [40, 40]
          });
        }

        if (rs.result.speed) {
          rs.result.speed = +(rs.result.speed/3.6).toFixed(2);
        }

        this.marker1 = L.marker([rs.result.lat, rs.result.long], { icon: RIcon }).addTo(mymap)
          .bindPopup(`Biển số: ${rs.result.transportCode} <br/> Tốc độ: ${rs.result.speed ? rs.result.speed : 'không có dữ liệu'} km/h <br/> Người lái: ${rs.result.name}`)
          .openPopup();

        if (rs.result.type === 1) {
          this.interval1 = setInterval(() => {
            this.refeshLocation();
          }, 3000);
        }
      }
    }
  }

  async refeshLocation() {
    const param = new PhatItemGetLocationQuery({ itemCode: this.itemCode });
    const rs = await this.phatItemApi.getLocation(param).toPromise();
    console.log('refeshLocation', rs);
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
          this.marker1.bindPopup(`Biển số: ${rs.result.transportCode} <br/> Tốc độ: ${rs.result.speed ? rs.result.speed : 'không có dữ liệu'} km/h <br/> Người lái: ${rs.result.name}`);
        }
      }
    }
  }
}
