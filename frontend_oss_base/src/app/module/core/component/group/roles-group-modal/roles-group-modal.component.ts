import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuRoles } from '../../../model/menuRoles.class';
import { TreeNode} from 'primeng/api';
import { Group } from '../../../model/group.class';
import { GroupService } from '../../../service/group-service';

@Component({
  selector: 'app-roles-group-modal',
  templateUrl: './roles-group-modal.component.html',    
})
export class RolesGroupModalComponent implements OnInit {
  @Input() group: Group;
  @Input() isVisibleRole: boolean;
  @Input() titleModelRole: string;  
  @Input() nodes: MenuRoles[] = [];
  @Output() cancel: EventEmitter<any> = new EventEmitter();

  selectedNodes: TreeNode[] = [];
  

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {        
        var arrayString: string[] = [];
        for(var i = 0 ; i < this.group.roles.length; i++) {
          arrayString.push(String(this.group.roles[i].roleId));
        }        
        this.selectNodes(this.nodes, null, this.selectedNodes, arrayString);        
  }

  handleCancelRole(): void {
    this.clearSelectedNodes(this.nodes);
    this.isVisibleRole = false;
    this.cancel.emit(false);
  }

  handleOkRole(): void {   
    let checkedKeys = [];
    this.selectedNodes.forEach(item => { if(!item.key.includes("E_")) checkedKeys.push(item.key);});
    this.groupService.setGroupRoles(this.group.groupId, checkedKeys).subscribe(res => {      
      this.clearSelectedNodes(this.nodes);
      this.isVisibleRole = false; 
      this.cancel.emit(true);
    }, error => {      
      console.log(error)
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
