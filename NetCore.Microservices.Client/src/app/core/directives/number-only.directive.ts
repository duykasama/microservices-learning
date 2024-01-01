import { Directive, ElementRef, Renderer2, HostListener } from '@angular/core';

@Directive({
  selector: '[NumberOnly]'
})
export class NumberOnlyDirective {

  numberPattern = /^[0-9]+$/;
  ignoredKeys: string[] = [
    'Enter',
    'Backspace',
    'ArrowUp',
    'ArrowDown',
    'ArrowLeft',
    'ArrowRight',
    'Alt',
    'Tab',
    'Shift',
    'Control',
  ];

  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent): void {
    if (this.ignoredKeys.includes(event.key)) {
      return;
    }
    const isValidKey = this.numberPattern.test(event.key);
    isValidKey || event.preventDefault();
  }

  constructor(
    el: ElementRef,
    renderer: Renderer2
  ) { }

}
