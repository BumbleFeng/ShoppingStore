import { Component, OnInit } from '@angular/core';
import { OrderDetail } from '../shared/models/orderdetail';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  public orders: Array<OrderDetail> = [];
  private errorMessage: string;

  constructor(private router: Router, private userService: UserService) { }

  async ngOnInit() {
    await this.getOrders();
  }

  async getOrders() {
    if (!this.userService.authorize()){
      this.router.navigate(['/login']);
      return ;
    }
    const promise = new Promise((resolve, reject) => {
      this.userService.getOrders()
        .toPromise()
        .then(
          res => { // Success 
            this.orders = res;
            this.orders.forEach(
              order => {
                var date = new Date(order.placedTime);
                order.placedTime = new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
              }
            );
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
