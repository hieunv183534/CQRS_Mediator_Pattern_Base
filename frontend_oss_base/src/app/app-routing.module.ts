import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import { LoginComponent } from 'src/app/module/core/component/auth/login/login.component';

@NgModule({
    imports: [
        RouterModule.forRoot([
          {
            path: '',
            redirectTo: '/login',
            pathMatch: 'full'
          },
          {
            path: '',
            component: LoginComponent,
            children: [
              {
                path: 'login',
                loadChildren: () => import('src/app/module/core/component/auth/auth.module').then(m => m.AuthModule)
              }
            ],
            data: {
              breadcrumb: 'Home',
            }
          },
        ], {scrollPositionRestoration: 'enabled'})
    ],
    exports: [RouterModule],
    providers: [],
})
export class AppRoutingModule {
}
