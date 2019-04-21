import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { delay } from 'q';

@Component({
  selector: 'app-game-dialog',
  templateUrl: './game-dialog.component.html',
  styleUrls: ['./game-dialog.component.scss']
})
export class GameDialogComponent implements OnInit {

  private try: boolean = false;
  private deg: number = 0;
  public degree: string = 'rotate(0deg)';
  private code: string;
  @Output() private promoCode: EventEmitter<string>;

  constructor() {
    this.promoCode = new EventEmitter();
  }

  ngOnInit() {
  }

  async play() {
    if (!this.try) {
      //this.try = true;
      this.deg = 0;
      let num = Math.random() * 720 + 1080;
      var d = 1;
      for (; this.deg <= num; this.deg++) {
        if (d < 30 && (num - this.deg) * d < 360)
          d++;
        await delay(d);
        this.degree = 'rotate(' + this.deg + 'deg)';
      }
      num %= 360;
      if (num < 51.4) {
        alert('50% off');
        this.code = 'SAVE50';
      } else if (num < 51.4 * 2) {
        alert('20% off');
        this.code = 'SAVE20';
      } else if (num < 51.4 * 3) {
        alert('30% off');
        this.code = 'SAVE30';
      } else if (num < 51.4 * 4) {
        alert('20% off');
        this.code = 'SAVE20';
      } else if (num < 51.4 * 5) {
        alert('30% off');
        this.code = 'SAVE30';
      } else if (num < 51.4 * 6) {
        alert('20% off');
        this.code = 'SAVE20';
      } else {
        alert('10% off');
        this.code = 'SAVE10';
      }
      this.promoCode.emit(this.code);
    }
  }

}
