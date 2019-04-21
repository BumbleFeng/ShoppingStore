using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ShoppingStore.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public string Issuer { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; }
        [StringLength(4)]
        public string Expiration { get; set; }
        [StringLength(3)]
        public string CVV { get; set; }

        public bool DefaultPayment { get; set; }

        public int BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }

        public string Exp()
        {
            return DateTime.ParseExact(Expiration, "MMyy", CultureInfo.InvariantCulture).ToString("yyyy/MM");
        }

        public string VerifyPayment()
        {
            if (CardNumber.Length != 16 || !long.TryParse(CardNumber, out long n))
                return "Invalid Card Number";
            if (Expiration.Length != 4 || !DateTime.TryParseExact(Expiration, "MMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d) || d.AddMonths(1).CompareTo(DateTime.Now) != 1)
                return "Invalid Expiration";
            if (CVV.Length != 3 || !int.TryParse(CVV, out int c))
                return "Invalid CVV";
            if (BillingAddress != null && BillingAddress.VerifyAddress() != "valid")
                return BillingAddress.VerifyAddress();

            return "vaild";
        }
    }
}
