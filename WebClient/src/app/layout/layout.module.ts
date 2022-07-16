import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutes } from './layout.routing';
import { MenuModule } from '../_shared/template/menu/menu.module';
import { FooterModule } from '../_shared/template/footer/footer.module';
import { NavbarModule } from '../_shared/template/navbar/navbar.module';
import { BreadcrumbModule } from '../_shared/template/breadcrumb/breadcrumb.module';

@NgModule({
  imports: [
    CommonModule,
    MenuModule,
    FooterModule,
    NavbarModule,
    BreadcrumbModule,
    LayoutRoutes
  ],
  declarations: [LayoutComponent]
})
export class LayoutModule { }
