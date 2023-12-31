import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutingModule } from './product-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  declarations: [
    ProductListComponent,
    ProductCreateComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule
  ]
})
export class ProductModule { }
