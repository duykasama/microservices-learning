import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { AuthService } from 'src/app/core/guards/auth.service';
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

  isLoggedIn$!: Observable<boolean>;
  username$!: Observable<string>;
  route = route;

  ngOnInit(): void {
    this.isLoggedIn$ = of(this.authService.isLoggedIn());
    this.username$ = this.store$.select(selectUsername);
  }

  logout(): void {
    localStorage.removeItem(TokenType.ACCESS_TOKEN);
    this.store$.dispatch(logout());
    this.isLoggedIn$ = of(false);
    this.router.navigateByUrl(route.LOGIN);
  }

  constructor(
    private router: Router,
    private store$: Store<AppState>,
    private authService: AuthService
  ) { }
}
