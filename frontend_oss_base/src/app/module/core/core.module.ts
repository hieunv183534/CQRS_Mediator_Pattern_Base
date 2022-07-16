import {NgModule} from '@angular/core';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {BrowserModule} from '@angular/platform-browser';
import {HashLocationStrategy, LocationStrategy} from '@angular/common';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {CoreRoutingModule} from './core-routing.module';

import {SharedModule} from 'src/app/shared/shared.module';
import {APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA,} from '@angular/core';
import {LayoutModule} from '../admin-layout/layout.module';
import { GroupService } from './service/group-service';
import {AppConfigService} from 'src/app-config.service';
import {AuthModule} from './component/auth/auth.module';
import {EffectsModule} from '@ngrx/effects';
import {StoreModule} from '@ngrx/store';
import {PERFECT_SCROLLBAR_CONFIG} from 'ngx-perfect-scrollbar';
import {PerfectScrollbarConfigInterface} from 'ngx-perfect-scrollbar';
import {AuthGuard} from 'src/app/shared/guards/guards.class';
import {MenuModule as AppMenuModule} from './component/menu/menu.module';
import {PageDefaultModule} from 'src/app/shared/component/page-default/page-default.module';
import {UserModule} from './component/user/user.module';
import {RoleModule} from './component/role/role.module';
import { EntityModule } from './component/entity/entity.module';

export function configServiceFactory(config: AppConfigService) {
    return () => config.load();
  }

  
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    suppressScrollX: true,
    wheelSpeed: 1,
    wheelPropagation: true,
    minScrollbarLength: 20
  };

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        CoreRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,        

        LayoutModule,
        SharedModule,
        StoreModule.forRoot({}),
        // AuthModule,
        EffectsModule.forRoot([]),
        AppMenuModule,
        PageDefaultModule,
        UserModule,
        RoleModule,
        EntityModule
    ],
    declarations: [        
    ],
    providers: [
        {provide: LocationStrategy, useClass: HashLocationStrategy},
        GroupService,
        {
            provide: PERFECT_SCROLLBAR_CONFIG,
            useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
          },
          AppConfigService, {
            provide: APP_INITIALIZER,
            useFactory: configServiceFactory,
            deps: [AppConfigService],
            multi: true
          }, AuthGuard
    ],    
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CoreModule {
}
