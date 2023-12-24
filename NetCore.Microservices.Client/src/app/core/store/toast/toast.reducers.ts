import { createReducer, on } from "@ngrx/store"
import { addToast, removeToast } from "./toast.actions"

export interface ToastState {
    toastList: SingleToast[],
    show: boolean
}

export interface SingleToast {
    id: string,
    show: boolean,
    content: string,
    title: string,
    timeout: number
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
        let filteredToasts = state.toastList.splice(state.toastList.indexOf(toastToDelete as any), 1);
        return {...state, toastList: filteredToasts}
    }),
)