import { DbsTitleToantrinhBonvp2Component } from './dash-board-custom/dbs-title-toantrinh-bonvp2/dbs-title-toantrinh-bonvp2.component';
import { DbsTileToantrinhNoitinh2Component } from './dash-board-custom/dbs-tile-toantrinh-noitinh2/dbs-tile-toantrinh-noitinh2.component';
import { DbsTileToantrinhLientinh2Component } from './dash-board-custom/dbs-tile-toantrinh-lientinh2/dbs-tile-toantrinh-lientinh2.component';
import { DbsTileToantrinhNoithanh2Component } from './dash-board-custom/dbs-tile-toantrinh-noithanh2/dbs-tile-toantrinh-noithanh2.component';
import { DbsSanLuongChuaKhaiThacComponent } from './dash-board-custom/dbs-san-luong-chua-khai-thac/dbs-san-luong-chua-khai-thac.component';
import { DbsCanhbaoToantrinhComponent } from './dash-board-custom/dbs-canhbao-toantrinh/dbs-canhbao-toantrinh.component';
import { DbsTileToantrinhLientinhComponent } from './dash-board-custom/dbs-tile-toantrinh-lientinh/dbs-tile-toantrinh-lientinh.component';
import { DsbTileToantrinhNoitinhComponent } from './dash-board-custom/dsb-tile-toantrinh-noitinh/dsb-tile-toantrinh-noitinh.component';
import { DbsSanLuongDiComponent } from './dash-board-custom/dbs-san-luong-di/dbs-san-luong-di.component';
import { DbsSanLuongDenComponent } from './dash-board-custom/dbs-san-luong-den/dbs-san-luong-den.component';
import { DbsSanLuongDichvuComponent } from './dash-board-custom/dbs-san-luong-dichvu/dbs-san-luong-dichvu.component';
import { DbsSanLuongTinhComponent } from './dash-board-custom/dbs-san-luong-tinh/dbs-san-luong-tinh.component';
import { DsbTrangThaiXeComponent } from './dash-board-custom/dsb-trang-thai-xe/dsb-trang-thai-xe.component';
import { DashBoardTableRawComponent } from './dash-board-table-raw/dash-board-table-raw.component';
import { DashBoardStackedComponent } from './dash-board-stacked/dash-board-stacked.component';
import { DashBoardPieComponent } from './dash-board-pie/dash-board-pie.component';
import { DashBoardColumnComponent } from './dash-board-column/dash-board-column.component';
import { DashBoardLineComponent } from './dash-board-line/dash-board-line.component';
import { DashBoardStockComponent } from './dash-board-stock/dash-board-stock.component';
import { DbsTileToantrinhNoitinh3Component } from './dash-board-custom/dbs-tile-toantrinh-noitinh3/dbs-tile-toantrinh-noitinh3.component';
import { DbsTileToantrinhLientinh3Component } from './dash-board-custom/dbs-tile-toantrinh-lientinh3/dbs-tile-toantrinh-lientinh3.component';

import { DashboardChapNhanGuiComponent } from './dashboard-chapnhangui/dashboard-chapnhangui.component';
import { DashboardChuyenThuComponent } from './dashboard-chuyenthu/dashboard-chuyenthu.component';
import { DashboardTuiThuComponent } from './dashboard-tuithu/dashboard-tuithu.component';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutes } from './home.routing';
import { HighchartsChartModule } from 'highcharts-angular';
import { FormsModule } from '@angular/forms';
import { NzSpinModule } from 'ng-zorro-antd';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { DongchuyenthuDataDialogModule } from '../phatbuugui/thongtinphat/dongchuyenthu-data-dialog/dongchuyenthu-data-dialog.module';

@NgModule({
  imports: [
    CommonModule,
    HighchartsChartModule,
    FormsModule,
    NzSpinModule,
    FormModule,
    DongchuyenthuDataDialogModule,
    HomeRoutes
  ],
  declarations: [
    HomeComponent,
    DashboardChapNhanGuiComponent,
    DashboardChuyenThuComponent,
    DashboardTuiThuComponent,
    DashBoardLineComponent,
    DashBoardStockComponent,
    DashBoardColumnComponent,
    DashBoardPieComponent,
    DashBoardStackedComponent,
    DashBoardTableRawComponent,
    DsbTrangThaiXeComponent,
    DbsSanLuongTinhComponent,
    DbsSanLuongDichvuComponent,
    DbsSanLuongDenComponent,
    DbsSanLuongDiComponent,
    DbsTileToantrinhLientinhComponent,
    DsbTileToantrinhNoitinhComponent,
    DbsCanhbaoToantrinhComponent,
    DbsSanLuongChuaKhaiThacComponent,
    DbsTileToantrinhNoithanh2Component,
    DbsTileToantrinhLientinh2Component,
    DbsTileToantrinhNoitinh2Component,
    DbsTitleToantrinhBonvp2Component,
    DbsTileToantrinhLientinh3Component,
    DbsTileToantrinhNoitinh3Component
  ]
})
export class HomeModule { }
