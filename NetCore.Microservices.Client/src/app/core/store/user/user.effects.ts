import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { AppState } from "../AppState";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { UserActionType } from "./user.actions";
import { map, of } from "rxjs";

@Injectable()
export class UserEffects {

    // logout$ = createEffect(() => this.actions$.pipe(
    //     ofType(UserActionType.LOGOUT),
    //     map(() => {
    //         return of(false);
    //     })
    // ));

    constructor(
        private store$: Store<AppState>,
        private actions$: Actions
    ) { }
}