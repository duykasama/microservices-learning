import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faPlusSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Coupon } from 'src/app/core/models/coupon.model';
import { CouponService } from 'src/app/core/services/coupon.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-coupon-list',
  templateUrl: './coupon-list.component.html',
})
export class CouponListComponent implements OnInit {

  couponsList: Coupon[] = [];

  constructor(
    private couponService: CouponService,
    protected router: Router
  ) { }

  ngOnInit(): void {
    this.couponService.getAllCoupons().subscribe({
      next: (res) => {
        this.couponsList = res.data;
      },
      error: (err) => {
        console.log(err);
        
        this.couponsList = [];
      }
    });
  }

  navigateToCreateCoupon(): void {
    this.router.navigateByUrl(`${route.COUPON}/${route.COUPON_CREATE}`);
  }

  faPlusSquare = faPlusSquare
  faTrash = faTrash
}
