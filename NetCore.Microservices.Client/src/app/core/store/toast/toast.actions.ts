import { createAction } from "@ngrx/store";

export enum ToastActionType {
    SHOW = '[Toast Action] Show toast',
    HIDE = '[Toast Action] Hide toast',
}

export const showToast = createAction(
    ToastActionType.SHOW
)

export const hideToast = createAction(
    ToastActionType.HIDE
)