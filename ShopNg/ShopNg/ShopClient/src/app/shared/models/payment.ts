import { Address } from "./address";

export class Payment {
    public paymentId: number;
    public nameOnCard: string;
    public cardType: string;
    public issuer: string;
    public cardNumber: string;
    public expiration: string;
    public cvv: string;
    public defaultPayment: boolean;
    public billingAddressId: string;
    public billingAddress: Address;
}
