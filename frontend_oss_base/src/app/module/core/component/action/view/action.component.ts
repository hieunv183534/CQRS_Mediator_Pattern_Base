import {Component, Input, OnInit} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {Action} from 'src/app/module/core/model/action.model';
import { ActionService } from 'src/app/module/core/service/action.service';
import { MessageService } from 'primeng/api';
import { Constant } from 'src/app/shared/constants/constant.class';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  providers: [MessageService]
})
export class ActionComponent implements OnInit {
  actions: Action[] = [];
  allActions: Action[] = [];
  selectedActions : Action[] = [];
  data: any;
  loading: boolean;  
  listPermission: any;  
  @Input() isView = false;
  action: Action;
  checkDelete = true;
  checkAdd = true;
  checkUpdate = true;  
  submitted: boolean;
  isVisibleAdd = false;
  isVisibleUpdate = false;  
  cols: any[];

  getListAction(reset: boolean = false) {    
    this.actionService.getAction(1, 1).subscribe(res => {
      if (res !== null) {
        this.allActions = res;
        this.loading = false;        
      }
    });
  }

  constructor(
    public translate: TranslateService,
    private actionService: ActionService,
    private messageService: MessageService,
  ) {    
    this.cols = [
      { field: 'name', header: 'Code' },      
      { field: 'nameAscii', header: 'nameAscii' } 
    ];

  }

  async getListPermission() {
    let arrayPermission: any;
    // await this.actionServices.getActionByScreen(Constant.SCREEN.ROLE).then(value => {
    //   arrayPermission = value;
    //   this.listPermission = new Set(arrayPermission);
    // });
    // this.checkAdd = this.listPermission.has(Constant.ACTION2.ADD);
    // this.checkDelete = this.listPermission.has(Constant.ACTION2.DELETE);
    // this.checkUpdate = this.listPermission.has(Constant.ACTION2.EDIT);    
  }

  ngOnInit(): void {     
    this.get();
    this.getListPermission();
    this.getListAction();
  }

  get() {
    this.translate.use(this.translate.currentLang).subscribe(data => {
      this.data = data;
    });
  }

  getRowIndex(index, pageIndex, pageSize) {
    return index + 1 + pageSize * (pageIndex - 1);
  }

  searchActions() {
    this.loading = true;
    this.getListAction();    
  }

  deleteActions() {    
    let ids = [];
    this.selectedActions.forEach(item => {
      ids.push(item.actionId);
    });
    this.actionService.deleteAction(ids).subscribe(res => {
      this.getListAction();
      this.messageService.add({key: "toastActionView", severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_DELETE_SUCCESS});
    }, error => {
      this.messageService.add({key: "toastActionView", severity:'error', summary: Constant.SUCCESS, detail: error.error});
    });
    
  }

  showModalUpdate(data) {    
    this.isVisibleUpdate = true;
    this.action = data;
  }

  showModalAdd() {    
    this.isVisibleAdd = true;
  }

  updateActions(value) {
    this.isVisibleAdd = true;
    this.submitted = true;
    this.actions = [
      ...this.allActions,
      value
    ];
  }

  closeModelAdd() {
    this.isVisibleAdd = false;
  }

  closeModelUpdate() {
    this.isVisibleUpdate = false;
  }

}
