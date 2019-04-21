import { Component, OnInit } from '@angular/core';
import { ShoppingCart } from '../shared/models/shoppingcart';
import { isString } from 'util';
import { ItemService } from '../shared/services/item.service';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public shoppingCarts: Array<ShoppingCart> = [];
  private errorMessage: string;
  public total: number;

  constructor(private router: Router, private itemService: ItemService, private userService: UserService) { }

  ngOnInit() {
    this.getShoppingCarts();
  }

  async getShoppingCarts() {
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.itemService.getShoppingCarts()
        .toPromise()
        .then(
          res => { // Success 
            this.shoppingCarts = res;
            this.total = 0;
            this.shoppingCarts.forEach(cart => {
              this.total += cart.number * cart.item.price;
            });
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

  async add(itemId: number) {
    let cart = this.shoppingCarts.find(item => item.itemId == itemId);
    if (cart.number < cart.item.stock) {
      cart.number++;
      this.total += cart.item.price;
    }
    await this.update(cart);
  }

  async remove(itemId: number) {
    let cart = this.shoppingCarts.find(item => item.itemId == itemId);
    if (cart.number > 1) {
      cart.number--;
      this.total -= cart.item.price;
    } else {
      await this.delete(itemId);
      return;
    }
    await this.update(cart);
  }

  async delete(itemId: number) {
    let cart = this.shoppingCarts.find(item => item.itemId == itemId);
    if (confirm("Delete Item: " + cart.item.name + "?")) {
      this.total -= cart.item.price * cart.number;
      cart.number = 0;
      this.shoppingCarts = this.shoppingCarts.filter(cart => cart.itemId != itemId);
      await this.update(cart);
    }
  }

  async update(shoppingCart: ShoppingCart) {
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.itemService.updateCart(shoppingCart)
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
}
