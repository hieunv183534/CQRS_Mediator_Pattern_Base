import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { PagingModel } from 'src/app/_base/models/response-model';
import { DialogService, DialogSize, DialogMode } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { POSApi, DimShiftApi, CustomerApi, POSInternalFullApi, DanhMucPOSInternalFullGetPagingQuery, DanhMucCustomerGetPagingQuery } from 'src/app/_shared/bccp-api.services';
import { SettingService } from 'src/app/_shared/services/setting.service';
import { UserService } from 'src/app/_shared/services/user.service';
import { BaocaoViewDialogComponent } from '../../cauhinh/baocao/baocao-view-dialog/baocao-view-dialog.component';

@Component({
  selector: 'app-THCLThang',
  templateUrl: './THCLThang.component.html',
  styleUrls: ['./THCLThang.component.scss']
})
export class THCLThangComponent implements OnInit {

  @Input() posValue: any = null;
  @Input() posRequired = false;
  @Input() shiftValue: any = null;
  @Input() shiftRequired = false;
  // tslint:disable-next-line: no-output-on-prefix
  @Output() onChange = new EventEmitter<any>();

  form: FormGroup;
  public whereParentCode = { parent: "", isPos: true };
  public wherePosCode = { posCode: [], isSender: true };
  constructor(
    private fb: FormBuilder,
    private dialogService: DialogService,
    public posApi: POSApi,
    public dimShiftApi: DimShiftApi,
    private uerService: UserService,
    public customerApi: CustomerApi,
    public pOSInternalFullApi: POSInternalFullApi,
    private messageService: MessageService,
    private settingService: SettingService
  ) {}

  async ngOnInit(): Promise<void> {
    this.form = this.fb.group({
      Month: [
        null,
        [ValidatorExtension.required("Từ ngày không được bỏ trống")],
      ]
    });
  }

  async submit() {
    let myFormValue = this.form.value;

    var date = new Date(),
      y = myFormValue.Month.getFullYear(),
      m = myFormValue.Month.getMonth();
    var StartDate = new Date(y, m, 1);
    var EndDate = new Date(y, m + 1, 0);
    let Creater = this.uerService.userInfo.userName;

    const dialog = this.dialogService.openDialog(
      (option) => {
        option.title = "Xem báo cáo";
        option.size = DialogSize.full;
        option.component = BaocaoViewDialogComponent;

        //debugger;
        option.inputs = {
          fileNameDowload: "THCLThang",
          reportCode: "THCLThang",
          reportParams: JSON.stringify({
            TuNgay: StartDate,
            DenNgay: EndDate
          }),
          mode: DialogMode.view,
        };
      },
      (eventName, value: any) => {
        if (eventName === "onClose") {
          this.dialogService.closeDialogById(dialog.id);
        }
      }
    );
  }
}
