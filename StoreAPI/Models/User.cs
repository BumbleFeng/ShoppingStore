using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        //[EmailAddress]
        public string Username { get; set; }
        [Required]
        //[MinLength(8)]
        public string Password { get; set; }
        public string Token { get; set; }

        public virtual IList<ShoppingCart> ShoppingCarts { get; set; }

        public virtual IList<Address> Addresses { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }

        public virtual IList<Payment> Payments { get; set; }
    }
}
