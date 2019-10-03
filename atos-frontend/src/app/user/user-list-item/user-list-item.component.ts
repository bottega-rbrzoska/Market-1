import { Component, OnInit, Input } from '@angular/core';
import { HomeUser } from 'src/app/models/home-user.interface';

@Component({
  selector: 'app-user-list-item',
  templateUrl: './user-list-item.component.html',
  styleUrls: ['./user-list-item.component.scss']
})
export class UserListItemComponent implements OnInit {

  @Input() user: HomeUser;
  constructor() {
    console.log('in constructor: ' + this.user);
  }

  ngOnInit() {
    console.log('in onInit: ' + this.user);
  }

}
