import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SettingService } from '../../services/setting.service';

declare let L: any;
@Component({
  selector: 'app-bando',
  templateUrl: './bando.component.html',
  styleUrls: ['./bando.component.scss']
})
export class BandoComponent implements OnInit {

  @Input() item: any;
  @Output('onClose') onClose = new EventEmitter<any>();
  
  public url: string
  public nodata = false;
  constructor(
    private settingService: SettingService,
  ) { }

  ngOnInit(): void {
    this.url = `${this.settingService.data.path}/ban-do?`;
    let path = '';
    if (this.item.fromLat) {
      this.url += `${path}fromLat=${this.item.fromLat}`;
      path = '&';
    }
    if (this.item.fromLong) {
      this.url += `${path}fromLong=${this.item.fromLong}`;
      path = '&';
    }
    if (this.item.toLat) {
      this.url += `${path}toLat=${this.item.toLat}`;
      path = '&';
    }
    if (this.item.toLong) {
      this.url += `${path}toLong=${this.item.toLong}`;
      path = '&';
    }
    if(this.item.toTitle){
      this.url += `${path}toTitle=${this.item.toTitle}`;
      path = '&';
    }
    if (!this.item.toLat || !this.item.toLong) {
      this.nodata = true;
    }
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit(null);
  }
}
