using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Original { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public string Seller { get; set; }

        [Column(TypeName = "TINYINT(1)")]
        public bool NewTag { get; set; }

        [JsonIgnore]
        public virtual IList<ShoppingCart> ShoppingCarts { get; set; }
        [JsonIgnore]
        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}
