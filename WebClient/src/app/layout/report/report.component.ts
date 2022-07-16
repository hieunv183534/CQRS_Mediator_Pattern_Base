import { PublicRoutes } from './../../public/public.routing';
import { DimMailRouteApi, POSApi } from './../../_shared/bccp-api.services';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { BaocaoViewDialogComponent } from '../cauhinh/baocao/baocao-view-dialog/baocao-view-dialog.component';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {

  ngOnInit() {
  }

  onActivate(event) {
    let scrollToTop = window.setInterval(() => {
      let pos = window.pageYOffset;
      if (pos > 0) {
        window.scrollTo(0, pos - 20); // how far to scroll on each step
      } else {
        window.clearInterval(scrollToTop);
      }
    }, 2);
  }
}
