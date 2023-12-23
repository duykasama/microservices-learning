import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ToastState } from "./toast.reducers";

const toastSelector = createFeatureSelector<ToastState>('toastReducer');

export const selectAllToasts = createSelector(
    toastSelector,
    (state: ToastState) => state.toastList
);

export const selectToastVisibility = createSelector(
    toastSelector,
    (state: ToastState) => state.show
);