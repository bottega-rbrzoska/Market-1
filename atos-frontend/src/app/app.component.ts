import { Component } from '@angular/core';
import { HomeUser } from './models/home-user.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'atos';
  nameClickCounter = 0;
  showHome = false;
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

  constructor() {
  }

  nameClickHandler(count: number) {
    this.nameClickCounter = count;
  }

  formatNumber(num: number) {
    return num.toString() + ' + VAT';
  }

  handleKeyup() {}
}
