import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { endpoint } from 'src/environments/endpoints';

@Injectable({
  providedIn: 'root'
})
export class CouponService {

  constructor(private http: HttpClient) { }

  getAllCoupons(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(endpoint.ALL_COUPONS);
  }
}