import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';
import { isString } from 'util';
import { OrderDetail } from '../shared/models/orderdetail';
import { Address } from '../shared/models/address';
import { Payment } from '../shared/models/payment';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  public user: User;
  private errorMessage: string;
  public total: number;
  public order: OrderDetail;
  private same: boolean;
  private exp: Date;
  public open: boolean = false;

  constructor(private router: Router, private userService: UserService) { }


  async ngOnInit() {
    this.order = new OrderDetail();
    this.order.shippingAddress = new Address();
    this.order.payment = new Payment();
    this.order.payment.billingAddress = new Address();
    this.order.payment.cardType = "Visa";
    this.order.shippingAddressId = 0;
    this.order.paymentId = 0;
    this.user = new User();
    this.user.shoppingCarts = [];
    this.same = false;
    this.exp = new Date();
    await this.placeOrder();
  }


  game() {
    this.open = true;
  }

  async placeOrder() {
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.userService.placeOrder()
        .toPromise()
        .then(
          res => { // Success 
            if (isString(res)) {
              this.router.navigate(['/cart']);
            }
            else {
              this.user = <User>res;
              this.total = 0;
              this.user.shoppingCarts.forEach(cart => {
                this.total += cart.number * cart.item.price;
              });
              localStorage.setItem('token', this.user.password);
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

  async getCode($event: string) {
    console.log($event);
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.userService.getCode($event)
        .toPromise()
        .then(
          res => { // Success 
            if (isString(res))
              this.router.navigate(['/checkout']);
            else
              this.order.code = $event;
            resolve();
          },
          err => {
            console.error(err);
            this.errorMessage = err;
            reject(err);
          });
    });
    await promise;
    this.checkout();
  }

  async checkout() {
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    if (this.order.paymentId == 0)
      this.order.payment.expiration = this.exp.toString().substring(5) + this.exp.toString().substring(2, 4);
    console.log(this.order);
    const promise = new Promise((resolve, reject) => {
      this.userService.checkout(this.order, this.same)
        .toPromise()
        .then(
          res => { // Success 
            if (!isString(res))
              this.router.navigate(['/cart']);
            else
              this.router.navigate(['/orderDetail/' + res]);
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
