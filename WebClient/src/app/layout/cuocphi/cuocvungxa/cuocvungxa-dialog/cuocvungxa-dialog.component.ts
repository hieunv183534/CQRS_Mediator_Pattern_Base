import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DomesticDomesticFarRegionFreightStepFindOneQuery,
  DomesticDomesticFreightRuleFindOneQuery,
  DomesticFarRegionFreightStepApi,
  DomesticFreightRuleApi,
  ItemTypeApi,
  DomesticDomesticFarRegionFreightStepCreateCommand,
  DomesticDomesticFarRegionFreightStepUpdateCommand
} from '../../../../_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-cuocchinh-dialog',
  templateUrl: './cuocvungxa-dialog.component.html',
  styleUrls: ['./cuocvungxa-dialog.component.scss']
})
export class CuocvungxaDialogComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('mode') mode: string;
  // tslint:disable-next-line: no-input-rename
  @Input('id') id: number;
  // tslint:disable-next-line: no-input-rename
  @Input('ruleId') ruleId: number;
  // tslint:disable-next-line: no-output-rename no-output-on-prefix
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private domesticFarRegionFreightStepApi: DomesticFarRegionFreightStepApi,
    private domesticFreightRuleApi: DomesticFreightRuleApi,
    public itemTypeApi: ItemTypeApi,
    private dialogService: DialogService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({     
      domesticFreightRuleId: [null, [
        ValidatorExtension.required('Mã bảng cước không được để trống')]
      ],    
      fromWeight: [0, [
        ValidatorExtension.required('Từ khối lượng không được để trống')]
      ],
      toWeight: [0, [
        ValidatorExtension.required('Đến khối lượng không được để trống')]
      ],
      itemTypeCode: [null, [
        ValidatorExtension.required('Loại bưu gửi không được để trống')]
      ],
      calculationMethod: [0],
      freight: [0,[
        ValidatorExtension.required('Cước không được để trống')]],
      freightStep: [0],      
      intrenalProvinceFreight: [0],     
    });

    this.isLoading = true;
    if (this.id) {
      const params = new DomesticDomesticFarRegionFreightStepFindOneQuery({
        where: { and: [{ id: this.id }] }
      });
      const rs = await this.domesticFarRegionFreightStepApi.findOne(params).toPromise();
      if (rs.success) {
        this.myForm.patchValue(rs.result);
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    } else if (this.ruleId){
      const params = new DomesticDomesticFreightRuleFindOneQuery({
        where: { and: [{ id: this.ruleId }] }
      });
      const rs = await this.domesticFreightRuleApi.findOne(params).toPromise();
      if (rs.success) {     
        this.myForm.get('domesticFreightRuleId').setValue(this.ruleId);     
      } else {
        this.messageService.notiMessageError(rs.error);
      }
    }   
    if (this.mode === 'view'){
      this.myForm.disable();
    }  
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrgin = JSON.stringify(this.myForm.value);
  }

  async submitForm(): Promise<void> {
    debugger;
    // hiển thị toàn bộ lỗi control
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }

    // bật hiệu ứng loading và disable nút submit
    this.isSubmit = true;
    if (this.mode === DialogMode.add) { // them moi
      // add
      const body = new DomesticDomesticFarRegionFreightStepCreateCommand(this.myForm.value);   
      const rs = await this.domesticFarRegionFreightStepApi.create(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const body = new DomesticDomesticFarRegionFreightStepUpdateCommand(this.myForm.value);
      body.id = this.id;
      const rs = await this.domesticFarRegionFreightStepApi.update(body).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Lưu dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    }
    this.isSubmit = false;
  }

  async closeDialog(): Promise<void> {
    if (this.formOrgin !== JSON.stringify(this.myForm.value)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit(null);
  }
}
