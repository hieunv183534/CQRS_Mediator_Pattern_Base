import {Component, EventEmitter, Input, OnInit, Output, SimpleChanges} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Action} from '../../../model/action.model';
import {ActionService} from '../../../service/action.service';
import { MessageService } from 'primeng/api';
import { CustomValidator } from 'src/app/shared/custom-validator/noWhitespace.class';
import { Constant } from 'src/app/shared/constants/constant.class';

@Component({
  selector: 'app-update-action',
  templateUrl: './update-action.component.html'
})
export class UpdateActionComponent implements OnInit {

  @Input() isVisibleUpdate: boolean;
  @Input() data: any;

  formUpdate: FormGroup;
  submitted: boolean;
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  @Output() closeUpdate: EventEmitter<any> = new EventEmitter();

  actions: Action[] = [];

  constructor(private fb: FormBuilder,
              private messageService: MessageService,
              private actionService: ActionService) {
  }

  ngOnInit(): void {
    if (this.data != undefined) {
      this.formUpdate = this.fb.group({
        actionId: [this.data.actionId],
        name: [this.data.name, Validators.required],
        nameAscii: [this.data.nameAscii, Validators.required],        
        status: [this.data.status]
      });
    } else {
      this.formUpdate = this.fb.group({
        actionId: [null],
        name: [null, Validators.required],
        nameAscii: [null, [Validators.required, CustomValidator.cannotContainSpace]],        
        status: [null],
      });
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    
  }


  handleOk() {
    this.submitted = true;
    this.isVisibleUpdate = true;
    const data = {
      actionId: this.formUpdate.get('actionId').value,
      name: this.formUpdate.get('name').value,
      nameAscii: this.formUpdate.get('nameAscii').value,      
      status: this.formUpdate.get('status').value
    };
    if (this.formUpdate.valid) {
      // Them moi
      if(data.status == 0 || data.status == undefined) {
        this.actionService.addActions(data).subscribe(res => {
          this.actions = res;
          this.isVisibleUpdate = false;
          this.submitUpdate.emit(this.isVisibleUpdate);
          this.submitted = false;
          this.formUpdate.reset();
          this.messageService.add({severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
        }, error => {
          this.messageService.add({severity:'error', summary: Constant.ERROR, detail: error.error});
        });
      } 
      // Cap nhat
      else {
        this.actionService.updateActions(data).subscribe(res => {
          this.actions = res;
          this.isVisibleUpdate = false;
          this.submitUpdate.emit(this.isVisibleUpdate);
          this.submitted = false;
          this.formUpdate.reset();
          this.messageService.add({severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_UPDATE_SUCCESS});
        }, error => {
          this.messageService.add({severity:'error', summary: Constant.ERROR, detail: error.error});
        });
      }
    }
  }

  handleCancel(): void {
    this.submitted = false;
    this.isVisibleUpdate = false;
    this.closeUpdate.emit();    
  }

  get f() {
    return this.formUpdate.controls;
  }
}
