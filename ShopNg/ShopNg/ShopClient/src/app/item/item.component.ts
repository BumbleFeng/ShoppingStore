import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ItemService } from '../shared/services/item.service';
import { Item } from '../shared/models/item';
import { ShoppingCart } from '../shared/models/shoppingcart';
import { isString, isNumber } from 'util';
import { delay } from 'q';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  public item: Item;
  private errorMessage: string;
  public shoppingCart: ShoppingCart;
  public hour: number = 0;
  public minute: number = 0;
  public second: number = 0;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private itemService: ItemService, 
    private userService: UserService) {
  }

  async ngOnInit() {
    this.shoppingCart = new ShoppingCart();
    this.shoppingCart.itemId = parseInt(this.route.snapshot.paramMap.get('id'));
    this.shoppingCart.number = 1;
    await this.getItem(this.shoppingCart.itemId);
    this.name();
    this.countdown();
  }

  async getItem(id: number) {
    const promise = new Promise((resolve, reject) => {
      this.itemService.getItem(id)
        .toPromise()
        .then(
          res => { // Success 
            if (!isNumber(res))
              this.item = <Item>res;
            else {
              this.router.navigate(['/category']);
            }
            resolve();
          },
          err => {
            console.error(err);
            this.errorMessage = err;
            reject(err);
          });
    });
    await promise;
  }

  async addCart() {
    if (!this.userService.authorize()){
      alert("Please Login First");
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.itemService.addCart(this.shoppingCart)
        .toPromise()
        .then(
          res => { // Success 
            if (!isString(res)) {
              console.log(res);
              alert("Out of Stock");
            }
            else {
              localStorage.setItem('token', res.toString());
              localStorage.setItem('exp', (new Date().valueOf() + 60 * 60 * 1000).toString());
              alert("Add Success");
            }
            resolve();
          },
          err => {
            console.error(err);
            this.errorMessage = err;
            reject(err);
          });
    });
    await promise;
  }

  name() {
    var c = true;
    $(".param .tab").click(function () {
      if (c) {
        $(this).addClass("on")
        c = false;
      } else {
        $(this).removeClass("on")
        c = true;
      }
    })
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

  add() {
    if (this.shoppingCart.number < this.item.stock)
      this.shoppingCart.number++;
  }

  remove() {
    if (this.shoppingCart.number > 1)
      this.shoppingCart.number--;
  }
  
}
