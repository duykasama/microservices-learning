import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { route } from 'src/environments/routes';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  canActivate(routeSnapshot: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.authSerivce.isLoggedIn()) {

      return true;
    } else {
      this.router.navigateByUrl(route.LOGIN);
      return false;
    }
  }

  constructor(
    private authSerivce: AuthService,
    private router: Router
  ) { }
}
