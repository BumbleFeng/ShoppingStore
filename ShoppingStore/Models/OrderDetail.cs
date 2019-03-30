using System;
using System.Collections.Generic;

namespace ShoppingStore.Models
{
    public class OrderDetail
    {
        public string OrderId { get; set; }

        public string Staus { get; set; }
        public DateTime PlacedTime { get; set; }
        public double Total { get; set; }
        public User User { get; set; }

        public IList<OrderItem> OrderItems { get; set; }

        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public Tracking Tracking { get; set; }

        public string VerifyOrder()
        {
            if (ShippingAddressId == 0 && ShippingAddress == null)
                return "No ShippingAddress Information";
            if (ShippingAddressId == 0 && ShippingAddress.VerifyAddress() != "valid")
                return ShippingAddress.VerifyAddress();

            if (PaymentId == 0 && Payment == null)
                return "Need Payment Infomation";
            if (PaymentId == 0 && Payment.VerifyPayment() != "valid")
                return Payment.VerifyPayment();

            return "valid";
        }
    }

}
