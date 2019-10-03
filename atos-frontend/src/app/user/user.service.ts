import { Injectable } from '@angular/core';
import { HomeUser } from '../models/home-user.interface';

@Injectable()
export class UserService {

  private userList: HomeUser[] = [
    {
      name: 'Alojzy',
      age: 67,
      address: { city: 'Opole', street: 'Wrocławska' }
    },
    {
      name: 'Stefan',
      age: 76,
      address: { city: 'Wrocław', street: 'Opolska' }
    }
  ];
  constructor() { }

  getUsersList() {
    return this.userList;
  }
}
