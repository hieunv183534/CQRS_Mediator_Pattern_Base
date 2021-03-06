import { element } from 'protractor';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { UserService } from './../../../../_shared/services/user.service';
import { DomesticValueAddedServiceFreightPercentMainFreightApi,
  DomesticDomesticValueAddedServiceFreightPercentMainFreightCreateCommand,
  DomesticDomesticValueAddedServiceFreightPercentMainFreightUpdateCommand,
  DomesticDomesticValueAddedServiceFreightPercentMainFreightFindOneQuery} from 'src/app/_shared/bccp-api.services';

@Component({
  selector: 'app-phantramcuocchinh',
  templateUrl: './phantramcuocchinh.component.html',
  styleUrls: ['./phantramcuocchinh.component.scss']
})
export class PhantramcuocchinhComponent implements OnInit {

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
  private domesticValueAddedServiceFreightPercentMainFreightId: number;
  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    public domesticValueAddedServiceFreightPercentMainFreightApi: DomesticValueAddedServiceFreightPercentMainFreightApi,
    private dialogService: DialogService,
    public userService: UserService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      percentMainFreight: [null, [ValidatorExtension.required(),
                                  ValidatorExtension.min(0,'C?????c kh??ng ???????c nh??? h??n 0')]]
    });
 
    this.isLoading = true;
    if (this.id) {
      const params = new DomesticDomesticValueAddedServiceFreightPercentMainFreightFindOneQuery({
        where: { and: [{ valueAddedServiceCode: this.vascode },{ domesticFreightRuleId: this.id }] }
      });
      const rs = await this.domesticValueAddedServiceFreightPercentMainFreightApi.findOne(params).toPromise();
      if (rs.success) {
        if(rs.result)
        {
          this.myForm.patchValue({
            percentMainFreight: rs.result.percentMainFreight            
            });
            this.domesticValueAddedServiceFreightPercentMainFreightId=rs.result.id;
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
    // hi???n th??? to??n b??? l???i control
    
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const formData: any = this.myForm.getRawValue();
    debugger;
   
    if (this.domesticValueAddedServiceFreightPercentMainFreightId) {
      const body = new DomesticDomesticValueAddedServiceFreightPercentMainFreightUpdateCommand({
        id: this.domesticValueAddedServiceFreightPercentMainFreightId,
        valueAddedServiceCode: this.vascode,
        percentMainFreight: formData.percentMainFreight,
        domesticFreightRuleId: this.id      
      });
      const rs = await this.domesticValueAddedServiceFreightPercentMainFreightApi.update(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('S???a d??? li???u th??nh c??ng'); 
        this.onClose.emit(this.id);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }

    }
    else
    {
      const body = new DomesticDomesticValueAddedServiceFreightPercentMainFreightCreateCommand({
        valueAddedServiceCode: this.vascode,
        percentMainFreight: formData.percentMainFreight,
        domesticFreightRuleId: this.id      
      });
      const rs = await this.domesticValueAddedServiceFreightPercentMainFreightApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Th??m d??? li???u th??nh c??ng'); 
        this.onClose.emit(this.id);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }    
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'B???n ???? thay ?????i d??? li???u. b???n mu???n h???y b??? kh??ng?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }

}
