import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appTest]'
})
export class TestDirective {


  constructor(private elRef: ElementRef) {
    elRef.nativeElement.style.color = 'blue';
  }

  @HostListener('mouseover')
  onHover() {
    this.elRef.nativeElement.style.backgroundColor = 'black';
  }


  @HostListener('mouseout')
  onHoverOut() {
    this.elRef.nativeElement.style.backgroundColor = 'transparent';
  }

}
