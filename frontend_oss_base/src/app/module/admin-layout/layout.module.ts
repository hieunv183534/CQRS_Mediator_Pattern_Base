
import { NgModule} from '@angular/core';
import {AdminLayoutComponent} from './admin-layout.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {registerLocaleData} from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);
import {RouterModule} from '@angular/router';
import {AdminLayoutRoutingModule} from './admin-layout-routing.module';
import {PerfectScrollbarModule} from "ngx-perfect-scrollbar";
import { AppTopBarComponent } from './sections/app.topbar.component';
import { MegaMenuModule } from 'primeng/megamenu';
import { AppRightMenuComponent } from './sections/app.rightmenu.component';
import {SidebarModule} from 'primeng/sidebar';
import { AppMenuComponent } from './sections/app.menu.component';
import { AppMenuitemComponent } from './sections/app.menuitem.component';
import { AppBreadcrumbService } from './sections/app.breadcrumb.service';
import {BreadcrumbModule} from 'primeng/breadcrumb';
import { AppBreadcrumbComponent } from './sections/app.breadcrumb.component';
import { AppFooterComponent } from './sections/app.footer.component';
import {MessageService} from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { SystemService } from '../core/service/system-service';

@NgModule({
  declarations: [
    AdminLayoutComponent,
    AppTopBarComponent,
    AppRightMenuComponent,
    AppMenuComponent,
    AppMenuitemComponent,
    AppBreadcrumbComponent,
    AppFooterComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild([]),
    AdminLayoutRoutingModule,
    PerfectScrollbarModule,
    MegaMenuModule,
    SidebarModule,
    BreadcrumbModule,
    ButtonModule
  ],
  providers: [AppBreadcrumbService, MessageService, SystemService]
})
export class LayoutModule {

}
