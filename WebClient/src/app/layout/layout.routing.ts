import { CuocPhiModule } from './cuocphi/cuocphi.module';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      { path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
      { path: 'document', loadChildren: () => import('./document/document.module').then(x => x.DocumentModule) },
      { path: 'example', loadChildren: () => import('./example/example.module').then(x => x.ExampleModule) },
      { path: 'danhmuc', loadChildren: () => import('./danhmuc/danhmuc.module').then(x => x.DanhmucModule) },
      { path: 'cauhinh', loadChildren: () => import('./cauhinh/cauhinh.module').then(x => x.CauhinhModule) },
      { path: 'report', loadChildren: () => import('./report/report.module').then(x => x.ReportModule) },
      { path: 'cuocphi', loadChildren: () => import('./cuocphi/cuocphi.module').then(x => x.CuocPhiModule) },
      { path: 'qtud', loadChildren: () => import('./qtud/qtud.module').then(x => x.QtudModule) },
      { path: 'vanbanhotro', loadChildren: () => import('./vanbanhotro/vanbanhotro.module').then(x => x.VanbanhotroModule) },
      { path: 'canhbao', loadChildren: () => import('./canhbao/canhbao.module').then(x => x.CanhbaoModule) },
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
