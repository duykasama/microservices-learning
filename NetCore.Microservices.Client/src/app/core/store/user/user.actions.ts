import { createAction, props } from "@ngrx/store";
import { UserState } from "./user.reducers";

export enum UserActionType {
    LOGIN = '[User Action] Login',
    LOGOUT = '[User Action] Logout',
}

export const login = createAction(
    UserActionType.LOGIN
);

export const logout = createAction(
    UserActionType.LOGOUT,
);