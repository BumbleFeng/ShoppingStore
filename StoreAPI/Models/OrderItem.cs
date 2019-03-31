using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("orderitem")]
    public class OrderItem
    {
        public string OrderId { get; set; }
        [JsonIgnore]
        public OrderDetail OrderDetail { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Number { get; set; }
    }

    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(t => new { t.OrderId, t.ItemId });
            builder.HasOne(t => t.OrderDetail).WithMany(p => p.OrderItems).HasForeignKey(t => t.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Item).WithMany(p => p.OrderItems).HasForeignKey(t => t.ItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
