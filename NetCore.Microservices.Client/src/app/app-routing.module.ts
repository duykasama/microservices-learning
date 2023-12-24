import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './modules/login/login.component';
import { NotFoundComponent } from './modules/not-found/not-found.component';
import { RegisterComponent } from './modules/register/register.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'coupon',
        loadChildren: () => import('./modules/coupon/coupon.module').then(m => m.CouponModule)
      }
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