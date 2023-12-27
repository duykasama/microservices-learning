import { Injectable, inject } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { exhaustMap, mergeMap, of, timeout, withLatestFrom } from 'rxjs';
import { ToastActionType, addToast, removeToast } from './toast.actions';
import { Store } from '@ngrx/store';
import { AppState } from '../AppState';

// Injectable()
// export class ToastEffects {
  
//   constructor(
//     private actions$: Actions,
//     private store$: Store<AppState>
//   ) { }

//   autoRemoveToast$ = createEffect(() => this.actions$.pipe(
//     ofType(ToastActionType.ADD),
//     withLatestFrom(this.store$),
//     withLatestFrom(this.actions$),
//     mergeMap(() => {
//       return of(removeToast({id: '1'}))
//     })
//   ));

// }


// export const autoRemoveToastEffect = createEffect(
//   (actions$ = inject(Actions)) => actions$.pipe(
//     ofType(ToastActionType.ADD),
//     mergeMap(() => of(removeToast({id: '1'})))
//   ),
  // { functional: true });
