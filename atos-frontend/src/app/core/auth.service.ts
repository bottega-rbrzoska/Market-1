import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AuthService {

  tokenSubject = new BehaviorSubject<string | null>(null);
  token$ = this.tokenSubject.asObservable();
  get token() {
    return this.tokenSubject.value;
  }

  constructor(private httpClient: HttpClient) { }

  login() {
    this.httpClient.post('http://localhost:5000/api/sign-in', {
      email: 'admin@market.com',
      password: 'secret'
  }).subscribe((res: any) => this.tokenSubject.next(res.accessToken));
  }

  logout() {
    this.tokenSubject.next(null);
  }
}
