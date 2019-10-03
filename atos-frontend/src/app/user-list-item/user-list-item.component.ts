import { Component, OnInit, Input } from '@angular/core';
import { HomeUser } from '../models/home-user.interface';

@Component({
  selector: 'app-user-list-item',
  templateUrl: './user-list-item.component.html',
  styleUrls: ['./user-list-item.component.scss']
})
export class UserListItemComponent implements OnInit {

  @Input() user: HomeUser;
  constructor() { }

  ngOnInit() {
  }

}
