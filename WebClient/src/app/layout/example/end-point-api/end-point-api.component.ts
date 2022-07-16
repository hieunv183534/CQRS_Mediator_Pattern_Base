import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-end-point-api',
  templateUrl: './end-point-api.component.html',
  styleUrls: ['./end-point-api.component.scss']
})
export class EndPointApiComponent implements OnInit {

  public listApi: any[] = [];

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.http.get('https://vnpost.ddns.net/kt1/api/specification.json').subscribe((rs: any) => {
      for (const key in rs.paths) {
        let method = rs.paths[key]['post'] ? 'POST': 'GET'
        let url = `${method} ${key}`
        if(url.indexOf('/Get') !== -1 || url.indexOf('/Find') !== -1){
          continue;
        }
        this.listApi.push(url);
      }
    });
  }

}
