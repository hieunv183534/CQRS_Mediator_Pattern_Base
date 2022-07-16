import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {SharedModule} from 'src/app/shared/shared.module';
import {EntityComponent} from "./view/entity.component";
import {EntityService} from "../../service/entity.service";
import { EntityRoutingModule } from './entity-routing.module';
import {AddEntityComponent} from "./add/add-entity.component";
import { UpdateEntityComponent } from './update/update-entity.component';

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
import {MenuModule} from 'primeng/menu';
import { TreeModule } from 'primeng/tree';
import { ConfirmationService } from 'primeng/api';
import { Constant } from 'src/app/shared/constants/constant.class';

@NgModule({
  declarations: [
    EntityComponent,
    AddEntityComponent,
    UpdateEntityComponent
    ],
  imports: [
    SharedModule,  
    EntityRoutingModule,
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
    MenuModule,
    TreeModule
  ],
  providers: [
    // { provide: 'apiName', useValue: Constant.API_PMS_CORE },
    { provide: 'apiName', useValue: Constant.API_BASE },
    EntityService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class EntityModule {

}
