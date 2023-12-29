import { Component } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { faUnderline } from '@fortawesome/free-solid-svg-icons';
import { ProductService } from 'src/app/core/services/product.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
})
export class ProductCreateComponent {

  createProductForm = this.formBuilder.group({
    name: new FormControl(''),
    categoryName: new FormControl(''),
    description: new FormControl(''),
    price: new FormControl(0),
    imageUrl: new FormControl('')
  });

  createProduct(): void {
    this.productService.createProduct(this.createProductForm.getRawValue()).subscribe();
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
