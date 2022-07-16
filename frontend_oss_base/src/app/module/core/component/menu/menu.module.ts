import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {SharedModule} from 'src/app/shared/shared.module';
import { ViewMenuComponent } from './view-menu/view-menu.component';
import {MenuRoutingModule} from './menu-routing.module';
import {MenuService} from '../../service/menu.service';
import { AddMenuComponent } from './add-menu/add-menu.component';
import { UpdateMenuComponent } from './update-menu/update-menu.component';
import { ToolbarModule } from 'primeng/toolbar';
import { ToastModule } from 'primeng/toast';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TableModule } from 'primeng/table';
import {InputNumberModule} from 'primeng/inputnumber';
import {InputMaskModule} from 'primeng/inputmask';
import {InputSwitchModule} from 'primeng/inputswitch';
import {InputTextModule} from 'primeng/inputtext';
import {InputTextareaModule} from 'primeng/inputtextarea';
import { FileUploadModule } from 'primeng/fileupload';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { DividerModule } from 'primeng/divider';
import {MessagesModule} from 'primeng/messages';
import {MessageModule} from 'primeng/message';
import {TooltipModule} from 'primeng/tooltip';
import {OverlayPanelModule} from 'primeng/overlaypanel';
import {SplitButtonModule} from 'primeng/splitbutton';
import {MenuModule as PrimeNgMenuModule} from 'primeng/menu';
import { TreeModule } from 'primeng/tree';
import { TreeTableModule } from 'primeng/treetable';
import {TreeSelectModule} from 'primeng/treeselect';
import { ConfirmationService } from 'primeng/api';
@NgModule({
  declarations: [
    ViewMenuComponent,
    AddMenuComponent,
    UpdateMenuComponent,    
  ],
  imports: [
    SharedModule,
    MenuRoutingModule,
    ToolbarModule,
    ToastModule,
    DialogModule,
    ConfirmDialogModule,
    TableModule,
    InputNumberModule,
    InputMaskModule,
    InputSwitchModule,
    InputTextModule,
    InputTextareaModule,
    FileUploadModule,
    MultiSelectModule,
    DropdownModule,
    TagModule,
    DividerModule,
    MessageModule,
    MessagesModule,
    TooltipModule,
    OverlayPanelModule,
    SplitButtonModule,
    PrimeNgMenuModule,
    TreeModule,
    TreeTableModule,
    TreeSelectModule
  ],
  providers: [MenuService],
  exports: [
    // IconSelectComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class MenuModule {

}
