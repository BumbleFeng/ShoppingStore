import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, Subject } from 'rxjs';
import { Constants } from '../../../app/app.constants';
import { User } from '../../shared/models/user';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';
import { OrderDetail } from '../models/orderdetail';
import { PromoCode } from '../models/promocode';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private subject = new Subject<any>();

  constructor(
    private http: HttpClient,
    private errorHandleService: ErrorHandlerService) { }

  clearUsername() {
    this.subject.next();
  }

  authorize(): boolean{
    if(!localStorage.getItem('token') || !localStorage.getItem('exp') ||new Date().valueOf() > parseInt(localStorage.getItem('exp'))){
      localStorage.clear();
      this.clearUsername();
      return false;
    }
    return true;
  }

  getUsername(): Observable<any> {
    return this.subject.asObservable();
  }

  login(user: User): Observable<string | User> {
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/login`);
    return this.http.post(uri, user, { responseType: 'text' })
      .pipe(
        tap(_ => {
          this.subject.next(user.username);
          console.log(user.username + ' login');
        }),
        catchError(this.errorHandleService.handleError('login', user)));
  }

  register(user: User): Observable<string | User> {
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/register`);
    return this.http.post(uri, user, { responseType: 'text' })
      .pipe(
        tap(_ => console.log(user.username + ' id: ' + _)),
        catchError(this.errorHandleService.handleError('register', user)));
  }

  placeOrder(): Observable<User | string> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/placeOrder?token=` + token);
    return this.http.get<User>(uri)
      .pipe(
        tap(_ => console.log('placeorder')),
        catchError(this.errorHandleService.handleError('placeorder', "error")));
  }

  checkout(orderDetial: OrderDetail, same: boolean): Observable<string | OrderDetail> {
    const token = localStorage.getItem('token');
    var s = "";
    if (!same) {
      s = "F";
    }
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/checkout?token=` + token + "&same=" + s);
    console.log(uri);
    return this.http.post(uri, orderDetial, { responseType: 'text' })
      .pipe(
        tap(_ => console.log('checkout')),
        catchError(this.errorHandleService.handleError('placeorder', orderDetial)));
  }

  getOrders(): Observable<OrderDetail[]> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/orderlist?token=` + token);
    return this.http.get<OrderDetail[]>(uri)
      .pipe(
        tap(_ => console.log('fetched orderlist')),
        catchError(this.errorHandleService.handleError('getOrders', [])));
  }

  getOrder(id: string): Observable<OrderDetail | string> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/orderdetail/` + id + "?token=" + token);
    return this.http.get<OrderDetail>(uri)
      .pipe(
        tap(_ => console.log('fetched order ' + id)),
        catchError(this.errorHandleService.handleError('getOrder', id))
      );
  }

  getCode(code: string): Observable<PromoCode | string> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/promocode/` + code + "?token=" + token);
    return this.http.get<PromoCode>(uri)
      .pipe(
        tap(_ => console.log('fetched promocode ' + code)),
        catchError(this.errorHandleService.handleError('getCode', code))
      );
  }
}
