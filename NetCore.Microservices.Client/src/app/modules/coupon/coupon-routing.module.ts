import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CouponListComponent } from './coupon-list/coupon-list.component';
import { CouponCreateComponent } from './coupon-create/coupon-create.component';
import { route } from 'src/environments/routes';

const couponRoutes: Routes = [
  {
    path: route.EMPTY,
    pathMatch: 'full',
    redirectTo: 'coupon-list'
  },
  {
    path: route.COUPON_LIST,
    component: CouponListComponent
  },
  {
    path: route.COUPON_CREATE,
    component: CouponCreateComponent
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
