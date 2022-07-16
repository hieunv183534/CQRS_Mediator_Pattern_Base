import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode,DialogSize, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../../_shared/services/user.service';
import { 
  DocumentsApi,HoTroDocumentsUpdateCommand, PhatDeliveryGetSamplePagingQuery, PhatDeliveryDeleteCommand, 
  HoTroDocumentsFindOneQuery, HoTroDocumentsCreateCommand
} from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-chuyentiep-data-dialog',
  templateUrl: './quanlyvanban-data-dialog.component.html',
  styleUrls: ['./quanlyvanban-data-dialog.component.scss']
})
export class QuanlyvanbanDataDialogComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public isAll = false;
  public formOrgin: string;
  public maxIndex: number;
  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,  
    private dialogService: DialogService,
    private userService: UserService,   
    public documentsApi: DocumentsApi,
    
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      Title: [null,[
        ValidatorExtension.required('Phải nhập tiêu đề!')]],
      Content:  [null,[
        ValidatorExtension.required('Phải nhập nội dung!')]],
      DateCreated: [null,[
        ValidatorExtension.required('Phải nhập ngày tạo!')]],
      fileURL: [null,[
        ValidatorExtension.required('Phải chọn văn bản tải lên!')]],
      isAll: null,     
    });
    // tslint:disable-next-line: no-debugger
    debugger;
    this.isLoading = true;
    if (this.id) {
      const params = new HoTroDocumentsFindOneQuery({
        where: { and: [{ iD: this.id }] }
      });
      const rs = await this.documentsApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue({
          DateCreated: rs.result.dateCreated,
          Title: rs.result.title,
          fileURL: rs.result.url,
          Content: rs.result.content});
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    if (this.mode === 'edit') {
      // logic view edit in here
    }
    this.isLoading = false;
    this.saveHistoryForm();
  }
  async deliveryChange(): Promise<void> {
    const formData: any = this.myForm.getRawValue();
    this.isAll = formData.isAll;
  }  
 
  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
     //hiển thị toàn bộ lỗi control
     this.myForm.markAllAsDirty();
     if (this.myForm.invalid) { return; }
     const formData: any = this.myForm.getRawValue();
     if(formData.DateCreated > new Date())
     {
      this.messageService.notiMessageError('Ngày tạo văn bản không được sau thời điểm hiện tại.');
      return;
     }
     // lấy max index
     debugger;
    if (this.mode == 'add') {         
         //lưu dữ liệu
         const body = new HoTroDocumentsCreateCommand({
           content: formData.Content,
           title: formData.Title,
           dateCreated: formData.DateCreated,   
           url: formData.fileURL,   
           posCode: this.userService.userInfo.postCode,      
         });
         // add
         const rs = await this.documentsApi.create(body).toPromise();
         if (rs.success) {
          this.id = rs.result;
          this.messageService.notiMessageSuccess('Nhập thông tin văn bản thành công');
           this.onClose.emit(this.id);
         } else {
           this.messageService.notiMessageError(this.myForm.bindError(rs.error));
         }
       }
       else {
        
         // lưu thông tin phát
         const body = new HoTroDocumentsUpdateCommand({
           id: this.id,
           content: formData.Content,
           title: formData.Title,
           posCode: this.userService.userInfo.postCode,
           url: formData.fileURL,   
           dateCreated: formData.DateCreated,
         });
         // add
         const rs = await this.documentsApi.update(body).toPromise();
         if (rs.success) {
          this.id = rs.result;
          this.messageService.notiMessageSuccess('Sửa thông tin văn bản thành công');
           this.onClose.emit(this.id);
         } else {
           this.messageService.notiMessageError(this.myForm.bindError(rs.error));
         }
     }
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
