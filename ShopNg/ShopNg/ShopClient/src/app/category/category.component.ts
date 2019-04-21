import { Component, OnInit } from '@angular/core';
import { ItemService } from '../shared/services/item.service';
import { Item } from '../shared/models/item';
import { ActivatedRoute } from '@angular/router';
import { ShoppingCart } from '../shared/models/shoppingcart';
import { isString } from 'util';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  public items: Array<Item> = [];
  private type: string;
  private subscription: Subscription;
  private errorMessage: string;
  private shoppingCart: ShoppingCart;

  constructor(private route: ActivatedRoute, private itemService: ItemService) {
    this.route.paramMap.subscribe(params => {
      this.type = this.route.snapshot.paramMap.get('type');
      this.ngOnInit();
    });
  }

  async ngOnInit() {
    this.shoppingCart = new ShoppingCart();
    this.shoppingCart.number = 1;
    await this.getItems();
  }

  async getItems() {
    if (this.type == "All")
      this.type = '';
    const promise = new Promise((resolve, reject) => {
      this.itemService.getItems(this.type)
        .toPromise()
        .then(
          res => { // Success 
            this.items = res;
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

  async addCart(itemId: number) {
    this.shoppingCart.itemId = itemId;
    console.log(!localStorage.getItem('token'));
    if (!localStorage.getItem('token')){

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

}
