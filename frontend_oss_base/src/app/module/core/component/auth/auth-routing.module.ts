import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {AuthorizedComponent} from './authorized/authorized.component';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {SsoComponent} from "./sso/sso.component";

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'sso', component: SsoComponent},
  {path: 'unauthorized', component: AuthorizedComponent},
  {path: '**', component: PageNotFoundComponent},
  {path: '**', redirectTo: '/404'},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule {
}
