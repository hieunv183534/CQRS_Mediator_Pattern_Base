import {AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Role} from '../../../model/role.class';
import { System } from '../../../model/system.class';
import { TreeNode } from 'primeng/api';

@Component({
  selector: 'app-add-menu',
  templateUrl: './add-menu.component.html',
})
export class AddMenuComponent implements OnInit, AfterViewInit {
  @Input() isVisibleAdd: boolean;
  formAdd: FormGroup;
  submitted: boolean;
  @Input() systems: System [] = [];
  @Input() roles: Role [] = [];  
  @Input() menuParent: TreeNode [] = [];
  @Output() dataAdd: EventEmitter<any> = new EventEmitter();  
  @Output() submitAdd: EventEmitter<any> = new EventEmitter();

  rolesBySystem: Role [] = [];  
  menusBySystem: TreeNode [] = [];

  constructor(private fb: FormBuilder) {
    this.formAdd = fb.group({
      name: [null, [Validators.required]],
      description: [null],
      orderPriority: [null, [Validators.required]],
      parentId: [null],
      roleId: [null, [Validators.required]],
      url: [null],
      systemId: [null, [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.rolesBySystem = [];
    this.menusBySystem = [];
  }

  onSystemChange(): void {
    this.menusBySystem = [];
    this.menuParent.forEach((item) =>{      
      if(item.data.systemDto.id == this.formAdd.value.systemId) {
        this.menusBySystem.push(item);
      }
    });
    this.formAdd.get('parentId').setValue('');

    this.rolesBySystem = [];
    this.roles.forEach((item) => {     
      let systemsDto = item.entityDto.systemsDto;
      systemsDto.forEach(systemDto => {
        if(systemDto.id == this.formAdd.value.systemId) {
          this.rolesBySystem.push(item);
        }
      });
    });
    this.formAdd.get('roleId').setValue('');
  }

  ngAfterViewInit() {
  }

  get f() {
    return this.formAdd.controls;
  }

  handleCancel() {
    this.submitted = false;
    this.isVisibleAdd = false;    
    this.submitAdd.emit(this.isVisibleAdd);
  }

  handleOk() {
    this.submitted = true;
    if (this.formAdd.valid) {
      // this.formAdd.get('parentId').setValue(this.formAdd.get('parentId').key);
      // let parent : any = this.formAdd.get('parentId').value;
      // this.formAdd.get('parentId').setValue(parent.key);
      this.dataAdd.emit(this.formAdd.value);
      // this.submitted = false;
      // this.isVisibleAdd = false;
    }
  }

  getSystemId() {
    this.rolesBySystem = [];
    const systemIdId = this.formAdd.get('systemId').value;    
    this.rolesBySystem = this.roles;
    this.formAdd.get('roleId').setValue('');
  }
}
