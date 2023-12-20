import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CouponRoutingModule } from './coupon-routing.module';
import { CouponListComponent } from './coupon-list/coupon-list.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    CouponListComponent
  ],
  imports: [
    CommonModule,
    CouponRoutingModule,
    FontAwesomeModule,
  ]
})
export class CouponModule { }
