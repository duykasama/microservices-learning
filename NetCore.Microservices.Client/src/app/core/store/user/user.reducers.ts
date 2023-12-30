import { createReducer, on } from "@ngrx/store";
import { login, logout } from "./user.actions";
import { getUserEmail, getUserId, getUserRole, getUserStateFromToken, getUsername } from "../../lib/jwt-helper";

export interface UserState {
    name: string;
    email: string;
    role: string;
    id: string;
}

export const initialState: UserState = {
    name: getUsername(),
    email: getUserEmail(),
    role: getUserRole(),
    id: getUserId()
}

const emptyUserState: UserState = {
    name: '',
    email: '',
    role: '',
    id: ''
}

export const userReducer = createReducer(
    initialState,
    on(login, () => (getUserStateFromToken())),
    on(logout, () => emptyUserState)
);