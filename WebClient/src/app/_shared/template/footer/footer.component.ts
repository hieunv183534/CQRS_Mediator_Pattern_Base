import { SettingService } from './../../services/setting.service';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit, AfterViewInit {
  public reportApiStatus = 'checking...';
  public mobileApiStatus = 'checking...';

  ngAfterViewInit(): void {
    console.log('afterviewInit footer')
  }

  constructor(private http: HttpClient,
    private settingService: SettingService) { }

  ngOnInit() {
    this.http.get(`${this.settingService.data.reportApi}/health`).subscribe(res => {
      this.reportApiStatus = 'online';
    }, error => {
      this.reportApiStatus = error.status === 200? 'online': 'offline';
    });
    this.http.get(`${this.settingService.data.mobileApi}/health`).subscribe(res => {
      this.mobileApiStatus = 'online';
    }, error => {
      this.mobileApiStatus = error.status === 200? 'online': 'offline';
    });
  }

}
