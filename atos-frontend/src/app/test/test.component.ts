import { Component, OnInit, ElementRef } from '@angular/core';
import { TestService } from '../test.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  constructor(public testService: TestService, public elRef: ElementRef) {
    console.log(elRef);
   }

  ngOnInit() {
  }

}
