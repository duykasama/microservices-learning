import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnDestroy {

  destroy$: Subject<void> = new Subject<void>();

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) { }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  registerForm = this.formBuilder.group({
    email: new FormControl<string>('', [
      Validators.email,
      Validators.required
    ]),
    name: new FormControl<string>('', [
      Validators.required
    ]),
    phoneNumber: new FormControl<string>('', [
      Validators.pattern('')
    ]),
    username: new FormControl<string>(''),
    password: new FormControl<string>('')
  });

  register(): void {
    this.authService.register(this.registerForm.getRawValue()).pipe(takeUntil(this.destroy$)).subscribe();
  }
}
