import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { endpoint } from 'src/environments/endpoints';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  getAllProducts(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(endpoint.ALL_PRODUCTS);
  }

  getProductById(id: number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${endpoint.PRODUCT}/${id}`);
  }

  createProduct(product: any): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(endpoint.CREATE_PRODUCT, product);
  }

  updateProduct(product: any, id: number): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${endpoint.UPDATE_PRODUCT}/${id}`, product);
  }

  deleteProduct(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${endpoint.DELETE_PRODUCT}/${id}`);
  }

  constructor(
    private http: HttpClient
  ) { }
}
