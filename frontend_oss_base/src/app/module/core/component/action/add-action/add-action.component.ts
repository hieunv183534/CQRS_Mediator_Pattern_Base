import {Component, EventEmitter, Input, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Action} from '../../../model/action.model';
import {ActionService} from '../../../service/action.service';
import { MessageService } from 'primeng/api';
import { CustomValidator } from 'src/app/shared/custom-validator/noWhitespace.class';
import { Constant } from 'src/app/shared/constants/constant.class';

@Component({
  selector: 'app-add-action',
  templateUrl: './add-action.component.html'
})
export class AddActionComponent implements OnInit {

  @Input() isVisibleAdd: boolean;
  @Input() data: any;

  formAdd: FormGroup;
  submitted: boolean;
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();
  @Output() closeAdd: EventEmitter<any> = new EventEmitter();

  actions: Action[] = [];

  constructor(private fb: FormBuilder,
              private messageService: MessageService,
              private actionService: ActionService) {
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.data != undefined) {
      this.formAdd = this.fb.group({
        actionId: [this.data.actionId],
        name: [this.data.name, Validators.required],
        nameAscii: [this.data.nameAscii, Validators.required],        
        status: [this.data.status]
      });
    } else {
      this.formAdd = this.fb.group({
        actionId: [null],
        name: [null, Validators.required],
        nameAscii: [null, [Validators.required, CustomValidator.cannotContainSpace]],        
        status: [null],
      });
    }
  }


  handleOk() {
    this.submitted = true;
    this.isVisibleAdd = true;
    const data = {
      actionId: this.formAdd.get('actionId').value,
      name: this.formAdd.get('name').value,
      nameAscii: this.formAdd.get('nameAscii').value,      
      status: this.formAdd.get('status').value
    };
    if (this.formAdd.valid) {
      // Them moi
      if(data.status == 0 || data.status == undefined) {
        this.actionService.addActions(data).subscribe(res => {
          this.actions = res;
          this.isVisibleAdd = false;
          this.submitAdd.emit(this.isVisibleAdd);
          this.submitted = false;
          this.formAdd.reset();
          this.messageService.add({severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        }, error => {
          this.messageService.add({severity:'error', summary: Constant.ERROR, detail: error.error});
        });
      } 
      // Cap nhat
      else {
        this.actionService.updateActions(data).subscribe(res => {
          this.actions = res;
          this.isVisibleAdd = false;
          this.submitAdd.emit(this.isVisibleAdd);
          this.submitted = false;
          this.formAdd.reset();
          this.messageService.add({severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_UPDATE_SUCCESS});
        }, error => {
          this.messageService.add({severity:'error', summary: Constant.ERROR, detail: error.error});
        });
      }
    }
  }

  handleCancel(): void {
    this.submitted = false;
    this.isVisibleAdd = false;
    this.closeAdd.emit();    
  }

  get f() {
    return this.formAdd.controls;
  }
}
