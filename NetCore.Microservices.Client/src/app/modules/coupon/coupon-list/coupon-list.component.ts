import { Component, OnInit } from '@angular/core';
import { faPlusSquare, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { Coupon } from 'src/app/core/models/coupon.model';
import { CouponService } from 'src/app/core/services/coupon.service';

@Component({
  selector: 'app-coupon-list',
  templateUrl: './coupon-list.component.html',
})
export class CouponListComponent implements OnInit {

  couponsList: Coupon[] = [];

  constructor(private couponService: CouponService) {
  }

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

  faPlusSquare = faPlusSquare
  faTrash = faTrash
}
