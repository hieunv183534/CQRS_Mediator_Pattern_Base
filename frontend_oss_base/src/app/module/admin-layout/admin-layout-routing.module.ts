import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminLayoutComponent} from './admin-layout.component';

const routes: Routes = [ 
  {
    path: '',
    component: AdminLayoutComponent,
    children: [      
      {
        path: 'welcome',
        loadChildren: () => import('src/app/shared/component/page-default/page-default.module').then(s => s.PageDefaultModule),
        data: {
          pagename: 'welcome',
          breadcrumb: 'Welcome'
        }
      },      
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminLayoutRoutingModule {
}
