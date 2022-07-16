import {Group} from './group.class';
import {Role} from './role.class';

export class User {
  userId: number;
  userName: string;
  name: string;
  phoneNumber: string;
  email: string;
  createdDate: Date;
  //status: Status;
  // groups?: Group[];
  group: Group;
  roles?: Role[];
  status: string;
  groupName: string;
  updatedDate: Date;
  groupId: number;
  requireOtp: number;
  roleIds: [] = [];
  password?: string;
  imageUrl?: string;
  mmcIds: [] = [];
  merchantId?: number;
  resellerId?: number;
  parentId?: number;
  modifiedDate?: Date;
  applicationId?: number;
}

export interface Status {
  key: number;
  value: string;
}
