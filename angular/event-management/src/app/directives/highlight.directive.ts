import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective implements OnInit {
  @Input('appHighlight') price!: number;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.price > 2000) {
      this.el.nativeElement.style.backgroundColor = 'lightgoldenrodyellow';
    }
  }
}
