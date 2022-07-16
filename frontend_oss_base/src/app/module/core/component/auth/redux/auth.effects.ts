import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Observable, of} from 'rxjs';
import {Action} from '@ngrx/store';
import * as authAction from '../redux/auth.action';
import {catchError, map, mergeMap, tap} from 'rxjs/operators';
import {AuthService} from '../../../service/auth.service';
import {AuthModel} from '../../../model/auth.model';

@Injectable()
export class AuthEffects {
  constructor(
    private actions$: Actions,
    private authService: AuthService,
  ) {
  }

  @Effect()
  login$: Observable<Action> = this.actions$.pipe(
    ofType<authAction.Login>(
      authAction.AuthActionTypes.Login
    ),
    mergeMap((action: authAction.Login) =>
      this.authService.login(action.payload).pipe(
        map(
          (data: AuthModel) =>
            new authAction.LoginSuccess(data)
        ),
        catchError(err => of(new authAction.LoginFail(err)))
      )
    )
  );
}
