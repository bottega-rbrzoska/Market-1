import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { HomeUser } from 'src/app/models/home-user.interface';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  userList: HomeUser[] = [];
  constructor(private userService: UserService) {
    this.userList = this.userService.getUsersList();
   }

  ngOnInit() {
  }

}
