import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faPlusSquare, faTrash, faPenToSquare } from '@fortawesome/free-solid-svg-icons';
import { Observable, Subject, map, takeUntil } from 'rxjs';
import { ApiResponse } from 'src/app/core/models/api-response.model';
import { Product } from 'src/app/core/models/product.model';
import { ProductService } from 'src/app/core/services/product.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit, OnDestroy {

  //#region Icons
  faPlusSquare = faPlusSquare;
  faTrash = faTrash;
  faPenToSquare = faPenToSquare;
  //#endregion

  destroy$: Subject<void> = new Subject<void>;
  productList: Product[] = [];

  ngOnInit(): void {
    this.loadProducts();
  }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
  
  loadProducts(): void {
    this.productService.getAllProducts().pipe(takeUntil(this.destroy$)).subscribe((res: ApiResponse) => this.productList = res.data);
  }

  navigateToCreateProduct(): void {
    this.router.navigateByUrl(`${route.PRODUCT}/${route.PRODUCT_CREATE}`);
  }

  updateProduct(id: number): void {
    this.router.navigateByUrl(`${route.PRODUCT}/${route.PRODUCT_UPDATE}/${id}`);
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id).subscribe();
  }

  constructor(
    private productService: ProductService,
    private router: Router
  ) { }
}
