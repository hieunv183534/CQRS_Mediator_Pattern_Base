import { Observable } from 'rxjs';
export interface ComboboxExtension{
  getCombobox(request: any): Observable<any>;
}
