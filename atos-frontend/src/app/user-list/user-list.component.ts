import { Component, OnInit } from '@angular/core';
import { HomeUser } from '../models/home-user.interface';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  userList: HomeUser[] = [
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

  ngOnInit() {
  }

}
