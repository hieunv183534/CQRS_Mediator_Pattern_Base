import {Component, Input, OnInit} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {EntityDto} from "../../../model/entity.class";
import {EntityService} from "../../../service/entity.service";
import { System } from '../../../model/system.class';
import { SystemService } from '../../../service/system-service';
import { MessageService } from 'primeng/api';
import { Constant } from 'src/app/shared/constants/constant.class';

@Component({
  selector: 'app-entity',
  templateUrl: './entity.component.html',  
  providers: [SystemService, MessageService]
})
export class EntityComponent implements OnInit {
  data: any;
  // entities: EntityDto[] = [];  
  entities: any[] = [];  
  entity: EntityDto;
  loading: boolean;  
  @Input() isView = false;  
  submitted: boolean;
  checkAdd = true;
  isVisibleAdd = false;
  checkUpdate = true;
  isVisibleUpdate = false;
  cols: any[];

  systems : System[] = [];
  
  constructor(
    public translate: TranslateService,             
    private entityService: EntityService,
    private systemService: SystemService,
    private messageService: MessageService,
  ) {    
    this.cols = [
      { field: 'name', header: 'Name' },      
      { field: 'nameAscii', header: 'NameAscii' },
      { field: 'description', header: 'Description' }      ,
      { field: 'status', header: 'Status' },
      { field: 'systemsDto.name', header: 'System Name' }
    ];
  }

  async getListPermission() {
    // let arrayPermission: any;
    // await this.actionServices.getActionByScreen(Constant.SCREEN.GROUP).then(value => {
    //   arrayPermission = value;
    //   this.listPermission = new Set(arrayPermission);
    // });
    // this.checkAdd = this.listPermission.has(Constant.ACTION2.ADD);
    // this.checkDelete = this.listPermission.has(Constant.ACTION2.DELETE);
    // this.checkUpdate = this.listPermission.has(Constant.ACTION2.EDIT);
    // this.checkExport = this.listPermission.has(Constant.ACTION2.EXPORT);
  }

  ngOnInit(): void {   
    this.isVisibleAdd = false;
    this.getListPermission();
    this.getEntities();
    this.getSystem();
  }  

  getEntities(): void {
    this.loading = true;  
    this.entityService.getActiveEntity().subscribe(res => {
      if(res != null && res != undefined)  {
        this.entities = res; 
        // Doan code nay tao ra mot String liet ke cac ung dung cua entity, chi de phuc vụ chuc nang filter.
        this.entities.forEach((entity) => {
          let listSystemsStr = '';
          let systems = entity.systemsDto;
          for(let i = 0; i < systems.length; i++) {
            listSystemsStr += systems[i].name + ",";
          }
          listSystemsStr = listSystemsStr.substring(0, listSystemsStr.length - 1);
          entity.systemsStr = listSystemsStr;
        });
      }
    });  
  }  

  getSystem(): void {
    this.systemService.getAll().subscribe(res => {
      if(res != null && res != undefined) {
        this.systems = res;
      }
    });
  }

  get() {
    this.translate.use(this.translate.defaultLang).subscribe(data => {
      this.data = data;
    });
  }

  addEntity(value) {
    this.entityService.add(value).subscribe(res => {        
      this.messageService.add({key: "toastEntityView", severity:'success', summary: Constant.SUCCESS, detail: Constant.MESSAGE_ADD_SUCCESS});
      this.isVisibleAdd = false;            
      this.getEntities();
    }, error => {      
      this.messageService.add({key: "toastEntityView", severity:'error', summary: Constant.SUCCESS, detail: error.error});
    })
  }  

  updateEntity(value) {
    this.entityService.updateEntity(value).subscribe(res => {        
      this.messageService.add({key: "toastEntityView", severity:'success', summary: Constant.ERROR, detail: Constant.MESSAGE_UPDATE_SUCCESS});
      this.isVisibleUpdate = false;            
      this.getEntities();
    }, error => {      
      this.messageService.add({key: "toastEntityView", severity:'error', summary: Constant.ERROR, detail: error.error});
    })
  }  

  showModalAdd() {
    this.isVisibleAdd = true;
  }

  closeModelAdd() {
    this.isVisibleAdd = false;
  }

  showModalUpdate(data : EntityDto) {
    this.entity = data
    this.isVisibleUpdate = true;
  }

  closeModelUpdate() {
    this.isVisibleUpdate = false;
  }

  showListSystems(event: any, overlayPanel: any, entity: EntityDto ) {
    this.entity = entity;
    overlayPanel.show(event);
  }
}
