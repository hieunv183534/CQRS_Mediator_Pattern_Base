import { element } from 'protractor';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../../_shared/services/user.service';
import { DomesticValueAddedServiceFreightPerItemApi,
  DomesticDomesticValueAddedServiceFreightPerItemCreateCommand,
  DomesticDomesticValueAddedServiceFreightPerItemUpdateCommand,
  DomesticDomesticValueAddedServiceFreightPerItemFindOneQuery} from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-motbuugi',
  templateUrl: './motbuugui.component.html',
  styleUrls: ['./motbuugui.component.scss']
})
export class MotbuuguiComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-input-rename
  @Input('vascode') vascode: string;
  // tslint:disable-next-line: no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public status = 0;
  private domesticValueAddedServiceFreightPerItemId: number;
  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    public domesticValueAddedServiceFreightPerItemApi: DomesticValueAddedServiceFreightPerItemApi,
    private dialogService: DialogService,
    public userService: UserService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      freight: [null, [ValidatorExtension.required(),
        ValidatorExtension.min(0,'Cước không được nhỏ hơn 0')]],
      minimumFreight: [null,[ValidatorExtension.min(0,'Cước không được nhỏ hơn 0')]]    
    });
 
    this.isLoading = true;
    if (this.id) {
      const params = new DomesticDomesticValueAddedServiceFreightPerItemFindOneQuery({
        where: { and: [{ valueAddedServiceCode: this.vascode },{ domesticFreightRuleId: this.id }] }
      });
      const rs = await this.domesticValueAddedServiceFreightPerItemApi.findOne(params).toPromise();
      if (rs.success) {
        if(rs.result)
        {
          this.myForm.patchValue({
            freight: rs.result.freightPerItem,
            minimumFreight: rs.result.minimumFreight          
            });
            this.domesticValueAddedServiceFreightPerItemId=rs.result.domesticValueAddedServiceFreightPerItemCode;
        }
        
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }
    if (this.mode === 'view') { this.myForm.disable(); }    
    this.isLoading = false;
    this.saveHistoryForm();
  }  
  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
    // hiển thị toàn bộ lỗi control
    
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const formData: any = this.myForm.getRawValue();
    debugger;
   
    if (this.domesticValueAddedServiceFreightPerItemId) {
      const body = new DomesticDomesticValueAddedServiceFreightPerItemUpdateCommand({
        domesticValueAddedServiceFreightPerItemCode: this.domesticValueAddedServiceFreightPerItemId,
        valueAddedServiceCode: this.vascode,
        freightPerItem: formData.freight,
        minimumFreight: formData.minimumFreight,
        domesticFreightRuleId: this.id      
      });
      const rs = await this.domesticValueAddedServiceFreightPerItemApi.update(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Sửa dữ liệu thành công'); 
        this.onClose.emit(this.id);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }

    }
    else
    {
      const body = new DomesticDomesticValueAddedServiceFreightPerItemCreateCommand({
        valueAddedServiceCode: this.vascode,
        freightPerItem: formData.freight,
        minimumFreight: formData.minimumFreight,
        domesticFreightRuleId: this.id      
      });
      const rs = await this.domesticValueAddedServiceFreightPerItemApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công'); 
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
