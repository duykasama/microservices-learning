import { createReducer, on } from "@ngrx/store";
import { login, logout } from "./user.actions";

export interface UserState {
    username: string
}

export const initialState: UserState = {
    username: ''
}

export const userReducer = createReducer(
    initialState,
    on(login, (state, action) => ({...state, username: action.username})),
    on(logout, (_) => initialState)
);