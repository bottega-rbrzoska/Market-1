import { Injectable } from '@angular/core';
import { HomeUser } from '../models/home-user.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {

  private userList: HomeUser[] = [];
  constructor(private httpClient: HttpClient) { }

  getUsersList$(): Observable<HomeUser[]> {
    return this.httpClient.get<HomeUser[]>('http://localhost:3000/users');
  }

}
