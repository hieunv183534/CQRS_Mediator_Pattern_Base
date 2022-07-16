import {AbstractControl, FormControl, ValidatorFn} from '@angular/forms';

export class CurrencyValidator {
  static required(control: FormControl): any {
    const value = control.value;
    if (!value || value == 0) {
      return {required: true};
    }
    return null;
  }

  static minCurrency(min: number): ValidatorFn {
    return (control: AbstractControl): any => {
      const value = control.value;
      if (value && Number(value) < min) {
        return {minValue: true};
      }
      return null;
    };
  }

  static maxCurrency(max: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      const value = control.value;
      if (Number(value) > max) {
        return {maxValue: true};
      }
      return null;
    };
  }

  static validateMinMaxCurency(min: string, max: string, errorName: string = 'notMatch'): ValidatorFn {
    return (formGroup: AbstractControl): { [key: string]: boolean } | null => {
      const minCurency = formGroup.get(min).value;
      const maxCurency = formGroup.get(max).value;
      if (((minCurency !== null && minCurency !== '') &&
        (maxCurency !== null && maxCurency !== '')) &&
        Number(minCurency) > Number(maxCurency)) {
        return {[errorName]: true};
      }
      return null;
    };
  }
}
