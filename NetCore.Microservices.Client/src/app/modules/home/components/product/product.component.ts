import { Component, Input } from '@angular/core';
import { Product } from 'src/app/core/models/product.model';
import { Router } from '@angular/router';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
})
export class ProductComponent {
  @Input()
  product!: Product;

  goToProductDetails(id: number): void {
    console.log('Button clicked');
    this.router.navigateByUrl(`${route.PRODUCT}/${route.PRODUCT_DETAILS}/${id}`);
  }

  constructor(
    private router: Router
  ) { }
}
