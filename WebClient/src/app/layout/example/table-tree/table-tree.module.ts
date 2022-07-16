import { FormModule } from './../../../_base/controls/form/form.module';
import { TableTreeRoutes } from './table-tree.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableTreeComponent } from './table-tree.component';
import { NzTableModule } from 'ng-zorro-antd';

@NgModule({
  imports: [
    CommonModule,
    FormModule,
    NzTableModule,
    TableTreeRoutes
  ],
  declarations: [TableTreeComponent]
})
export class TableTreeModule { }
