import { forkJoin } from 'rxjs';
import { LazyLoadScriptService } from './../../../../_base/servicers/lazy-load-script.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SettingService } from 'src/app/_shared/services/setting.service';

declare let L: any;
@Component({
  selector: 'app-bando-page',
  templateUrl: './bando-page.component.html',
  styleUrls: ['./bando-page.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class BandoPageComponent implements OnInit {

  constructor(
    private settingService: SettingService,
    private ar: ActivatedRoute,
    private lazyLoadService: LazyLoadScriptService
  ) { }

  async ngOnInit() {
    forkJoin([
      this.lazyLoadService.loadStyles(`${this.settingService.data.path}/assets/module/map/leaflet.css`),
      this.lazyLoadService.loadScript(`${this.settingService.data.path}/assets/module/map/leaflet.js`)
    ]).subscribe(x => {
      const toLat = this.ar.snapshot.queryParams.toLat;
      const toLong = this.ar.snapshot.queryParams.toLong;
      let toTitle = this.ar.snapshot.queryParams.toTitle;
      if(!toTitle){
        toTitle = 'Điểm phát';
      }
      const fromLat = this.ar.snapshot.queryParams.fromLat;
      const fromLong = this.ar.snapshot.queryParams.fromLong;
      if (toLat && toLong) {

        setTimeout(() => {
          this.initMap(fromLat, fromLong, toLat, toLong, toTitle);
        }, 500);
      }
    });
  }

  initMap(fromLat: string, fromLong: string, toLat: string, toLong: string, toTitle: string) {
    let mymap = L.map('map').setView([toLat, toLong], 15);
    L.tileLayer('https://maps.vnpost.vn/api/tm/{z}/{x}/{y}@2x.png?apikey=457756595ea907a5ed7dbc62fdda85852a1736e04f258c47', {
      maxZoom: 20,
      minZoom: 5,
      maxNativeZoom: 15
    }).addTo(mymap);
    let marker1 = L.marker([toLat, toLong]).addTo(mymap)
      .bindPopup(toTitle)
      .openPopup();
    if (fromLat && fromLong) {
      let marker2 = L.marker([fromLat, fromLong]).addTo(mymap)
        .bindPopup('Điểm tiếp nhận')
    }
  }

}
