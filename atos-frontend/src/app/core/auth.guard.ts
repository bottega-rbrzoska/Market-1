import { Injectable } from '@angular/core';
import { CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanLoad {
  constructor(private authService: AuthService) {}
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {

      const isAuthorized = !!this.authService.token;
      if (!isAuthorized) {
        alert('spadaj!!');
      }
      return isAuthorized;
  }
}
