import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of, Subject } from 'rxjs';
import { Constants } from '../../../app/app.constants';
import { Item } from '../../shared/models/item';
import { catchError, map, tap } from 'rxjs/operators';
import { ErrorHandlerService } from '../../shared/services/error-handler.service';
import { ShoppingCart } from '../models/shoppingcart';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(
    private http: HttpClient,
    private errorHandleService: ErrorHandlerService) { }

  getItems(type: string): Observable<Item[]> {
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/item?type=` + type);
    return this.http.get<Item[]>(uri)
      .pipe(
        tap(_ => console.log('fetched items ' + type)),
        catchError(this.errorHandleService.handleError('getItems', [])));
  }

  getItem(id: number): Observable<Item | number> {
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/item/` + id);
    return this.http.get<Item>(uri)
      .pipe(
        tap(_ => console.log('fetched item ' + id)),
        catchError(this.errorHandleService.handleError('getItem', id))
      );
  }

  addCart(shoppingCart: ShoppingCart): Observable<string | ShoppingCart> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/addcart?token=` + token);
    return this.http.post(uri, shoppingCart, { responseType: 'text' })
      .pipe(
        tap(_ => console.log('addcart ' + shoppingCart.itemId + ":" + shoppingCart.number)),
        catchError(this.errorHandleService.handleError('addcart', shoppingCart)));
  }

  updateCart(shoppingCart: ShoppingCart): Observable<string | ShoppingCart> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/updatecart?token=` + token);
    return this.http.put(uri, shoppingCart, { responseType: 'text' })
      .pipe(
        tap(_ => console.log('updatecart ' + shoppingCart.itemId + ":" + shoppingCart.number)),
        catchError(this.errorHandleService.handleError('getUpdateCart', shoppingCart)));
  }

  getShoppingCarts(): Observable<ShoppingCart[]> {
    const token = localStorage.getItem('token');
    const uri = decodeURIComponent(
      `${Constants.APIUrl}/user/showcart?token=` + token);
    return this.http.get<ShoppingCart[]>(uri)
      .pipe(
        tap(_ => console.log('fetched shoppingcarts')),
        catchError(this.errorHandleService.handleError('getShoppingCarts', [])));
  }

}
