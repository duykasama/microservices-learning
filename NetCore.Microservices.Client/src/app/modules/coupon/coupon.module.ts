import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CouponRoutingModule } from './coupon-routing.module';
import { CouponListComponent } from './coupon-list/coupon-list.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CouponCreateComponent } from './coupon-create/coupon-create.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CouponListComponent,
    CouponCreateComponent
  ],
  imports: [
    CommonModule,
    CouponRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
  ]
})
export class CouponModule { }
