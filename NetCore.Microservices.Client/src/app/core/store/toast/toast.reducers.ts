import { createReducer, on } from "@ngrx/store"
import { hideToast, showToast } from "./toast.actions"

export interface ToastState {
    show: boolean
}

const initialState: ToastState = {
    show: false
}

export const toastReducer = createReducer(
    initialState,
    on(showToast, (state) => ({...state, show: true})),
    on(hideToast, (state) => ({...state, show: false})),
)