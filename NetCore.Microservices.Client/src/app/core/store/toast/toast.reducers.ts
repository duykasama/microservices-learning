import { createReducer, on } from "@ngrx/store"
import { addToast, removeToast } from "./toast.actions"
import { Guid } from "guid-typescript"

export interface ToastState {
    toastList: SingleToast[],
    show: boolean
}

export interface SingleToast {
    id: string,
    title: string,
    content: string,
    status: 'success' | 'warning' | 'error',
}

const initialState: ToastState = {
    toastList: [],
    show: false,
}

export const toastReducer = createReducer(
    initialState,
    on(addToast, (state, action) => ({...state, toastList: [...state.toastList, action.toast]})),
    on(removeToast, (state, action) => {
        const toastToDelete = state.toastList.find(t => t.id === action.id);
        const copiedToasts = [...state.toastList];
        copiedToasts.splice(state.toastList.indexOf(toastToDelete as any), 1);
        return {...state, toastList: copiedToasts}
    }),
)