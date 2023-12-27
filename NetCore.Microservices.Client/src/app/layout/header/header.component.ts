import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { TokenType } from 'src/app/core/models/tokens.enum';
import { AppState } from 'src/app/core/store/AppState';
import { logout } from 'src/app/core/store/user/user.actions';
import { selectUsername } from 'src/app/core/store/user/user.selectors';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {

  isLoggedIn!: Observable<boolean>;
  route = route;

  ngOnInit(): void {
    this.isLoggedIn = this.store$.select(selectUsername).pipe(map((username: string) => !!username));
  }

  logout(): void {
    this.store$.dispatch(logout());
    localStorage.removeItem(TokenType.ACCESS_TOKEN);
    this.router.navigateByUrl(route.LOGIN);
  }

  constructor(
    private router: Router,
    private store$: Store<AppState>
  ) { }
}
