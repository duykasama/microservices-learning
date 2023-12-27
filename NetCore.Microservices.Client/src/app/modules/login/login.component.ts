import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/core/models/api-response.model';
import { TokenType } from 'src/app/core/models/tokens.enum';
import { AuthService } from 'src/app/core/services/auth.service';
import { ToastService } from 'src/app/core/services/toast.service';
import { route } from 'src/environments/routes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  loginFailed: boolean = false;
  
  loginForm = this.formBuilder.group({
    username: new FormControl<string>('', [
      Validators.email,
      Validators.required
    ]),
    password: new FormControl<string>('', [
      Validators.required
    ])
  });
  
  login(): void {
    this.authService.login(this.loginForm.getRawValue()).subscribe({
      next: (response: ApiResponse) => {
        localStorage.setItem(TokenType.ACCESS_TOKEN, response.data?.accessToken);
        localStorage.setItem(TokenType.REFRESH_TOKEN, response.data?.refreshToken);
        this.router.navigateByUrl(route.EMPTY);
      },
      error: (err: HttpErrorResponse) => {
        this.loginForm.get('password')?.setValue('');
        this.loginFailed = true;
        this.toastService.error(err.error?.messages[0]?.content, 'Error');
      }
    });
  }

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastService: ToastService
  ) { }
}
