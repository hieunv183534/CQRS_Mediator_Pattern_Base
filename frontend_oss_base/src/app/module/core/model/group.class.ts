import {Role} from './role.class';

export interface Group {  
  groupId: string;
  name: string;
  description: string;
  createdDate: Date;
  roles: Role [];
  roleIds: number [];  
  status: number;
}

export class Pagination {
  page: number;
  pageSize: number;
}
