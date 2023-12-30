import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { ApiResponse } from 'src/app/core/models/api-response.model';
import { Product } from 'src/app/core/models/product.model';
import { ProductService } from 'src/app/core/services/product.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
})
export class ProductCreateComponent implements OnInit, OnDestroy {

  destroy$: Subject<void> = new Subject<void>();
  isUpdating: boolean = true;

  createProductForm = this.formBuilder.group({
    name: new FormControl('', [
      Validators.min(0),
      Validators.max(1000)
    ]),
    categoryName: new FormControl(''),
    description: new FormControl(''),
    price: new FormControl(0),
    imageUrl: new FormControl('')
  });

  ngOnInit(): void {
    this.isUpdating = this.router.url.includes(route.PRODUCT_UPDATE);
    if (this.isUpdating) {
      const productId: string = this.router.url.substring(this.router.url.lastIndexOf('/') + 1);
      this.productService.getProductById(Number.parseInt(productId))
        .pipe(takeUntil(this.destroy$))
        .subscribe((res: ApiResponse) => {
          const product = res.data as Product;
          this.createProductForm.get('name')?.setValue(product.name);
          this.createProductForm.get('categoryName')?.setValue(product.categoryName);
          this.createProductForm.get('description')?.setValue(product.description);
          this.createProductForm.get('price')?.setValue(product.price);
          this.createProductForm.get('imageUrl')?.setValue(product.imageUrl);
        });      
    }
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  submitForm(): void {
    this.isUpdating 
    ? this.productService.updateProduct(this.createProductForm.getRawValue(), 0).pipe(takeUntil(this.destroy$)).subscribe()
    : this.productService.createProduct(this.createProductForm.getRawValue()).pipe(takeUntil(this.destroy$)).subscribe();
  }

  backToList(): void {
    this.router.navigateByUrl(`${route.PRODUCT}/${route.PRODUCT_LIST}`);
  }

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private toastService: ToastService
  ) { }
}