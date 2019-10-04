import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    let request;
    if (this.authService.token) {
      request = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + this.authService.token)
      });
    } else {
      request = req;
    }
    console.log(req);
    return next.handle(request);
  }
  constructor( private authService: AuthService) {

   }
}
