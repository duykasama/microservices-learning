
import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/core/services/product.service';
import { Observable, map } from 'rxjs';
import { Product } from 'src/app/core/models/product.model';
import { ApiResponse } from 'src/app/core/models/api-response.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  productList$!: Observable<Product[]>;

  ngOnInit(): void {
    this.productList$ = this.productService.getAllProducts()
      .pipe(map((res: ApiResponse) => res.data));
  }

  constructor(
    private productService: ProductService
  ) { }
}
