import { ActionReducer } from "@ngrx/store";
import { ToastState, toastReducer } from "./toast/toast.reducers";

export interface AppState {
    toastReducer: ActionReducer<ToastState>
}

export const appState: AppState = {
    toastReducer
}