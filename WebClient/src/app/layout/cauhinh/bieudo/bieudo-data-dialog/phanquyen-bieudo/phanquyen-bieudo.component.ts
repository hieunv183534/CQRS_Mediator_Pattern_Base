import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MessageService } from '../../../../../_base/servicers/message.service';
import { POSApi } from '../../../../../_shared/bccp-api.services';
import { PagingModel } from '../../../../../_base/models/response-model';
import { DialogMode, DialogService, DialogSize } from '../../../../../_base/servicers/dialog.service';
import { ThembuucucDataDialogComponent } from '../thembuucuc-data-dialog/thembuucuc-data-dialog.component';

interface DanhSachBuuCuc {
  id: string;
  settingId: string;
  postCode: string;
  posCode: string;
  posName: string;
  address: string;
  posTypeCode: string;
  posTypeName: string;
  posLevelCode: string;
  posLevelName: string;
}

@Component({
  selector: 'app-phanquyen-bieudo',
  templateUrl: './phanquyen-bieudo.component.html',
  styleUrls: ['./phanquyen-bieudo.component.scss']
})
export class PhanquyenBieudoComponent implements OnInit {

  @Input() formValue: any;
  @Input() mode: any;
  // tslint:disable-next-line:no-output-on-prefix
  @Output() onSubmit = new EventEmitter<any>();
  // tslint:disable-next-line:no-output-on-prefix
  @Output() onPreStep = new EventEmitter<any>();

  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public myForm: FormGroup;

  // đơn vị sử dụng
  public listOfData: DanhSachBuuCuc[] = [];
  public paging: PagingModel = {
    count: 0
  };

  public listPos: any = [];

  constructor(
    private fb: FormBuilder,
    private message: MessageService,
    private dialogService: DialogService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      isPermissionAll: [true]
    });
    this.isLoading = false;
    // set data to form
    if (this.formValue) {
      this.myForm.patchValue(this.formValue);
      this.listOfData = this.formValue.dashboardPermisionFullInfo ? this.formValue.dashboardPermisionFullInfo : [];
    }

    if (this.mode === DialogMode.view) {
      this.myForm.disable();
    }
  }

  async getData(value: any): Promise<void> {

  }

  async submitForm(): Promise<void> {
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    let body: any = this.myForm.value;
    // logic api
    // đẩy dữ liệu ra ngoài form cha
    body = {
      ...body,
      listPermisson: this.listOfData
    };
    this.onSubmit.emit(body);
  }

  async themBuuCuc(): Promise<void> {
    const setSelected = this.listOfData.reduce((c, x) => {
      return c.add(x.posCode);
    }, new Set());
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Chọn nhóm quyền';
      option.size = DialogSize.large;
      option.component = ThembuucucDataDialogComponent;
      option.inputs = {
        selected: setSelected,
        listSelected: this.listOfData,
        mode: DialogMode.add
      };
    }, (eventName, eventValue: any) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          this.listOfData = eventValue;
        }
      }
    });
  }

  async preStep(): Promise<void> {
    const formValue = this.myForm.getRawValue();
    formValue.listPermisson = this.listOfData;
    this.onPreStep.emit(formValue);
  }

  async removePos(value: string): Promise<void> {
    this.listOfData = this.listOfData.filter(item => item.id !== value);
  }

}
