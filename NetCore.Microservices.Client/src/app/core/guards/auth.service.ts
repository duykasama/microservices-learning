import { Injectable } from '@angular/core';
import { getLocalAccessToken } from '../lib/helpers';
import { getExpirationTime } from '../lib/jwt-helper';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn(): boolean {
    if (!getLocalAccessToken()) {
      return false;
    }
    const expirationTime = getExpirationTime() || 0;
    return Date.now() < expirationTime * 1000;
  }

  constructor() { }
}
