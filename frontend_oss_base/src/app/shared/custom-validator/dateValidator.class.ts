import {AbstractControl, FormControl, ValidationErrors, ValidatorFn} from '@angular/forms';
import {DateUtils} from 'src/app/shared/utils/date-utils.class';

export class DateValidator {
  static maxDateValidator(numberYears: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      const date = control.value;
      if (date && date instanceof Date) {
        date.setHours(0, 0, 0, 0);
        const maxDate = new Date();
        maxDate.setFullYear(maxDate.getFullYear() - numberYears);
        maxDate.setHours(0, 0, 0, 0);
        if (date.getTime() > maxDate.getTime()) {
          return {maxDate: true};
        }
      }
      return null;
    };
  }

  static minDateValidator(numberYears: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      const date = control.value;
      if (date && date instanceof Date) {
        date.setHours(0, 0, 0, 0);
        const minDate = new Date();
        minDate.setFullYear(minDate.getFullYear() - numberYears);
        minDate.setHours(0, 0, 0, 0);
        if (date.getTime() < minDate.getTime()) {
          return {minDate: true};
        }
      }
      return null;
    };
  }

  static maxYesterdayDateValidator(control: FormControl): any {
    const maxYesterdayDate = new Date();
    maxYesterdayDate.setDate(maxYesterdayDate.getDate() - 1);
    const toDate = control.value;
    if (toDate && toDate instanceof Date) {
      toDate.setHours(0, 0, 0, 0);
      maxYesterdayDate.setHours(0, 0, 0, 0);
      if (toDate.getTime() > maxYesterdayDate.getTime()) {
        return {maxYesterdayDate: true};
      }
    }
    return null;
  }

  static maxCurrentDateValidator(control: FormControl): any {
    const dateNow = new Date();
    const toDate = control.value;
    if (toDate && toDate instanceof Date) {
      toDate.setHours(0, 0, 0, 0);
      dateNow.setHours(0, 0, 0, 0);
      if (toDate.getTime() > dateNow.getTime()) {
        return {maxDateNow: true};
      }
    }
    return null;
  }

  static onlyLowerTodayDate(control: AbstractControl): ValidationErrors | null {
    if (control.value) {
      const today = new Date();

      if (control.value instanceof Date) {
        if (DateUtils.compareDate(control.value, today) === 1) {
          return {noLowerTodayValidator: true};
        }
      } else {
        return {noMatchClass: true};
      }
    }
    return null;
  }

  static onlyFromTodayDate(control: AbstractControl): ValidationErrors | null {
    if (control.value) {
      const today = new Date();

      if (control.value instanceof Date) {
        if (DateUtils.compareDate(control.value, today) === -1) {
          return {onlyFromTodayValidator: true};
        }
      } else {
        return {noMatchClass: true};
      }
    }
    return null;
  }

  static lower18Old(control: AbstractControl): ValidationErrors | null {
    if (control.value) {
      const today = new Date();

      if (control.value instanceof Date) {
        if (DateUtils.compareDate(control.value, today, 18) === 1) {
          return {noLower18OldValidator: true};
        }
      } else {
        return {noMatchClass: true};
      }
    }
    return null;
  }

  static minYear(control: AbstractControl): ValidationErrors | null {
    if (control.value && control.value instanceof Date && control.value.getFullYear() < 1900) {
      return {minYear: true};
    }
    return null;
  }

  static validateRangeDate(sDate: string, eDate: string, errorName: string = 'fromToDate'): ValidatorFn {
    return (formGroup: AbstractControl): { [key: string]: boolean } | null => {
      const fromDate = formGroup.get(sDate).value;
      const toDate = formGroup.get(eDate).value;
      // Ausing the fromDate and toDate are numbers. In not convert them first after null check
      if ((fromDate !== null && toDate !== null) && fromDate > toDate) {
        return {[errorName]: true};
      }
      return null;
    };
  }

  static validateRangeMaxDate(sDate: string, eDate: string, typeRange: string, number: number, errorName: string = 'maxRangDateError'): ValidatorFn {
    return (formGroup: AbstractControl): { [key: string]: boolean } | null => {
      const fromDate = formGroup.get(sDate).value;
      const toDate = formGroup.get(eDate).value;
      if ((fromDate !== null && toDate !== null)) {
        if (typeRange === 'DAY') {
          let difference_In_Time = toDate.getTime() - fromDate.getTime();
          let difference_In_Days = difference_In_Time / (1000 * 3600 * 24);
          if (difference_In_Days > number) {
            return {[errorName]: true};
          }
        }
        if (typeRange === 'MONTH') {
          let enDate = new Date(toDate);
          enDate.setMonth(enDate.getMonth() - number);
          enDate.setDate(enDate.getDate() - 1);
          enDate.setHours(0);
          enDate.setMinutes(0);
          enDate.setSeconds(59);
          enDate.setMilliseconds(0);
          console.log(fromDate, "fromDate");
          let fromDateTmp = new Date(fromDate);
          fromDateTmp.setHours(0);
          fromDateTmp.setMinutes(0);
          fromDateTmp.setSeconds(59);
          fromDateTmp.setMilliseconds(0);
          console.log(enDate, "enDate");
          console.log(fromDateTmp, "fromDateTmp");
          if (fromDateTmp <= enDate) {
            return {[errorName]: true};
          }
        }
        if (typeRange === 'YEAR') {
          let diff = Math.floor(toDate.getTime() - fromDate.getTime());
          let day = 1000 * 60 * 60 * 24;
          let days = Math.floor(diff/day);
          let months = Math.floor(days/31);
          let years = Math.floor(months/12);
          if (years > number) {
            return {[errorName]: true};
          }
        }
        return null;
      }
      return null;
    };
  }

}
