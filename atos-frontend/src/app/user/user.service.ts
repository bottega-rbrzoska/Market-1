import { Injectable } from '@angular/core';
import { HomeUser } from '../models/home-user.interface';

@Injectable()
export class UserService {

  private userList: HomeUser[] = [];
  constructor() { }

  getUsersList() {
    return this.userList;
  }
}
