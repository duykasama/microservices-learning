import { createAction, props } from "@ngrx/store";
import { SingleToast } from "./toast.reducers";

export enum ToastActionType {
    ADD = '[Toast Action] Add toast',
    REMOVE = '[Toast Action] Remove toast',
}

export const addToast = createAction(
    ToastActionType.ADD,
    props<{toast: SingleToast}>()
)

export const removeToast = createAction(
    ToastActionType.REMOVE,
    props<{id: string}>()
)