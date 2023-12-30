import { ActionReducer } from "@ngrx/store";
import { ToastState, toastReducer } from "./toast/toast.reducers";
import { UserState, userReducer } from "./user/user.reducers";

export interface AppState {
    toastReducer: ActionReducer<ToastState>,
    userReducer: ActionReducer<UserState>,
}

export const appState: AppState = {
    toastReducer,
    userReducer,
}