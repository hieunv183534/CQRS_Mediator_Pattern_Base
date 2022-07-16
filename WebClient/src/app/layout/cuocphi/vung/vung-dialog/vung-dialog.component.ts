import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogMode, DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { DomesticDomesticFreightBlockFindOneQuery,
  DomesticFreightBlockApi,
  DomesticDomesticFreightBlockCreateCommand,
  DomesticDomesticFreightBlockUpdateCommand
} from '../../../../_shared/bccp-api.services';

@Component({
  selector: 'app-cuocphi-vung-dialog',
  templateUrl: './vung-dialog.component.html',
  styleUrls: ['./vung-dialog.component.scss']
})
export class VungDialogComponent implements OnInit {
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
  private domesticFreightBlockApi: DomesticFreightBlockApi,
  private dialogService: DialogService,
) { }

async ngOnInit(): Promise<void> {
  this.myForm = this.fb.group({
    domesticFreightRuleId: [null, [
      ValidatorExtension.required('Mã bảng cước không được để trống')]
    ],
    blockCode: ['', [
      ValidatorExtension.required('Mã không được để trống'),
      ValidatorExtension.space('Mã không được có khoảng trắng'),
      ValidatorExtension.specialChar('Mã không được có ký tự đặt biệt'),
      ValidatorExtension.maxLength(5, 'Mã không được nhập quá 5 ký tự')]
    ],
    blockName: ['', [
      ValidatorExtension.required('Tên vùng cước không được để trống'),
      ValidatorExtension.maxLength(50, 'Tên vùng cước không được nhập quá 50 ký tự')]
    ],
    domesticMainFreightPercent: [null, [
      ValidatorExtension.min(0, 'Không được nhỏ hơn 0'),
      ValidatorExtension.max(100, 'Không được lớn hơn 100')]
    ],
    domesticAirSurchargeFreightPercent: [null, [
      ValidatorExtension.min(0, 'Không được nhỏ hơn 0'),
      ValidatorExtension.max(100, 'không được lớn hơn 100')]
    ]
  });

  this.isLoading = true;
  if (this.id) {
    const params = new DomesticDomesticFreightBlockFindOneQuery({
      where: { and: [{ id: this.id }] }
    });
    const rs = await this.domesticFreightBlockApi.findOne(params).toPromise();
    if (rs.success) {
      this.myForm.patchValue(rs.result);
    } else {
      this.messageService.notiMessageError(rs.error);
    }
  }
  else{
    this.myForm.get('domesticFreightRuleId').setValue(this.ruleId);
  }

  if (this.mode === 'view'){
    this.myForm.disable();
  }
  else if (this.mode === 'edit') {
    this.myForm.get('blockCode').disable();
  }
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

  // bật hiệu ứng loading và disable nút submit
  this.isSubmit = true;
  if (this.mode === DialogMode.add) { // them moi
    // add
    const body = new DomesticDomesticFreightBlockCreateCommand(this.myForm.value);
    const rs = await this.domesticFreightBlockApi.create(body).toPromise();
    if (rs.success) {
      this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
      this.onClose.emit(body);
    } else {
      this.messageService.notiMessageError(this.myForm.bindError(rs.error));
    }
  } else { // update
    // edit
    const body = new DomesticDomesticFreightBlockUpdateCommand(this.myForm.value);
    body.id = this.id;
    const rs = await this.domesticFreightBlockApi.update(body).toPromise();
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
