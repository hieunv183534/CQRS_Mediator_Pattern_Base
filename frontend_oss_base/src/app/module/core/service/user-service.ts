import {Injectable} from '@angular/core';
import {BaseService} from 'src/app/shared/base-service/base-service.service';
import {Observable} from 'rxjs';
import {SearchUser} from '../model/searchUser.class';
import {UrlConstant} from 'src/app/shared/constants/url.class';

@Injectable()
export class UserService  extends  BaseService {
  getUser(search: SearchUser): Observable<any> {
     // return this.post( UrlConstant.LIST_USER  , search);
     return this.post(UrlConstant.LIST_USER  , search);
  }
  addUser(user): Observable<any> {
     return this.post(  UrlConstant.ADD_USER , user);
  }
  deleteUser(id: number[]): Observable<any> {
    return this.delete(  UrlConstant.DETAIL_USER, id);
  }
  updateUser(user): Observable<any> {
    return this.put(  UrlConstant.UPDATE_USER , user);
  }
  updateProfile(user): Observable<any> {
    return this.put(  UrlConstant.UPDATE_PROFILE , user);
  }
  changePassword(user): Observable<any> {
    return this.put(  UrlConstant.CHANGE_PASSWORD , user);
  }
  getUserByUsername(username): Observable<any> {
    return this.get( UrlConstant.DETAIL_USER  + '/' +  username );
  }

  getUsersListReport(data: any) {
    return this.post( UrlConstant.DETAIL_USER  + '/reportUser',  data, null, 'blob');
  }
  uploadAvatar(FormData): Observable<any> {
    return this.post(  UrlConstant.UPLOAD_AVATAR , FormData);
  }
  getBusinessUnitByUser(userId: any) {
    return this.get( UrlConstant.BUSINESS_UNIT  + '?userId=' + userId);
  }
  readSheetsExel(dataFile) {
    return this.post(  UrlConstant.USER_READ_SHEETS, dataFile);
  }
  getRolesPartner() {
    return this.get( UrlConstant.USER_ROLES_PARTNER);
  }
  getRolesBss() {
    return this.get(  UrlConstant.LIST_ROLE);
  }
  getUserRoles(userName) {
    return this.post(UrlConstant.DETAIL_USER + "/getUsersRole", userName);
  }
  setUserRoles(userId, roles) {
    return this.post(UrlConstant.DETAIL_USER + "/setUsersRole", {userId: userId, roles: roles});
  }
  setValidateImport(index, formData, roles, type) {
    return this.post(  UrlConstant.USER_PARTNER_VALIDATE + '?index=' + index + '&roles=' + roles + '&type=' + type, formData);
  }
  exportFileValidateImport(index, formData, type) {
    return this.post(  UrlConstant.USER_VALIDATE_EXPORT_FILE + '?index=' + index + '&type=' + type, formData, null, 'blob');
  }
  importExcelUser(formData, type) {
    return this.post(  UrlConstant.USER_IMPORT_FILE + '?type=' + type, formData);
  }
  sendTotpCode(username: string){
    // @ts-ignore
    return this.post( UrlConstant.SEND_TOTP_CODE, username);
  }
}
