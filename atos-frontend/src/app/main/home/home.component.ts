import { Component, OnInit, ViewEncapsulation, Input,
   Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private clickCount = 0;
  @Input() homeName: string;
  @Output() nameClick = new EventEmitter<number>();
  constructor() { }

  ngOnInit() {
  }

  handleClick() {
    this.clickCount++;
    this.nameClick.emit(this.clickCount);
  }

}
