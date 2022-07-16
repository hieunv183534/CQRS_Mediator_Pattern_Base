import {Role} from './role.class';
import { System } from './system.class';

export interface Menu {
  menuId?: number;
  url?: string;
  name?: string;
  description?: string;
  menuChildren?: Menu[];
  orderPriority?: number;
  createdDate?: Date;
  roleDto: Role;
  level?: number;
  expand?: boolean;
  parent?: Menu;
  parentId?: number;
  roleId?: number;
  icon?: string;
  systemId?: number;
  systemDto: System;
}
