import { ShoppingCart } from './shoppingcart';
import { Address } from './address';
import { Payment } from './payment';

export class User {
    public username: string;
    public password: string;
    public shoppingCarts: Array<ShoppingCart>;
    public addresses: Array<Address>;
    public payments: Array<Payment>;
}


