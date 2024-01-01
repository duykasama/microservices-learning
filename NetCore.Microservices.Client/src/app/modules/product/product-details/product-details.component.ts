import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/core/models/product.model';
import { takeUntil, Subject } from 'rxjs';
import { ApiResponse } from 'src/app/core/models/api-response.model';
import { ProductService } from 'src/app/core/services/product.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
})
export class ProductDetailsComponent implements OnInit, OnDestroy {

  destroy$: Subject<void> = new Subject<void>();
  product!: Product;

  ngOnInit(): void {
    const productIdStr = this.router.url.substring(this.router.url.lastIndexOf('/') + 1);
    const productId = Number.parseInt(productIdStr);
    this.productService.getProductById(productId).pipe(takeUntil(this.destroy$)).subscribe((res: ApiResponse) => this.product = res.data);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  goBackToList(): void {
    this.router.navigateByUrl(route.EMPTY);
  }

  addProductToCart(id: number): void {
  }

  constructor(
    private router: Router,
    private productService: ProductService
  ) { }
}
