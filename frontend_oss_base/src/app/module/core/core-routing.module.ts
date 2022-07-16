import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import {AdminLayoutComponent} from 'src/app/module/admin-layout/admin-layout.component';

@NgModule({
    imports: [
        RouterModule.forRoot([
          {
            path: '',
            component: AdminLayoutComponent,
            children: [
              {
                path: 'user',
                loadChildren: () => import('../core/component/user/user.module').then(m => m.UserModule),
                data: {
                  pagename: 'users_page_name',
                  breadcrumb: 'Users'
                }
              },
              {
                path: 'system',
                loadChildren: () => import('../core/component/system/system.module').then(m => m.SystemModule),
                data: {
                  pagename: 'systems_page_name',
                  breadcrumb: 'System'
                }
              },     
              {
                path: 'role',
                loadChildren: () => import('../core/component/role/role.module').then(m => m.RoleModule),
                data: {
                  pagename: 'roles_page_name',
                  breadcrumb: 'Roles'
                }
              },
              {
                path: 'group',
                loadChildren: () => import('../core/component/group/group.module').then(m => m.GroupModule),
                data: {
                  pagename: 'groups_page_name',
                  breadcrumb: 'Groups'
                }
              },
              {
                path: 'menu',
                loadChildren: () => import('../core/component/menu/menu.module').then(m => m.MenuModule),
                data: {
                  pagename: 'menus_page_name',
                  breadcrumb: 'Menus'
                }
              },
              {
                path: 'action',
                loadChildren: () => import('../core/component/action/action.module').then(m => m.ActionModule),
                data: {
                  pagename: 'actions_page_name',
                  breadcrumb: 'Actions'
                },
              },
              
              {
                path: 'entities',
                loadChildren: () => import('../core/component/entity/entity.module').then(m => m.EntityModule),
                data: {
                  pagename: 'page_name.entity',
                  breadcrumb: 'Entities'
                }
              },
            ]
          },
        ], {scrollPositionRestoration: 'enabled'})
    ],
    exports: [RouterModule],
    providers: [],
})
export class CoreRoutingModule {
}
