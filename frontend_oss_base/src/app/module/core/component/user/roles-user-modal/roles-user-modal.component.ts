import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuRoles } from '../../../model/menuRoles.class';
import { UserService } from '../../../service/user-service';
import { User } from '../../../model/user.class';
import {TreeNode} from 'primeng/api';

@Component({
  selector: 'app-roles-user-modal',
  templateUrl: './roles-user-modal.component.html',  
})
export class RolesUserModalComponent implements OnInit {
  @Input() user: User;
  @Input() isVisibleRole: boolean;
  @Input() titleModelRole: string;  
  @Input() nodes: MenuRoles[] = [];
  @Output() cancel: EventEmitter<any> = new EventEmitter();

  selectedNodes: TreeNode[] = [];  
  
  constructor(private userSevice: UserService) { }

  ngOnInit(): void {    
    this.userSevice.getUserRoles(this.user.userName).subscribe(res => {      
      if(res != undefined && res != null && res.length > 0) {        
        var arrayString: string[] = [];
        for(var i = 0 ; i < res.length; i++) {
          arrayString.push(String(res[i]));
        }
        console.log(arrayString);
        this.selectNodes(this.nodes, null, this.selectedNodes, arrayString)
      }
    });
  }

  handleCancelRole(): void {
    this.clearSelectedNodes(this.nodes);
    this.isVisibleRole = false;
    this.cancel.emit(this.isVisibleRole);
  }

  handleOkRole(): void {
    let checkedKeys = [];
    this.selectedNodes.forEach(item => { if(!item.key.includes("E_")) checkedKeys.push(item.key);});
    this.userSevice.setUserRoles(this.user.userId, checkedKeys).subscribe(res => {
      this.clearSelectedNodes(this.nodes);
      this.isVisibleRole = false; 
      this.cancel.emit(this.isVisibleRole);
    });
  }  

  selectNodes(tree: TreeNode[], parent: TreeNode, checkedNodes: TreeNode[], keys: string[]) {
    // Iterate through each node of the tree and select nodes
    let count = tree.length;
    for (const node of tree) {
       // If the current nodes key is in the list of keys to select, or it's parent is selected then select this node as well
       if (keys.includes(node.data) || checkedNodes.includes(node.parent)) {
          checkedNodes.push(node);
          count--;
       }
       // Look at the current node's children as well
       if (node.children)
          this.selectNodes(node.children, node, checkedNodes, keys);
    }
    // Once all nodes of a tree are looked at for selection, see if only some nodes are selected and make this node partially selected
    if (tree.length > 0 && parent) 
      parent.partialSelected = (count > 0 && count != tree.length);
    if (tree.length > 0 && parent && count == 0) 
      checkedNodes.push(parent);    
  }

  clearSelectedNodes(tree: TreeNode[]) {        
    for (const node of tree) {       
      node.partialSelected = false;
       // Look at the current node's children as well
       if (node.children)
          this.clearSelectedNodes(node.children);
    }    
  }
}
