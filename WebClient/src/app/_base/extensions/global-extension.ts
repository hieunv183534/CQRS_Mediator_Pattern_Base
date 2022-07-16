import { AbstractControl, FormArray, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { SwaggerResponseHandler } from 'src/app/_shared/bccp-api.services';
import { ErrorsModel } from '../models/response-model';
import { ComboboxExtension } from './combobox-extension';

// tslint:disable-next-line: typedef
AbstractControl.prototype.markAllAsDirty = function (this: AbstractControl) {
  // tslint:disable-next-line: forin
  if (this instanceof FormGroup) {
    const formGroupValue = (this as FormGroup);
    for (const item in formGroupValue.controls) {
      formGroupValue.get(item).markAllAsDirty();
    }
  } else if (this instanceof FormArray) {
    const formArrayValue = (this as FormArray);
    for (let i = 0; i < formArrayValue.length; i++) {
      const formGroupValue = formArrayValue.at(i);
      (formGroupValue as AbstractControl).markAllAsDirty();
    }
  } else if (this instanceof FormControl) {
    this.markAsDirty();
    this.updateValueAndValidity();
  }
};

FormGroup.prototype.bindError = function (this: FormGroup, errors: ErrorsModel): string {
  const getKeyName = function (keyName: string, form: FormGroup) {
    for (const control in form.controls) {
      if (keyName.toLocaleLowerCase() === control.toLocaleLowerCase()) {
        return control;
      }
    }
  };
  const lstMessageAlert: string[] = [];
  for (const key in errors) {
    let controlName = getKeyName(key, this);
    if (controlName != null) {
      if (errors[key].length > 0) {
        const errorValue = { error: errors[key][0] };
        this.get(controlName).setErrors(errorValue);
      }
    } else {
      // tslint:disable-next-line: prefer-for-of
      for (let index = 0; index < errors[key].length; index++) {
        const value = errors[key][index];
        lstMessageAlert.push(value);
      }
    }
  }
  return lstMessageAlert.join('/n');
};

// tslint:disable-next-line: typedef
FormGroup.prototype.textTrim = function (this: FormGroup) {
  for (const i in this.controls) {
    if (typeof this.controls[i].value === 'string') {
      this.controls[i].setValue(this.controls[i].value.trim());
    }
  }
};

// tslint:disable-next-line: typedef
FormGroup.prototype.resetMulti = function (this: FormGroup, listControl: string[]) {
  for (const key of listControl) {
    this.get(key).reset();
  }
};

// tslint:disable-next-line: typedef
FormGroup.prototype.disableMulti = function (this: FormGroup, listControl: string[]) {
  for (const key of listControl) {
    this.get(key).disable();
  }
};

// tslint:disable-next-line: typedef
FormGroup.prototype.enableMulti = function (this: FormGroup, listControl: string[]) {
  for (const key of listControl) {
    this.get(key).enable();
  }
};

// tslint:disable-next-line: typedef
String.prototype.convertToISOTime = function (this: string) {
  // tslint:disable-next-line: radix
  return (new Date(parseInt(this.substring(0, 4)), parseInt(this.substring(4, 6)) - 1, parseInt(this.substring(6, 8)))).toISOString();
};

String.prototype.convertToDate = function (this: string) {
  // tslint:disable-next-line: radix
  return new Date(parseInt(this.substring(0, 4)), parseInt(this.substring(4, 6)) - 1, parseInt(this.substring(6, 8)));
};

String.prototype.convertYYYYMMDDToDate = function (this: string) {
  // tslint:disable-next-line: radix
  return new Date(parseInt(this.substring(0, 4)), parseInt(this.substring(4, 6)) - 1, parseInt(this.substring(6, 8)));
};

String.prototype.toDateYYYYMMDD = function (this: string): string {
  const dateTime = new Date(this);
  let monthValue = (dateTime.getMonth() + 1).toString();
  if (monthValue.length == 1) {
    monthValue = `0${monthValue}`;
  }
  let dateValue = dateTime.getDate().toString();
  if (dateValue.length == 1) {
    dateValue = `0${dateValue}`;
  }
  return `${dateTime.getFullYear()}${monthValue}${dateValue}`;
};

String.prototype.toUnSign = function (this: string, toUper: boolean = true): string {
  let str = this;
  const AccentsMap = [
    "aàảãáạăằẳẵắặâầẩẫấậ",
    "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
    "dđ", "DĐ",
    "eèẻẽéẹêềểễếệ",
    "EÈẺẼÉẸÊỀỂỄẾỆ",
    "iìỉĩíị",
    "IÌỈĨÍỊ",
    "oòỏõóọôồổỗốộơờởỡớợ",
    "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
    "uùủũúụưừửữứự",
    "UÙỦŨÚỤƯỪỬỮỨỰ",
    "yỳỷỹýỵ",
    "YỲỶỸÝỴ"
  ];
  for (var i = 0; i < AccentsMap.length; i++) {
    var re = new RegExp('[' + AccentsMap[i].substr(1) + ']', 'g');
    var char = AccentsMap[i][0];
    str = str.replace(re, char);
  }
  if (toUper) {
    str = str.toUpperCase();
  }
  return str;
}

Date.prototype.toDateYYYYMMDD = function (this: Date): string {
  let monthValue = (this.getMonth() + 1).toString();
  if (monthValue.length == 1) {
    monthValue = `0${monthValue}`;
  }
  let dateValue = this.getDate().toString();
  if (dateValue.length == 1) {
    dateValue = `0${dateValue}`;
  }
  return `${this.getFullYear()}${monthValue}${dateValue}`;
};

Date.prototype.getOnlyDate = function (this: Date): Date {
  return new Date(this.getFullYear(), this.getMonth(), this.getDate());
};

Array.prototype.getMapingCombobox =
  // tslint:disable-next-line: only-arrow-functions
  async function <T>(this: Array<T>, keys: string, keyMap: string, apiService: any, apiActionName: string): Promise<Array<T>> {

    return new Promise(async (resove) => {

      if (!this || this.length === 0) {
        return resove(this);
      }

      const getApiCombobox = (param: any): Promise<any> => {
        if (!apiActionName) {
          apiActionName = 'getCombobox';
        }
        return apiService[apiActionName](param).toPromise();
      };

      const getValueFromObjectByKeyMultipleLevel = (obj: any, multipleKey: string): any => {
        const arr = multipleKey.split('.');
        // clone object để không dính preference
        let temp = {
          ...obj
        };
        // lấy dữ liệu từ các cấp key
        try {
          arr.map((key) => {
            temp = temp[key];
          });
        } catch (e) { // nếu không get được value thì return null
          return null;
        }

        return temp;
      };

      let isArray = false;
      let valueSearchParam: any[] = [];
      valueSearchParam = this.filter(x => getValueFromObjectByKeyMultipleLevel(x, keys)).map(x => {
        const valueByKey = getValueFromObjectByKeyMultipleLevel(x, keys);
        if (valueByKey instanceof Array) {
          isArray = true;
        }
        return valueByKey;
      });
      if (isArray) {
        const valueSearchParamNew = [];
        for (const item of valueSearchParam) {
          for (const v of item) {
            valueSearchParamNew.push(v);
          }
        }
        valueSearchParam = valueSearchParamNew;
      }

      const params = { page: 1, size: 500, valueSearch: valueSearchParam };
      const rs = await getApiCombobox(params);
      if (rs.success) {
        for (const item of this) {
          const objectItem = getValueFromObjectByKeyMultipleLevel(item, keys);
          if (isArray) {
            const listValueMap = [];
            for (const objectValue of objectItem) {
              const mapData = rs.result.data.find(x => JSON.stringify(x.value) === JSON.stringify(objectValue));
              if (mapData) {
                listValueMap.push(mapData.text);
              }
            }
            item[keyMap] = listValueMap;
          } else {
            const mapData = rs.result.data.find(x => JSON.stringify(x.value) === JSON.stringify(objectItem));
            if (mapData) {
              item[keyMap] = mapData.text;
            }
          }
        }
      }

      return resove(this);
    });
  };

Observable.prototype.toPromise = function <T>(this: Observable<SwaggerResponseHandler<T>>): Promise<SwaggerResponseHandler<T>> {
  return new Promise(async (resove) => {
    this.subscribe(result => {
      if (result) {
        resove(new SwaggerResponseHandler<T>(result?.status, result?.headers, result?.result));
      } else {
        resove(new SwaggerResponseHandler<T>(200, null, null));
      }
    }, error => {
      resove(new SwaggerResponseHandler<T>(error.status, error.headers, error.response ? JSON.parse(error.response) : null));
    });
  });
};

export { };

