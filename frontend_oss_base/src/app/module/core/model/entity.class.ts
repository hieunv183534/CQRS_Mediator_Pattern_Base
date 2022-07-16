import {Role} from "./role.class";
import {FilterClass} from "./filter.class";
import { System } from "./system.class";

export class EntityDto {
  entityId: number;
  name: string;
  nameAscii: string;
  status: number;
  strStatus: string;
  adRoles: Role[];
  // systemId: number;
  // systemDto: System;
  systemsDto: System[];
  description: String;
}

export class EntityFilter extends FilterClass {
  name: string;
  status: number
}
