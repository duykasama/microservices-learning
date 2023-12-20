import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CouponListComponent } from './coupon-list/coupon-list.component';

const couponRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'coupon-list'
  },
  {
    path: 'coupon-list',
    component: CouponListComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(couponRoutes)
  ]
})
export class CouponRoutingModule { }
