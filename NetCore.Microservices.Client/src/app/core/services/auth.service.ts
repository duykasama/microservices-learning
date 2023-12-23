import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { endpoint } from 'src/environments/endpoints';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(userLoginRequest: any): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(endpoint.LOGIN, userLoginRequest);
  }

  register(userRegisterRequest: any): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(endpoint.REGISTER, userRegisterRequest);
  }
}