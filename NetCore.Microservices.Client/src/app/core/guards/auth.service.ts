import { Injectable } from '@angular/core';
import { TokenType } from '../models/tokens.enum';
import { Store } from '@ngrx/store';
import { AppState } from '../store/AppState';
import { Observable, map, of } from 'rxjs';
import { selectUserId, selectUsername } from '../store/user/user.selectors';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn(): boolean {
    let isloggedIn = false;
    this.store$.select(selectUserId).pipe(
      map((id: string) => !!id)
    ).subscribe((val: boolean) => { isloggedIn = val });
    return isloggedIn;
  }

  constructor(
    private store$: Store<AppState>
  ) { }
}
