import { Component, OnInit } from '@angular/core';
import { Observable, of, Subject, BehaviorSubject } from 'rxjs';
import { tap, map, filter } from 'rxjs/operators';

@Component({
  selector: 'app-observables',
  templateUrl: './observables.component.html',
  styleUrls: ['./observables.component.scss']
})
export class ObservablesComponent implements OnInit {
  currentSubjValue = '';
  obs = new Observable<number>(observer => {
    observer.next(1);
    observer.next(2);
    observer.next(3);
    observer.error('Error!');
    observer.next(4);
  });

  subject = new Subject<string>();
  bSubject = new BehaviorSubject('x');
  ofObs = of(1,2,3,4);
  constructor() { }

  ngOnInit() {
    this.bSubject.next('xx');
    console.log(this.bSubject.value)
    this.bSubject.subscribe(console.log);
    this.ofObs.subscribe(console.log)
    this.obs.subscribe(
      (nextVal) =>  console.log(nextVal),
      (error) => console.error(error),
      () =>  console.log('complete!') );

    this.obs.subscribe(
      {
        next: (nextVal) =>  console.log(nextVal),
        error:  (error) => console.error(error),
        complete: () =>  console.log('complete!')
      } );

    this.subject
    .pipe(
      filter(val => val.includes('a')),
      tap((val) => this.currentSubjValue = val),
      map(val => val.toUpperCase())
    )
    .subscribe(console.log);

    this.subject.next('1abc');
    this.subject.next('2bc');
    this.subject.next('3c');
  }

}
