import { User } from './user';
import { OrderItem } from './orderitem';
import { Address } from './address';
import { Payment } from './payment';

export class OrderDetail {
    public orderId: string;
    public staus: string;
    public placedTime: Date;
    public total: number;
    public user: User;
    public orderItems: Array<OrderItem>;
    public shippingAddressId: number
    public shippingAddress: Address;
    public paymentId: number;
    public payment: Payment;
    public code: string;
}