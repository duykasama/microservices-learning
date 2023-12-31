import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomeComponent } from './modules/home/home.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HttpClientInterceptor } from './core/interceptors/httpClientInterceptor';
import { ToastComponent } from './components/toast/toast.component';
import { StoreModule } from '@ngrx/store';
import { appState } from './core/store/AppState';
import { LoginComponent } from './modules/login/login.component';
import { NotFoundComponent } from './modules/not-found/not-found.component';
import { RegisterComponent } from './modules/register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TestToastComponent } from './modules/test-toast/test-toast.component';
import { EffectsModule } from '@ngrx/effects';
import { ProductComponent } from './modules/home/components/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    ToastComponent,
    LoginComponent,
    NotFoundComponent,
    RegisterComponent,
    TestToastComponent,
    ProductComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    ReactiveFormsModule,
    StoreModule.forRoot(appState),
    EffectsModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpClientInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
