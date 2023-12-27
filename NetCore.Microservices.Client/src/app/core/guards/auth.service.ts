import { Injectable } from '@angular/core';
import { TokenType } from '../models/tokens.enum';
import { Store } from '@ngrx/store';
import { AppState } from '../store/AppState';
import { Observable, map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn(): Observable<boolean> {
    return of(false);
    // return this.store$.select(selectUsername).pipe(
    //   map((username: string) => !!username)
    // );
  }

  constructor(
    private store$: Store<AppState>
  ) { }
}
