import {NgModule} from '@angular/core';
// import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import {SharedModule} from 'src/app/shared/shared.module';
import {AuthRoutingModule} from './auth-routing.module';
import {LoginComponent} from './login/login.component';
import {AuthorizedComponent} from './authorized/authorized.component';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {ServerErrorComponent} from './server-error/server-error.component';
import {AuthService} from '../../service/auth.service';
import {StoreModule} from '@ngrx/store';
import {authReducer} from './redux/auth.reducer';
import {EffectsModule} from '@ngrx/effects';
import {AuthEffects} from './redux/auth.effects';
import {clearState} from 'src/app/module/admin-layout/admin-layout.component';
import {SsoComponent} from "./sso/sso.component";
import {ButtonModule} from 'primeng/button';
import {InputMaskModule} from 'primeng/inputmask';
import {InputTextModule} from 'primeng/inputtext';
import {PanelModule} from 'primeng/panel';
import { TagModule } from 'primeng/tag';

@NgModule({
  declarations: [
    LoginComponent,
    AuthorizedComponent,
    PageNotFoundComponent,
    ServerErrorComponent,
    SsoComponent,
  ],
  imports: [
      AuthRoutingModule,
      SharedModule,
      ButtonModule,
      InputMaskModule,
      InputTextModule,
      PanelModule,
      TagModule,
      StoreModule.forFeature(
          'auth', authReducer, {metaReducers: [clearState]}
      ), EffectsModule.forFeature([AuthEffects])
  ],
  providers: [AuthService]

})
export class AuthModule {
}
