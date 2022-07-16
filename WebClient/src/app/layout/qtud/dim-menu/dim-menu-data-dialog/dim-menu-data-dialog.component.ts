import { DimMenuDataDialogService } from './dim-menu-data-dialog.service';
import { MenuApi, ApplicationApi, IdentityMenuCreateCommand, IdentityMenuFindOneQuery } from 'src/app/_shared/bccp-api.services';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { DialogMode, DialogService, DialogSize } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { TableConfigModel } from 'src/app/_base/models/table-config-model';
import { ActionEndpointComponent } from './action-endpoint/action-endpoint.component';


@Component({
  selector: 'app-dim-menu-data-dialog',
  templateUrl: './dim-menu-data-dialog.component.html',
  styleUrls: ['./dim-menu-data-dialog.component.scss']
})
export class DimMenuDataDialogComponent implements OnInit {
  @Input() mode: string;
  @Input() id: number;
  // tslint:disable-next-line: no-output-rename
  @Output('onClose') onClose = new EventEmitter<any>();

  public myForm: FormGroup;
  public isLoading = false;
  public isSubmit = false;
  public formOrigin: string;

  public lstStatus: any[] = [
    { value: 1, text: 'Hiển thị' },
    { value: 2, text: 'Ẩn' },
  ];
  public tableConfig: TableConfigModel = new TableConfigModel({
    keyId: 'menuTaskId',
    isAllChecked: false,
    indeterminate: false,
    itemSelected: new Set<any>()
  });

  constructor(
    private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService,
    public menuApi: MenuApi,
    public applicationApi: ApplicationApi,
    private dimMenuDataDialogService: DimMenuDataDialogService
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      code: ['', [
        ValidatorExtension.required(),
        ValidatorExtension.space(),
        ValidatorExtension.specialChar('Không được chứa kí tự đặc biệt')]],
      name: ['', [
        ValidatorExtension.required(),
        ValidatorExtension.specialChar('Không được chứa kí tự đặc biệt')]],
      applicationId: [null, [
        ValidatorExtension.required()]],
      parentId: [null],
      link: [null],
      queryParams: ['{}'],
      icon: [null],
      type: [1],
      order: [null],
      actions: this.fb.array([])
    });

    this.isLoading = true;
    if (this.id) {
      const params = new IdentityMenuFindOneQuery();
      params.init({
        where: {
          and: [
            { id: this.id }
          ]
        }
      })
      const rs = await this.menuApi.findOne(params).toPromise();
      if (rs.success) {
        for (const item of rs.result.actions) {
          this.addActionForm(item);
        }
        this.myForm.patchValue(rs.result);
      }
    }

    if (this.myForm.get('actions').value.length === 0) {
      // thêm 
      this.addActionForm({
        id: 0,
        menuId: this.id,
        actionCode: '-1',
        actionName: 'Mặc định',
        domain: '',
        description: null,
        endPoints: []
      });
    }

    if (this.mode === 'view') { this.myForm.disable(); }
    this.isLoading = false;
    this.saveHistoryForm();
  }

  async saveHistoryForm(): Promise<void> {
    this.formOrigin = JSON.stringify(this.myForm.value);
  }

  async save(): Promise<void> {
    this.myForm.textTrim();
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.getRawValue();
    this.isSubmit = true;
    if (!this.id) { // them moi
      // add
      const params = new IdentityMenuCreateCommand();
      params.init(body);
      const rs = await this.menuApi.create(params).toPromise();
      if (rs.success) {
        this.messageService.notiMessageSuccess('Thêm dữ liệu thành công');
        this.onClose.emit(body);
      } else {
        this.messageService.notiMessageError(this.myForm.bindError(rs.error));
      }
    } else { // update
      // edit
      const params = new IdentityMenuCreateCommand();
      params.init({
        id: this.id,
        ...body
      });
      const rs = await this.menuApi.update(params).toPromise();
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
    const formCurrentValue = this.myForm.value;
    if (this.formOrigin !== JSON.stringify(formCurrentValue)) {
      const rs = await this.dialogService.confirm('', 'Bạn đã thay đổi dữ liệu. bạn muốn hủy bỏ không?');
      if (!rs) { return; }
    }
    this.onClose.emit();
  }

  async saveAndNew(): Promise<void> {

  }

  getActionForm() {
    return this.myForm.get('actions') as FormArray;
  }

  async addActionForm(data: any) {
    const acctionFrom = this.getActionForm();
    const itemBuild = this.fb.group({
      id: [0],
      menuId: [this.id],
      actionCode: [null, ValidatorExtension.required()],
      actionName: [null, ValidatorExtension.required()],
      domain: [''],
      description: [null],
      endPoints: [[]]
    });

    if (data) {
      itemBuild.patchValue(data);
    }

    acctionFrom.push(itemBuild);
  }

  deleteActionForm(index: number) {
    const acctionFrom = this.getActionForm();
    acctionFrom.removeAt(index);
  }

  async editDataDialog(item: any, index: number): Promise<void> {
    const dialog = this.dialogService.openDialog(option => {
      option.title = 'Quản lý Api';
      option.size = DialogSize.xlarge;
      option.component = ActionEndpointComponent;
      option.inputs = {
        data: item.value,
        mode: this.mode
      };
    }, (eventName, eventValue) => {
      if (eventName === 'onClose') {
        this.dialogService.closeDialogById(dialog.id);
        if (eventValue) {
          const acctionFrom = this.getActionForm();
          acctionFrom.at(index).patchValue(eventValue);
          const a = acctionFrom.at(index).value;
        }
      }
    });
  }

}

