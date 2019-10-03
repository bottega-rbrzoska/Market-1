import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'atos';
  nameClickCounter = 0;


  nameClickHandler(count: number) {
    this.nameClickCounter = count;
  }

  handleKeyup() {}
}
