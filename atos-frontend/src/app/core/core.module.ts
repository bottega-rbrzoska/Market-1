import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth.service';
import { AuthInterceptorService } from './auth-interceptor.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard } from './auth.guard';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [{provide: AuthService, useClass: AuthService}, AuthGuard,
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true}]
})
export class CoreModule { }
