import { Injectable } from '@angular/core';
import { TokenType } from '../models/tokens.enum';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn(): boolean {
    const accessToken = localStorage.getItem(TokenType.ACCESS_TOKEN);

    return !!accessToken;
  }

  constructor() { }
}
