import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CouponService } from 'src/app/core/services/coupon.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-coupon-create',
  templateUrl: './coupon-create.component.html',
})
export class CouponCreateComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private couponService: CouponService,
    private router: Router
  ) { }

  createCouponForm = this.formBuilder.group({
    couponCode: new FormControl<string>(''),
    discountAmount: new FormControl<number>(0,[
      Validators.min(0)
    ]),
    minAmount: new FormControl<number>(0,[
      Validators.min(0)
    ])
  });

  ngOnInit(): void {
    
  }

  createCoupon(): void{
    this.couponService.createCoupon(this.createCouponForm.getRawValue()).subscribe();
    this.backToList();
  }

  backToList(): void {
    this.router.navigateByUrl(`${route.COUPON}/${route.COUPON_LIST}`);
  }
}