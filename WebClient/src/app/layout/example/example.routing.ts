import { Routes, RouterModule } from '@angular/router';
import { ExampleComponent } from './example.component';

const routes: Routes = [
  {
    path: '', component: ExampleComponent, children: [
      { path: '', loadChildren: () => import('./list-code/list-code.module').then(m => m.ListCodeModule) },
      { path: 'crud', loadChildren: () => import('./crud/crud.module').then(x => x.CrudModule) },
      { path: 'crud-multi-key', loadChildren: () => import('./crud-multi-key/crud-multi-key.module').then(x => x.CrudMultiKeyModule) },
      { path: 'table-tree', loadChildren: () => import('./table-tree/table-tree.module').then(x => x.TableTreeModule) },
      { path: 'basic', loadChildren: () => import('./basic/basic.module').then(x => x.BasicModule) },
      { path: 'icon', loadChildren: () => import('./icon/icon.module').then(x => x.IconModule) },
      { path: 'form-step', loadChildren: () => import('./form-step/form-step.module').then(x => x.FormStepModule) },
      { path: 'bar-code', loadChildren: () => import('./bar-code/bar-code.module').then(x => x.BarCodeModule) },
      { path: 'upload-file', loadChildren: () => import('./upload-file/upload-file.module').then(x => x.UploadFileModule) },
      { path: 'end-point-api', loadChildren: () => import('./end-point-api/end-point-api.module').then(x => x.EndPointApiModule) },
    ]
  },
];

export const ExampleRoutes = RouterModule.forChild(routes);
