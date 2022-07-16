import { InjectionToken, ɵisObservable as isObservable, ɵisPromise as isPromise } from '@angular/core';
import { Observable, forkJoin, from, Observer } from 'rxjs';
import { map, distinctUntilChanged } from 'rxjs/operators';
import {
  Validator, ValidatorFn, AbstractControl, ValidationErrors,
  Validators, AsyncValidatorFn, FormControl, FormGroup
} from '@angular/forms';

function isEmptyInputValue(value: any): boolean {
  // we don't check for string here so it also works with arrays
  return value == null || value.length === 0;
}

/**
 * @description
 * An `InjectionToken` for registering additional synchronous validators used with `AbstractControl`s.
 *
 * @see `NG_ASYNC_VALIDATORS`
 *
 * @usageNotes
 *
 * ### Providing a custom validator
 *
 * The following example registers a custom validator directive. Adding the validator to the
 * existing collection of validators requires the `multi: true` option.
 *
 * ```typescript
 * @Directive({
 *   selector: '[customValidator]',
 *   providers: [{provide: NG_VALIDATORS, useExisting: CustomValidatorDirective, multi: true}]
 * })
 * class CustomValidatorDirective implements Validator {
 *   validate(control: AbstractControl): ValidationErrors | null {
 *     return { 'custom': true };
 *   }
 * }
 * ```
 *
 * @publicApi
 */
// tslint:disable-next-line: ban-types
export const NG_VALIDATORS = new InjectionToken<Array<Validator | Function>>('NgValidators');

/**
 * @description
 * An `InjectionToken` for registering additional asynchronous validators used with `AbstractControl`s.
 *
 * @see `NG_VALIDATORS`
 *
 * @publicApi
 */
export const NG_ASYNC_VALIDATORS =
  // tslint:disable-next-line: ban-types
  new InjectionToken<Array<Validator | Function>>('NgAsyncValidators');

/**
 * A regular expression that matches valid e-mail addresses.
 *
 * At a high level, this regexp matches e-mail addresses of the format `local-part@tld`, where:
 * - `local-part` consists of one or more of the allowed characters (alphanumeric and some
 *   punctuation symbols).
 * - `local-part` cannot begin or end with a period (`.`).
 * - `local-part` cannot be longer than 64 characters.
 * - `tld` consists of one or more `labels` separated by periods (`.`). For example `localhost` or
 *   `foo.com`.
 * - A `label` consists of one or more of the allowed characters (alphanumeric, dashes (`-`) and
 *   periods (`.`)).
 * - A `label` cannot begin or end with a dash (`-`) or a period (`.`).
 * - A `label` cannot be longer than 63 characters.
 * - The whole address cannot be longer than 254 characters.
 *
 * ## Implementation background
 *
 * This regexp was ported over from AngularJS (see there for git history):
 * https://github.com/angular/angular.js/blob/c133ef836/src/ng/directive/input.js#L27
 * It is based on the
 * [WHATWG version](https://html.spec.whatwg.org/multipage/input.html#valid-e-mail-address) with
 * some enhancements to incorporate more RFC rules (such as rules related to domain names and the
 * lengths of different parts of the address). The main differences from the WHATWG version are:
 *   - Disallow `local-part` to begin or end with a period (`.`).
 *   - Disallow `local-part` length to exceed 64 characters.
 *   - Disallow total address length to exceed 254 characters.
 *
 * See [this commit](https://github.com/angular/angular.js/commit/f3f5cf72e) for more details.
 */
const EMAIL_REGEXP =
  // tslint:disable-next-line: max-line-length
  /^(?=.{1,254}$)(?=.{1,64}@)[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
const PHONE_REGEXP = /^(01|03|09|07|05|06)+([0-9]{8})\b$/;
const SPACE_REGEXP = /^\s+(?![^.])/;
const SPECIAL_REGEXP = /[!@#$%^&*()-+={}\[\]\/|<>/\\?*]/;
const s = /\s{2,}/g;

/**
 * @description
 * Provides a set of built-in validators that can be used by form controls.
 *
 * A validator is a function that processes a `FormControl` or collection of
 * controls and returns an error map or null. A null map means that validation has passed.
 *
 * @see [Form Validation](/guide/form-validation)
 *
 * @publicApi
 */

export class ValidatorExtension {

  /**
   * @description
   * Validator that requires the control's value to be greater than or equal to the provided number.
   * The validator exists only as a function and not as a directive.
   *
   * @usageNotes
   *
   * ### Validate against a minimum of 3
   *
   * ```typescript
   * const control = new FormControl(2, Validators.min(3));
   *
   * console.log(control.errors); // {min: {min: 3, actual: 2}}
   * ```
   *
   * @returns A validator function that returns an error map with the
   * `min` property if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static min(min: number): ValidatorFn {
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     if (isEmptyInputValue(control.value) || isEmptyInputValue(min)) {
  //       return null;  // don't validate empty values to allow optional controls
  //     }
  //     const value = parseFloat(control.value);
  //     // Controls with NaN values after parsing should be treated as not having a
  //     // minimum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-min
  //     return !isNaN(value) && value < min ? { min: { min, actual: control.value } } : null;
  //   };
  // }
  static min(min: number, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value) || isEmptyInputValue(min)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const value = parseFloat(control.value);
      // Controls with NaN values after parsing should be treated as not having a
      // minimum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-min
      return !isNaN(value) && value < min ? {
        error: errorMessage || `Giá trị tối thiểu là ${min}`,
        min: { min, actual: control.value }
      } : null;
    };
  }

  static minDate(min: Date, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value) || isEmptyInputValue(min)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const value = control.value as Date;
      // Controls with NaN values after parsing should be treated as not having a
      // minimum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-min
      return value != null && value !== undefined && value < min ? {
        error: errorMessage || `Giá trị ngày tối thiểu là ${min}`,
        min: { min, actual: control.value }
      } : null;
    };
  }

  static maxDate(max: Date, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value) || isEmptyInputValue(max)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const value = control.value as Date;
      // Controls with NaN values after parsing should be treated as not having a
      // minimum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-min
      return value != null && value !== undefined && value > max ? {
        error: errorMessage || `Giá trị ngày tối đa là ${max}`,
        min: { max, actual: control.value }
      } : null;
    };
  }

  /**
   * @description
   * Validator that requires the control's value to be less than or equal to the provided number.
   * The validator exists only as a function and not as a directive.
   *
   * @usageNotes
   *
   * ### Validate against a maximum of 15
   *
   * ```typescript
   * const control = new FormControl(16, Validators.max(15));
   *
   * console.log(control.errors); // {max: {max: 15, actual: 16}}
   * ```
   *
   * @returns A validator function that returns an error map with the
   * `max` property if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static max(max: number): ValidatorFn {
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     if (isEmptyInputValue(control.value) || isEmptyInputValue(max)) {
  //       return null;  // don't validate empty values to allow optional controls
  //     }
  //     const value = parseFloat(control.value);
  //     // Controls with NaN values after parsing should be treated as not having a
  //     // maximum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-max
  //     return !isNaN(value) && value > max ? { max: { max, actual: control.value } } : null;
  //   };
  // }
  static max(max: number, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value) || isEmptyInputValue(max)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const value = parseFloat(control.value);
      // Controls with NaN values after parsing should be treated as not having a
      // maximum, per the HTML forms spec: https://www.w3.org/TR/html5/forms.html#attr-input-max
      return !isNaN(value) && value > max ? {
        error: errorMessage || `Giá trị tối đa là ${max}`,
        max: { max, actual: control.value }
      } : null;
    };
  }

  /**
   * @description
   * Validator that requires the control have a non-empty value.
   *
   * @usageNotes
   *
   * ### Validate that the field is non-empty
   *
   * ```typescript
   * const control = new FormControl('', Validators.required);
   *
   * console.log(control.errors); // {required: true}
   * ```
   *
   * @returns An error map with the `required` property
   * if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static required(control: AbstractControl): ValidationErrors | null {
  //   return isEmptyInputValue(control.value) ? { required: true } : null;
  // }
  static required(errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      return isEmptyInputValue(control.value) ? { error: errorMessage || 'Không được để trống', required: true } : null;
    };
  }

  static notWhiteSpace(errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      return (control.value as string || '').trim() === ''
        ? { error: errorMessage || 'Khoảng trắng là không hợp lệ', required: true }
        : null;
    };
  }


  /**
   * @description
   * Validator that requires the control's value be true. This validator is commonly
   * used for required checkboxes.
   *
   * @usageNotes
   *
   * ### Validate that the field value is true
   *
   * ```typescript
   * const control = new FormControl('', Validators.requiredTrue);
   *
   * console.log(control.errors); // {required: true}
   * ```
   *
   * @returns An error map that contains the `required` property
   * set to `true` if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static requiredTrue(control: AbstractControl): ValidationErrors | null {
  //   return control.value === true ? null : { required: true };
  // }
  static requiredTrue(errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      return control.value === true ? null : { error: errorMessage || 'Không được để trống', required: true };
    };
  }

  /**
   * @description
   * Validator that requires the control's value pass an email validation test.
   *
   * Tests the value using a [regular expression](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions)
   * pattern suitable for common usecases. The pattern is based on the definition of a valid email
   * address in the [WHATWG HTML specification](https://html.spec.whatwg.org/multipage/input.html#valid-e-mail-address)
   * with some enhancements to incorporate more RFC rules (such as rules related to domain names and
   * the lengths of different parts of the address).
   *
   * The differences from the WHATWG version include:
   * - Disallow `local-part` (the part before the `@` symbol) to begin or end with a period (`.`).
   * - Disallow `local-part` to be longer than 64 characters.
   * - Disallow the whole address to be longer than 254 characters.
   *
   * If this pattern does not satisfy your business needs, you can use `Validators.pattern()` to
   * validate the value against a different pattern.
   *
   * @usageNotes
   *
   * ### Validate that the field matches a valid email pattern
   *
   * ```typescript
   * const control = new FormControl('bad@', Validators.email);
   *
   * console.log(control.errors); // {email: true}
   * ```
   *
   * @returns An error map with the `email` property
   * if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static email(control: AbstractControl): ValidationErrors | null {
  //   if (isEmptyInputValue(control.value)) {
  //     return null;  // don't validate empty values to allow optional controls
  //   }
  //   return EMAIL_REGEXP.test(control.value) ? null : { email: true };
  // }
  static email(errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value)) {
        return null;  // don't validate empty values to allow optional controls
      }
      return EMAIL_REGEXP.test(control.value) ? null : { error: errorMessage || 'Không đúng định dạng email', email: true };
    };
  }

  static phoneNumber(errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value)) {
        return null;  // don't validate empty values to allow optional controls
      }
      return PHONE_REGEXP.test(control.value) ? null : { error: errorMessage || 'Không đúng định dạng số điện thoại', phoneNumber: true };
    };
  }

  /**
   * @description
   * Validator that requires the length of the control's value to be greater than or equal
   * to the provided minimum length. This validator is also provided by default if you use the
   * the HTML5 `minlength` attribute.
   *
   * @usageNotes
   *
   * ### Validate that the field has a minimum of 3 characters
   *
   * ```typescript
   * const control = new FormControl('ng', Validators.minLength(3));
   *
   * console.log(control.errors); // {minlength: {requiredLength: 3, actualLength: 2}}
   * ```
   *
   * ```html
   * <input minlength="5">
   * ```
   *
   * @returns A validator function that returns an error map with the
   * `minlength` if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static minLength(minLength: number): ValidatorFn {
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     if (isEmptyInputValue(control.value)) {
  //       return null;  // don't validate empty values to allow optional controls
  //     }
  //     const length: number = control.value ? control.value.length : 0;
  //     return length < minLength ?
  //       { minlength: { requiredLength: minLength, actualLength: length } } :
  //       null;
  //   };
  // }
  static minLength(minLength: number, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const length: number = control.value ? control.value.length : 0;
      return length < minLength ?
        {
          error: errorMessage || `Số ký tự tối thiểu là ${minLength}`,
          minlength: { requiredLength: minLength, actualLength: length }
        } :
        null;
    };
  }

  /**
   * @description
   * Validator that requires the length of the control's value to be less than or equal
   * to the provided maximum length. This validator is also provided by default if you use the
   * the HTML5 `maxlength` attribute.
   *
   * @usageNotes
   *
   * ### Validate that the field has maximum of 5 characters
   *
   * ```typescript
   * const control = new FormControl('Angular', Validators.maxLength(5));
   *
   * console.log(control.errors); // {maxlength: {requiredLength: 5, actualLength: 7}}
   * ```
   *
   * ```html
   * <input maxlength="5">
   * ```
   *
   * @returns A validator function that returns an error map with the
   * `maxlength` property if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static maxLength(maxLength: number): ValidatorFn {
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     const length: number = control.value ? control.value.length : 0;
  //     return length > maxLength ?
  //       { maxlength: { requiredLength: maxLength, actualLength: length } } :
  //       null;
  //   };
  // }
  static maxLength(maxLength: number, errorMessage?: string) {
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const length: number = control.value ? control.value.length : 0;
      return length > maxLength ?
        {
          error: errorMessage || `Số ký tự tối đa là ${maxLength}`,
          maxlength: { requiredLength: maxLength, actualLength: length }
        } :
        null;
    };
  }

  /**
   * @description
   * Validator that requires the control's value to match a regex pattern. This validator is also
   * provided by default if you use the HTML5 `pattern` attribute.
   *
   * @usageNotes
   *
   * ### Validate that the field only contains letters or spaces
   *
   * ```typescript
   * const control = new FormControl('1', Validators.pattern('[a-zA-Z ]*'));
   *
   * console.log(control.errors); // {pattern: {requiredPattern: '^[a-zA-Z ]*$', actualValue: '1'}}
   * ```
   *
   * ```html
   * <input pattern="[a-zA-Z ]*">
   * ```
   *
   * @param pattern A regular expression to be used as is to test the values, or a string.
   * If a string is passed, the `^` character is prepended and the `$` character is
   * appended to the provided string (if not already present), and the resulting regular
   * expression is used to test the values.
   *
   * @returns A validator function that returns an error map with the
   * `pattern` property if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  // static pattern(pattern: string | RegExp): ValidatorFn {
  //   if (!pattern) { return Validators.nullValidator; }
  //   let regex: RegExp;
  //   let regexStr: string;
  //   if (typeof pattern === 'string') {
  //     regexStr = '';

  //     if (pattern.charAt(0) !== '^') { regexStr += '^'; }

  //     regexStr += pattern;

  //     if (pattern.charAt(pattern.length - 1) !== '$') { regexStr += '$'; }

  //     regex = new RegExp(regexStr);
  //   } else {
  //     regexStr = pattern.toString();
  //     regex = pattern;
  //   }
  //   return (control: AbstractControl): ValidationErrors | null => {
  //     if (isEmptyInputValue(control.value)) {
  //       return null;  // don't validate empty values to allow optional controls
  //     }
  //     const value: string = control.value;
  //     return regex.test(value) ? null :
  //       { pattern: { requiredPattern: regexStr, actualValue: value } };
  //   };
  // }
  static pattern(pattern: string | RegExp, errorMessage?: string): ValidatorFn {
    if (!pattern) { return Validators.nullValidator; }
    let regex: RegExp;
    let regexStr: string;
    if (typeof pattern === 'string') {
      regexStr = '';

      if (pattern.charAt(0) !== '^') { regexStr += '^'; }

      regexStr += pattern;

      if (pattern.charAt(pattern.length - 1) !== '$') { regexStr += '$'; }

      regex = new RegExp(regexStr);
    } else {
      regexStr = pattern.toString();
      regex = pattern;
    }
    return (control: AbstractControl): ValidationErrors | null => {
      if (isEmptyInputValue(control.value)) {
        return null;  // don't validate empty values to allow optional controls
      }
      const value: string = control.value;
      return regex.test(value) ? null :
        {
          error: errorMessage || 'Không đúng định dạng',
          pattern: { requiredPattern: regexStr, actualValue: value }
        };
    };
  }

  /**
   * @description
   * Validator that performs no operation.
   *
   * @see `updateValueAndValidity()`
   *
   */
  static nullValidator(control: AbstractControl): ValidationErrors | null { return null; }

  /**
   * @description
   * Compose multiple validators into a single function that returns the union
   * of the individual error maps for the provided control.
   *
   * @returns A validator function that returns an error map with the
   * merged error maps of the validators if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  static compose(validators: null): null;
  static compose(validators: (ValidatorFn | null | undefined)[]): ValidatorFn | null;
  static compose(validators: (ValidatorFn | null | undefined)[] | null): ValidatorFn | null {
    if (!validators) { return null; }
    const presentValidators: ValidatorFn[] = validators.filter(isPresent) as any;
    if (presentValidators.length === 0) { return null; }

    return (control: AbstractControl) => {
      return _mergeErrors(_executeValidators(control, presentValidators));
    };
  }

  /**
   * @description
   * Compose multiple async validators into a single function that returns the union
   * of the individual error objects for the provided control.
   *
   * @returns A validator function that returns an error map with the
   * merged error objects of the async validators if the validation check fails, otherwise `null`.
   *
   * @see `updateValueAndValidity()`
   *
   */
  static composeAsync(validators: (AsyncValidatorFn | null)[]): AsyncValidatorFn | null {
    if (!validators) { return null; }
    const presentValidators: AsyncValidatorFn[] = validators.filter(isPresent) as any;
    if (presentValidators.length === 0) { return null; }

    return (control: AbstractControl) => {
      const observables = _executeAsyncValidators(control, presentValidators).map(toObservable);
      return forkJoin(observables).pipe(map(_mergeErrors));
    };
  }

  // tslint:disable-next-line: max-line-length
  static compareValidator(nameControlTarget: string, errorMessage: string) {
    return (control: AbstractControl) => {
      const controlTarget = control?.parent?.get(nameControlTarget);

      if(!controlTarget){
        return null;
      }

      if(isEmptyInputValue(controlTarget.value) && isEmptyInputValue(control.value)){
        return null;
      }

      if (isEmptyInputValue(control.value)) {
        return { error: 'Không được để trống' };
      }

      if (controlTarget.value !== null && control.value !== controlTarget.value) {
        return { error: errorMessage };
      }
      return null;
    };
  }

  static eqFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value === ctrlTarget.value;
  static notEqFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value !== ctrlTarget.value;
  static gtFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value > ctrlTarget.value;
  static gteFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value >= ctrlTarget.value;
  static ltFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value < ctrlTarget.value;
  static lteFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => ctrl.value <= ctrlTarget.value;
  static gtDateFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => new Date(ctrl.value)
    > new Date(ctrlTarget.value)
  static gteDateFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => new Date(ctrl.value)
    >= new Date(ctrlTarget.value)
  static ltDateFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => new Date(ctrl.value)
    < new Date(ctrlTarget.value)
  static lteDateFn = (ctrl: FormControl, ctrlTarget: AbstractControl) => new Date(ctrl.value)
    <= new Date(ctrlTarget.value)

  static existAsyncValidator(checkExist: (value: string) => Observable<boolean>, errorMessage?: string) {
    return (control: FormControl) =>
      new Observable((observer: Observer<ValidationErrors | null>) => {
        setTimeout(async () => {
          if (await checkExist(control.value).toPromise()) {
            observer.next({ error: errorMessage || 'Đã tồn tại', duplicated: true });
          } else {
            observer.next(null);
          }
          observer.complete();
        }, 1000);
      });
  }

  static space(errorMessage?: string) {
    return (control: AbstractControl) => {
      if (control.value !== null && control.value !== '' && (SPACE_REGEXP.test(control.value))) {
        return { error: errorMessage || 'Không đúng định dạng ! ', space: true };
      }
      return null;
    };
  }

  static specialChar(errorMessage?: string) {
    return (control: AbstractControl) => {
      if (control.value !== null && control.value !== '' && (SPECIAL_REGEXP.test(control.value))) {
        return { error: errorMessage || 'Không hợp lệ !', special: true };
      }
      return null;
    };
  }

  static containsSpace(errorMessage?: string) {
    return (control: AbstractControl) => {
      if (control.value !== null && control.value !== '' && (/\s/.test(control.value))) {
        return { error: errorMessage || 'Không được chứa khoảng trắng ! ', space: true };
      }
      return null;
    };
  }

  // tslint:disable-next-line:typedef
  static countNumber(min: number, max: number, errorMessage?: string) {
    return (control: AbstractControl) => {
      const value: string = control.value;
      const countNumber = value.replace(/[^0-9]/g, '').length;
      if (countNumber < min || countNumber > max) {
        return { error: errorMessage || `phải chứa từ ${min} đến ${max} số`, number: true };
      }
      return null;
    };
  }

  // tslint:disable-next-line:typedef
  static countChar(min: number, max: number, errorMessage?: string) {
    // đi kèm với validate ký tự đặc biệt
    return (control: AbstractControl) => {
      const value: string = control.value;
      const countNumber = value.replace(/[0-9]/g, '').length;
      if (countNumber < min || countNumber > max) {
        return { error: errorMessage || `phải chứa từ ${min} đến ${max} chữ cái`, char: true };
      }
      return null;
    };
  }

  // tslint:disable-next-line:typedef
  static checkFormatString(errorMessage?: string) {
    // đi kèm với validate ký tự đặc biệt
    return (control: AbstractControl) => {
      // const value: string = control.value;
      // const s15: string = value.substr(0, 5);
      // const s6: string = value.substr(5, 1);
      // const s7: string = value.substr(6, 1);
      //
      // const countNumber = value.replace(/[0-9]/g, '').length;
      // if (countNumber < min || countNumber > max) {
      //   return { error: errorMessage || `phải chứa từ ${min} đến ${max} chữ cái`, char: true };
      // }
      return null;
    };
  }


  // static compareValidator(controlTarget: AbstractControl, message: string) {
  //   return (control: FormControl) => {
  //     if (!control.value) {
  //       return { required: true };
  //     } else if (control.value !== controlTarget.value) {
  //       return { compare: message, error: true };
  //     }
  //     return null;
  //   };
  // }

  // static setCompareValidator(myForm: FormGroup, control: string, controlTarget: string, message: string) {
  //   myForm.get(control).setValidators(this.compareValidator(myForm.controls[controlTarget], message));
  // }
}

function isPresent(o: any): boolean {
  return o != null;
}

export function toObservable(r: any): Observable<any> {
  const obs = isPromise(r) ? from(r) : r;
  if (!(isObservable(obs))) {
    throw new Error(`Expected validator to return Promise or Observable.`);
  }
  return obs;
}

function _executeValidators(control: AbstractControl, validators: ValidatorFn[]): any[] {
  return validators.map(v => v(control));
}

function _executeAsyncValidators(control: AbstractControl, validators: AsyncValidatorFn[]): any[] {
  return validators.map(v => v(control));
}

function _mergeErrors(arrayOfErrors: ValidationErrors[]): ValidationErrors | null {
  const res: { [key: string]: any } =
    // tslint:disable-next-line: no-shadowed-variable
    arrayOfErrors.reduce((res: ValidationErrors | null, errors: ValidationErrors | null) => {
      // tslint:disable-next-line: no-non-null-assertion
      return errors != null ? { ...res!, ...errors } : res!;
    }, {});
  return Object.keys(res).length === 0 ? null : res;
}
