import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { delay } from 'q';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.scss']
})
export class SaleComponent implements OnInit {

  public hour: number = 0;
  public minute: number = 0;
  public second: number = 0;

  constructor() { }

  ngOnInit() {
    this.countdown();
  }

  async countdown() {
    while (true) {
      var date = new Date();
      var date2 = new Date();
      date2.setHours(23);
      date2.setMinutes(59);
      date2.setSeconds(59);
      var time1 = (date2.getTime() - date.getTime()) / 1000;
      this.hour = Math.floor(time1 % (24 * 60 * 60) / (60 * 60));
      this.minute = Math.floor(time1 % (24 * 60 * 60) % (60 * 60) / 60);
      this.second = Math.floor(time1 % (24 * 60 * 60) % (60 * 60) % 60);
      await delay(1000);
    }
  }

}
