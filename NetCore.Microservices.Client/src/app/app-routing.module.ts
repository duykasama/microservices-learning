import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './modules/login/login.component';
import { NotFoundComponent } from './modules/not-found/not-found.component';
import { RegisterComponent } from './modules/register/register.component';
import { TestToastComponent } from './modules/test-toast/test-toast.component';
import { route } from 'src/environments/routes';

const routes: Routes = [
  {
    path: route.EMPTY,
    component: LayoutComponent,
    children: [
      {
        path: route.EMPTY,
        component: HomeComponent
      },
      {
        path: route.LOGIN,
        component: LoginComponent
      },
      {
        path: route.REGISTER,
        component: RegisterComponent
      },
      {
        path: route.COUPON,
        loadChildren: () => import('./modules/coupon/coupon.module').then(m => m.CouponModule)
      },
      {
        path: route.PRODUCT,
        loadChildren: () => import('./modules/product/product.module').then(m => m.ProductModule)
      },
      {
        path: 'test',
        component: TestToastComponent
      },
    ]
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }