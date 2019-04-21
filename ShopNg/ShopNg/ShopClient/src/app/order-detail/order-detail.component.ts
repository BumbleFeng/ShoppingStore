import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { OrderDetail } from '../shared/models/orderdetail';
import { Router, ActivatedRoute } from '@angular/router';
import { isString } from 'util';
import { Address } from '../shared/models/address';
import { Payment } from '../shared/models/payment';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {

  public order: OrderDetail;
  private errorMessage: string;
  public discount: number;

  constructor(private router: Router, private route: ActivatedRoute, private userService: UserService) { }

  async ngOnInit() {
    this.order = new OrderDetail();
    this.order.orderItems = [];
    this.order.shippingAddress = new Address();
    this.order.payment = new Payment();
    this.order.payment.billingAddress = new Address();
    await this.getOrder();
  }

  async getOrder() {
    if (!localStorage.getItem('token')){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.userService.getOrder(this.route.snapshot.paramMap.get('id'))
        .toPromise()
        .then(
          res => { // Success 
            if (!isString(res)) {
              this.order = <OrderDetail>res;
              var date = new Date(this.order.placedTime);
              this.order.placedTime = new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
              localStorage.setItem('token', this.order.user.password);
              this.discount = 0;
              this.order.orderItems.forEach(item => this.discount += item.number * item.item.price);
              this.discount = this.order.total - this.discount;
            }
            else
              this.router.navigate(['/orders']);
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
