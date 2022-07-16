import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar.component';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { FormModule } from 'src/app/_base/controls/form/form.module';
import { NotificationComponent } from './conponent/notification/notification.component';
import { SeenPipe } from './conponent/notification/seen.pipe';
import { ChiTietCaLamViecModule } from 'src/app/layout/calamviec/chitietcalamviec/chitietcalamviec.module';

@NgModule({
  imports: [
    CommonModule,
    NgZorroAntdModule,
    FormModule,
    ChiTietCaLamViecModule,
    RouterModule,
  ],
  exports: [
    NavbarComponent
  ],
  declarations: [NavbarComponent, NotificationComponent, SeenPipe]
})
export class NavbarModule { }
