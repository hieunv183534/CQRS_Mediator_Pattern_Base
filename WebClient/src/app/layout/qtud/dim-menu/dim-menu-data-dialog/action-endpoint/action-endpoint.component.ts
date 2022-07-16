import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorExtension } from 'src/app/_base/extensions/validator-extension';
import { DialogService } from 'src/app/_base/servicers/dialog.service';
import { MessageService } from 'src/app/_base/servicers/message.service';

@Component({
  selector: 'app-action-endpoint',
  templateUrl: './action-endpoint.component.html',
  styleUrls: ['./action-endpoint.component.scss']
})
export class ActionEndpointComponent implements OnInit {

  @Input() mode: string;
  @Input() data: any;
  @Output('onClose') onClose = new EventEmitter<any>();

  myForm: FormGroup;

  constructor(private fb: FormBuilder,
    private messageService: MessageService,
    private dialogService: DialogService) { }

  ngOnInit() {
    this.myForm = this.fb.group({
      id: [null],
      menuId: [null],
      actionCode: [null, ValidatorExtension.required()],
      actionName: [null, ValidatorExtension.required()],
      domain: [''],
      description: [null],
      endPoints: this.fb.array([]),
      endPointAuto:[null]
    });

    if (this.data) {
      for (const item of this.data.endPoints) {
        this.addEndpointForm(item);
      }
      this.myForm.patchValue(this.data);
    }

    this.myForm.disableMulti(['actionCode'])
  }

  closeDialog(value: any = null) {
    this.onClose.emit(value);
  }

  getEndpointForm() {
    return this.myForm.get('endPoints') as FormArray;
  }

  async addEndpointForm(data: any = null) {
    const acctionFrom = this.getEndpointForm();
    const itemBuild = this.fb.group({
      id: [0],
      actionId: [this.myForm.get('id').value],
      url: [null],
      method: [null]
    });

    if (data) {
      itemBuild.patchValue(data);
    }

    acctionFrom.push(itemBuild);
  }

  deleteEndpointForm(index: number) {
    const acctionFrom = this.getEndpointForm();
    acctionFrom.removeAt(index);
  }

  save() {
    const value = this.myForm.getRawValue();
    this.onClose.emit(value);
  }

  autoGenderEndPoint() {
    const endPointAuto = this.myForm.get('endPointAuto').value
    if (!endPointAuto) return;
    const data = endPointAuto.split('POST ​');
    //(this.myForm.get('endPoints') as FormArray).clear();
    for (const item of data) {
      if(!item.trim()){
        continue;
      }
      this.addEndpointForm({
        id: 0,
        actionId: this.myForm.get('id').value,
        method: 'POST',
        url: item.trim().replaceAll(' ','')
      })
    }
  }
}
