import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { route } from 'src/environments/routes';
import { ProductCreateComponent } from './product-create/product-create.component';

const productRoutes: Routes = [
  {
    path: route.EMPTY,
    pathMatch: 'full',
    redirectTo: route.PRODUCT_LIST
  },
  {
    path: route.PRODUCT_LIST,
    component: ProductListComponent
  },
  {
    path: route.PRODUCT_CREATE,
    component: ProductCreateComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(productRoutes)
  ]
})
export class ProductRoutingModule { }
