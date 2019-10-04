import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appTest]'
})
export class TestDirective {

  @Input() appTest;
  @Input('appTestHoverOut') hoverOutColor;

  constructor(private elRef: ElementRef) {
    elRef.nativeElement.style.color = 'blue';
  }

  @HostListener('mouseover')
  onHover() {
    this.elRef.nativeElement.style.backgroundColor = this.appTest || 'black';
  }


  @HostListener('mouseout')
  onHoverOut() {
    this.elRef.nativeElement.style.backgroundColor = this.hoverOutColor || 'transparent';
  }

  ngOnChanges(changes) {
    console.log(changes);
  }

}
