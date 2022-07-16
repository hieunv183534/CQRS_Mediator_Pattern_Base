import { AbstractControl, ValidationErrors } from '@angular/forms';

export class CustomValidator {
  static cannotContainSpace(control: AbstractControl): ValidationErrors | null {
    if (control.value) {
      if ((control.value as string).indexOf(' ') >= 0) {
        return {cannotContainSpace: true};
      }
      return null;
    }
    return null;
  }

  static numeric(control: AbstractControl) {
    const val = control.value;

    if (val !== '' && val !== null) {
      if (!val.toString().match(/^[0-9]+(\.?[0-9]+)?$/)) {
        return {invalidNumber: true};
      }

      if (val.toString().match(/^[0-9]+(\.?[0-9]+)?$/) && val < 0) {
        return {invalidNumber: true};
      }

    }
    return null;
  }


  static onlySpace(control: AbstractControl) {
    const val = control.value;
    if (val !== null) {
      if (!val.replace(/\s/g, '').length) {
        return {onlySpace: true};
      }
    }
    return null;
  }
}
