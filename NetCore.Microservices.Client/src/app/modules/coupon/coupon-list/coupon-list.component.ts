import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faPlusSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Coupon } from 'src/app/core/models/coupon.model';
import { CouponService } from 'src/app/core/services/coupon.service';
import { route } from 'src/environments/routes';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-coupon-list',
  templateUrl: './coupon-list.component.html',
})
export class CouponListComponent implements OnInit, OnDestroy {

  destroy$: Subject<void> = new Subject<void>();
  couponsList: Coupon[] = [];

  constructor(
    private couponService: CouponService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.couponService.getAllCoupons().pipe(takeUntil(this.destroy$)).subscribe({
      next: (res) => {
        this.couponsList = res.data;
      },
      error: (err) => {
        console.log(err);
        
        this.couponsList = [];
      }
    });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  deleteCoupon(couponId: number): void {
    this.couponService.delete(couponId).subscribe({
      error: (err: HttpErrorResponse) => {
        alert(err.message);
      }
    });

  }

  navigateToCreateCoupon(): void {
    this.router.navigateByUrl(`${route.COUPON}/${route.COUPON_CREATE}`);
  }

  faPlusSquare = faPlusSquare;
  faTrash = faTrash;
}
