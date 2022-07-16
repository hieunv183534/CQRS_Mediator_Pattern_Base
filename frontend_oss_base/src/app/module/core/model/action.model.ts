import {FilterClass} from './filter.class';

export interface Action {
  actionId: number;
  name: string;
  nameAscii: string;
  description: string;
  createdDate: Date;
  status: number;
}

export class ActionFilter extends FilterClass {
  name: string;
  status: number
}
