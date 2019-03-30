using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingStore.Models
{
    public class User
    {
        [Required]
        //[EmailAddress]
        public string Username { get; set; }
        [Required]
        //[MinLength(8)]
        public string Password { get; set; }
        public string Token { get; set; }

        public IList<ShoppingCart> ShoppingCarts { get; set; }

        public IList<Address> Addresses { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }

        public IList<Payment> Payments { get; set; }

        public User()
        {
        }
    }
}
