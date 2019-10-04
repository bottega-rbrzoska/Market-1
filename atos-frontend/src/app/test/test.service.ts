import { Injectable } from '@angular/core';

@Injectable()
export class TestService {

  private _counter = 0;

  constructor() {
    console.log('constructor');
   }

   getCount() {
     return this._counter;
   }

   increment() {
     this._counter++;
   }
}
