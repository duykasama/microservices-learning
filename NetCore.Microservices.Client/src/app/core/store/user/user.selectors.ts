import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserState } from "./user.reducers";

const userSelector = createFeatureSelector<UserState>('userReducer');

export const selectUsername = createSelector(
    userSelector, 
    (state: UserState) => state.name
);

export const selectUserId = createSelector(
    userSelector, 
    (state: UserState) => state.id
);