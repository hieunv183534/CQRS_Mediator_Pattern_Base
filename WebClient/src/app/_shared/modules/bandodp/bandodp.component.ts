import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SettingService } from '../../services/setting.service';

declare let L: any;
@Component({
  selector: 'app-bando',
  templateUrl: './bandodp.component.html',
  styleUrls: ['./bandodp.component.scss']
})
export class BandodpComponent implements OnInit {

  @Input() item: any;
  @Input('id') id: number;
  @Output('onClose') onClose = new EventEmitter<any>();
  
  public url: string
  public nodata = false;
  constructor(
    private settingService: SettingService,
  ) { }

  ngOnInit(): void {
    this.url = `${this.settingService.data.path}/ban-do-dp?`;
    let path = '';
    this.url += `${path}id=${this.id}`;
    path = '&';   
  }

  async closeDialog(): Promise<void> {
    this.onClose.emit(null);
  }
}
