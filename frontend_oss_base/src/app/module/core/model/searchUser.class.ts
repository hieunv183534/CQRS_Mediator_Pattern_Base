import { HttpParams } from '@angular/common/http';

export class SearchUser {
  page: number;
  pageSize: number;
  sortBy: string;
  sortType: boolean;
  email: string;
  name: string;
  userName: string;
  groupId: number;
  phoneNumber: string;
  status: number;
}

export class SearchUserParam {
  searchByUserName?: string;
  searchByEmail?: string;
  searchByPhone?: string;
  searchByGroup?: number;
  searchByStatus?: number;

  setUserNameParam(name: string) {
    if (name) { this.searchByUserName = name; }
  }

  setEmailParam(email: string) {
    if (email) { this.searchByEmail = email; }
  }

  setPhoneParam(phoneNumber: string) {
    if (phoneNumber) { this.searchByPhone = phoneNumber; }
  }

  setGroupParam(group: number) {
    if (group) { this.searchByGroup = group; }
  }

  setStatusParam(status: number) {
    if (status) { this.searchByStatus = status; }
  }
}
