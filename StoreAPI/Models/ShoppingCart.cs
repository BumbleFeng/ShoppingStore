using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("shoppingcart")]
    public class ShoppingCart
    {

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Number { get; set; }

        public DateTime AddTime { get; set; }

        public ShoppingCart()
        {
        }
    }

    public class ShoppingCartMap : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(t => new { t.UserId, t.ItemId });
            builder.HasOne(t => t.User).WithMany(p => p.ShoppingCarts).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Item).WithMany(p => p.ShoppingCarts).HasForeignKey(t => t.ItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
