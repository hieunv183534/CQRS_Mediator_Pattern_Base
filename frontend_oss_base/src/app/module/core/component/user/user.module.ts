import { NgModule} from '@angular/core';
import {UserComponent} from './user-view/user.component';
import {UserRoutingModule} from './user-routing.module';
import {UserService} from '../../service/user-service';
import {SharedModule} from 'src/app/shared/shared.module';
import { ToolbarModule } from 'primeng/toolbar';
import { ToastModule } from 'primeng/toast';
import { UpdateUserComponent } from './update-user/update-user.component';
import { AddUserComponent } from './add-user/add-user.component';
import {DatePipe} from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TableModule } from 'primeng/table';
// import {UserProfileComponent} from './user-profile/user-profile.component';
import { RolesUserModalComponent } from './roles-user-modal/roles-user-modal.component';
// import { UserImportComponent } from './user-import/user-import.component';
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
import {FieldsetModule} from 'primeng/fieldset';
import {GMapModule} from 'primeng/gmap';

@NgModule({
  declarations: [
    UserComponent,
    UpdateUserComponent,
    AddUserComponent,
    // UserProfileComponent,
    RolesUserModalComponent,
    // UserImportComponent
  ],
  imports: [
    UserRoutingModule,
    SharedModule,
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
    TreeModule,
      FieldsetModule,
      GMapModule
  ],
  providers: [UserService, DatePipe]

})
export class UserModule {

}
