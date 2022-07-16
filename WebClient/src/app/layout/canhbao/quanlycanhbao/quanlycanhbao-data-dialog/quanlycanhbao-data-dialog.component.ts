import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode,DialogSize, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../../_shared/services/user.service';
import { 
  WarningApi, HoTroWarningFindOneQuery
} from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-quanlycanhbao-data-dialog',
  templateUrl: './quanlycanhbao-data-dialog.component.html',
  styleUrls: ['./quanlycanhbao-data-dialog.component.scss']
})
export class QuanlycanhbaoDataDialogComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public maxIndex: number;
  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,  
    private dialogService: DialogService,
    private userService: UserService,    
    public warningApi: WarningApi,
    
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      WarningType: null,
      WarningLevel: null,
      WarningContent: null,
      DateCreated: null,     
    });
    // tslint:disable-next-line: no-debugger
    debugger;
    this.isLoading = true;
    if (this.id) {
      const params = new HoTroWarningFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.warningApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue({
          DateCreated: rs.result.dateCreated,
          WarningType: rs.result.warningTypeName,
          WarningLevel: rs.result.warningLevelName,
          WarningContent: rs.result.warningContent,
          });
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      // logic view edit in here
    }
    this.isLoading = false;
   
  }
  async submitForm(): Promise<void> {
     //hiển thị toàn bộ lỗi control
    //  this.myForm.markAllAsDirty();
    //  if (this.myForm.invalid) { return; }
    //  const formData: any = this.myForm.getRawValue();
    //  // lấy max index
    //  debugger;
    // if (this.mode == 'add') {
    //      // lưu thông tin chuyển hoàn
    //       const paramsdeletereturn = new PhatItemReturnDeleteCommand({
    //         itemID: [this.id],
    //       });
    //       const rsdir = await this.itemReturnApi.delete(paramsdeletereturn).toPromise();
    //       debugger;
    //       const bodyreturn = new PhatItemReturnCreateCommand({
    //         itemID: this.id,
    //         itemCode: formData.ItemCode,
    //         reason: formData.Note,
    //         returnDate: formData.DeliveryDate,
    //         receiverFullname: formData.SenderName,
    //         receiverAddress: formData.SenderAddress,
    //         posCode: this.userService.userInfo.postCode,
    //         note: formData.Note,
    //         createTime: new Date(),
    //         lastUpdatedTime: new Date(),
    //       });
    //       // add
    //       const rscit = await this.itemReturnApi.create(bodyreturn).toPromise();
    //       if (rscit.success) {
    //         // cap nhat trang thai buu gui
    //         const bodyitem = new PhatItemUpdateStatusReturnCommand();
    //         bodyitem.itemID = this.id;             
    //         const rs = await this.itemApi.updateStatusReturn(bodyitem).toPromise();
    //       } else {
    //         this.messageService.notiMessageError(this.myForm.bindError(rscit.error));
    //       }

    //      const rsmax = await this.deliveryApi.getMaxIndex(new PhatDeliveryGetMaxIndexQuery({
    //        toPOSCode: this.userService.userInfo.postCode,
    //        itemID: this.id
    //      })).toPromise();
    //      this.maxIndex = rsmax.result;
    //      //lưu dữ liệu
    //      const body = new PhatDeliveryCreateCommand({
    //        id: new PhatDeliveryCreateCommandKey({ itemID: this.id, toPOSCode: this.userService.userInfo.postCode.toString(), deliveryIndex: this.maxIndex + 1 }),
    //        itemCode: formData.ItemCode,
    //        deliveryDate: formData.DeliveryDate,
    //        isDeliverable: false,
    //        deliveryUser: this.userService.userInfo.userName.toString(),
    //        causeCode: formData.Cause,
    //        solutionCode: formData.Solution,
    //        //mailtripID: this.mailtripID
    //      });
    //      // add
    //      const rs = await this.deliveryApi.create(body).toPromise();
    //      if (rs.success) {
    //        this.id = rs.result.itemID;
    //        this.messageService.notiMessageSuccess('Nhập thông tin phát thành công');
    //        this.onClose.emit(this.id);
    //      } else {
    //        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
    //      }
    //    }
    //    else {
        
    //      // lưu thông tin phát
    //      const body = new PhatDeliveryUpdateCommand({
    //        id: new PhatDeliveryUpdateCommandKey({ itemID: this.id, toPOSCode: this.userService.userInfo.postCode.toString(), deliveryIndex: this.maxIndex }),
    //        itemCode: formData.ItemCode,
    //        deliveryDate: formData.DeliveryDate,
    //        isDeliverable: formData.isDelivery,
    //        deliveryUser: this.userService.userInfo.userName.toString(),
    //        causeCode: formData.Cause,
    //        solutionCode: formData.Solution,
    //        //mailtripID: this.mailtripID
    //      });
    //      // add
    //      const rs = await this.deliveryApi.update(body).toPromise();
    //      if (rs.success) {
    //        this.id = rs.result.itemID;
    //        this.messageService.notiMessageSuccess('Nhập thông tin phát thành công');
    //        this.onClose.emit(this.id);
    //      } else {
    //        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
    //      }
    //  }
  }

  async closeDialog(): Promise<void> {
       this.onClose.emit(null);
  }

}
