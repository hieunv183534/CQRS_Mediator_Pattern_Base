import {AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { TreeNode } from 'primeng/api';
import {Menu} from '../../../model/menu.class';
import { System } from '../../../model/system.class';
import {Role} from '../../../model/role.class';

@Component({
  selector: 'app-update-menu',
  templateUrl: './update-menu.component.html',  
})

export class UpdateMenuComponent implements OnInit, OnChanges, AfterViewInit {
  @Input() isVisibleUpdate: boolean;
  @Input() menu: Menu;
  @Input() systems: System [] = [];
  @Input() roles: Role[];
  @Input() menuParent: TreeNode [] = [];
  @Output() submitUpdate: EventEmitter<any> = new EventEmitter();
  @Output() data: EventEmitter<any> = new EventEmitter();  
  formUpdate: FormGroup;
  submitted: boolean;
  
  rolesBySystem: Role [] = [];  
  menusBySystem: TreeNode [] = [];
  selectedParent: TreeNode;
  constructor(private formBuilder: FormBuilder) {
    this.formUpdate = this.formBuilder.group({
      menuId: [null],
      name: [[null], [Validators.required, Validators.maxLength(100)]],
      description: [[null], [Validators.maxLength(100)]],
      url: [[null]],
      orderPriority: [[null], [Validators.required]],
      parentId: [[null]],
      roleId: [null, [Validators.required]],      
      systemId: [null, [Validators.required]],
    });
  }

  ngAfterViewInit(): void {
   
  }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    if (this.menu != null) {
      this.formUpdate.patchValue({
        menuId: this.menu.menuId,
        name: this.menu.name,
        description: this.menu.description,
        url: this.menu.url,
        orderPriority: this.menu.orderPriority,      
        systemId: this.menu.systemDto.id, 
      });   

      this.menusBySystem = [];
      this.menuParent.forEach((item) =>{      
        if(item.data.systemDto.id == this.formUpdate.value.systemId) {
          this.menusBySystem.push(item);
        }      
        if(item.data.menuId == this.menu.parentId) {
          this.selectedParent = item;
        }
      });      

      this.rolesBySystem = [];
      this.roles.forEach((item) => {     
        let systemsDto = item.entityDto.systemsDto;
        systemsDto.forEach(systemDto => {
          if(systemDto.id == this.formUpdate.value.systemId) {
            this.rolesBySystem.push(item);
          }
        });
      });      
      this.formUpdate.get('roleId').setValue(this.menu.roleDto.roleId);
    }    
  }

  onSystemChange(): void {
    this.menusBySystem = [];
    this.menuParent.forEach((item) =>{      
      if(item.data.systemDto.id == this.formUpdate.value.systemId) {
        this.menusBySystem.push(item);
      }            
    });
    this.formUpdate.get('parentId').setValue('');

    this.rolesBySystem = [];
    this.roles.forEach((item) => {     
      let systemsDto = item.entityDto.systemsDto;
      systemsDto.forEach(systemDto => {
        if(systemDto.id == this.formUpdate.value.systemId) {
          this.rolesBySystem.push(item);
        }
      });
    });
    this.formUpdate.get('roleId').setValue('');
  }

  get f() {
    return this.formUpdate.controls;
  } 

  handleCancel(): void {
    this.submitUpdate.emit(false);    
  }

  handleOk(): void {
    this.submitted = true;
    if (this.formUpdate.valid) {
      this.isVisibleUpdate = false;
      this.data.emit(this.formUpdate.value);      
    }
  }
}
