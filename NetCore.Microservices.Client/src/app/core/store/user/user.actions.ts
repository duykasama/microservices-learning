import { createAction, props } from "@ngrx/store";

export enum UserActionType {
    LOGIN = '[User Action] Login',
    LOGOUT = '[User Action] Logout',
}

export const login = createAction(
    UserActionType.LOGIN,
    props<{username: string}>()
);

export const logout = createAction(
    UserActionType.LOGOUT,
);