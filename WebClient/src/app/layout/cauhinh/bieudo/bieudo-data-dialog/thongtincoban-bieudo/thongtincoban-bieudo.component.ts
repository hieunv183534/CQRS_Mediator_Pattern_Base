import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MessageService } from '../../../../../_base/servicers/message.service';
import { DimDashboardDatasetApi } from '../../../../../_shared/bccp-api.services';
import { ValidatorExtension } from '../../../../../_base/extensions/validator-extension';
import { DialogMode } from '../../../../../_base/servicers/dialog.service';

@Component({
  selector: 'app-thongtincoban-bieudo',
  templateUrl: './thongtincoban-bieudo.component.html',
  styleUrls: ['./thongtincoban-bieudo.component.scss']
})
export class ThongtincobanBieudoComponent implements OnInit {

  @Input() formValue: any;
  @Input() formError: any;
  @Input() mode: any;
  // tslint:disable-next-line:no-output-on-prefix
  @Output() onSubmit = new EventEmitter<any>();

  public isLoading = false;
  public isSubmit = false;
  public formOrgin: string;
  public myForm: FormGroup;
  public lstType: any[] = [
    {value: 1, text: 'Biểu đồ cột dọc (có tổng)'},
    {value: 2, text: 'Biểu đồ cột ngang'},
    {value: 3, text: 'Biểu đồ tròn'},
    {value: 4, text: 'Biểu đồ đường'},
    {value: 5, text: 'Biểu đồ cột dọc'},
    {value: 6, text: 'Biểu đồ bảng'},
    {value: 7, text: 'Biểu đồ bảng (theo dữ liệu gốc)'},

    {value: 100, text: 'Biểu đồ Custom sản lượng dịch vụ'},
    {value: 101, text: 'Biểu đồ Custom kiểm soát xe'},
    {value: 102, text: 'Biểu đồ Custom sản lượng theo tỉnh'},
    {value: 103, text: 'Biểu đồ Custom sản lượng chiều đi'},
    {value: 104, text: 'Biểu đồ Custom sản lượng chiều đến'},
    {value: 105, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn trái'},
    {value: 106, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn phải'},
    {value: 107, text: 'Biểu đồ Custom cảnh báo chậm toàn trình'},
    {value: 108, text: 'Biểu đồ Custom sản lượng tồn chưa khai thác'},
    {value: 109, text: 'Biểu đồ Custom tỉ lệ toàn trình liên tỉnh 2'},
    {value: 110, text: 'Biểu đồ Custom tỉ lệ toàn trình nội tỉnh 2'},
    {value: 111, text: 'Biểu đồ Custom tỉ lệ toàn trình nội thành 2'},
    {value: 112, text: 'Biểu đồ Custom tỉ lệ toàn trình 4vp 2'},
    {value: 113, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn trái (Cục)'},
    {value: 114, text: 'Biểu đồ Custom tỉ lệ toàn trình tròn phải (Cục)'},
  ];

  constructor(
    private fb: FormBuilder,
    private message: MessageService,
    public dimDashboardDatasetApi: DimDashboardDatasetApi
  ) { }

  async ngOnInit(): Promise<void> {
    this.myForm = this.fb.group({
      datasetId: [null, [
        ValidatorExtension.required()
      ]],
      code: ['', [
        ValidatorExtension.required(),
        ValidatorExtension.containsSpace(),
        ValidatorExtension.specialChar(),
      ]],
      type: [1, [
        ValidatorExtension.required()
      ]],
      name: ['', [
        ValidatorExtension.required(),
      ]],
      period: [1, [
        ValidatorExtension.required()
      ]],
      size: [1, [
        ValidatorExtension.required()
      ]],
      width: [6, [
        ValidatorExtension.required()
      ]],
      index: [null],
      status: [null],
      createDate: [null]
    });
    // set data to form
    if (this.formValue) {
      this.myForm.patchValue(this.formValue);
    }

    if (this.mode === DialogMode.view) {
      this.myForm.disable();
    } else if (this.mode === DialogMode.edit) {
      this.myForm.get('code').disable();
    }

    if (this.formError) {
      this.myForm.bindError(this.formError);
    }
    this.isLoading = false;
  }

  async submitForm(): Promise<void> {
    this.myForm.markAllAsDirty();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.getRawValue();
    this.isLoading = true;
    // logic api
    // đẩy dữ liệu ra ngoài form cha
    this.onSubmit.emit(body);
    this.isSubmit = false;
  }

}
