import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { route } from 'src/environments/routes';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

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
  },
  {
    path: `${route.PRODUCT_UPDATE}/:everything`,
    component: ProductCreateComponent
  },
  {
    path: `${route.PRODUCT_DETAILS}/:everything`,
    component: ProductDetailsComponent
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
