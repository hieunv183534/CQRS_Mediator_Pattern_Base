import {createEntityAdapter, EntityAdapter, EntityState} from '@ngrx/entity';
import {AuthModel} from '../../../model/auth.model';
import * as fromRoot from '../../app-state/app-state';
import * as actionAuth from '../redux/auth.action';
import {AuthActionTypes} from '../redux/auth.action';
import {createFeatureSelector, createSelector} from '@ngrx/store';
import {Constant} from "src/app/shared/constants/constant.class";

interface AuthState extends EntityState<AuthModel> {
  selectId: number | null;
  loading: boolean;
  error: string;
  isAuthenticated: boolean;
}

export interface AppState extends fromRoot.AppState {
  auth: AuthState;
}

export const authAdapter: EntityAdapter<AuthModel> = createEntityAdapter<AuthModel>();
export const defaultAuth: AuthState = {
  selectId: null,
  ids: [],
  entities: {},
  loading: false,
  error: '',
  isAuthenticated: false,
};
export const initialState = authAdapter.getInitialState(defaultAuth);

export function authReducer(state = initialState, action: actionAuth.AuthActions): AuthState {
  switch (action.type) {
    case AuthActionTypes.LoginSuccess: {
      return authAdapter.addOne(action.payload, {
        ...state,
        isAuthenticated: true,
        loaded: true
      });
    }
    case AuthActionTypes.LoginFail: {
      return {
        ...state,
        entities: {},
        isAuthenticated: false,
        error: Constant.LOGIN.MSG_KEY.LOGIN_FAIL
      };
    }
    default: {
      return state;
    }
  }
}

export const getAuthFeatureState = createFeatureSelector<AuthState>('auth');
export const getAuth = createSelector(
  getAuthFeatureState,
  authAdapter.getSelectors().selectAll
);

export const getLoginError = createSelector(
  getAuthFeatureState,
  (state: AuthState) => state.error
);


