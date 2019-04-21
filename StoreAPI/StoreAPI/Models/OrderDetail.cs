using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("orderdetail")]
    public class OrderDetail
    {
        [Key]
        public string OrderId { get; set; }

        public string Staus { get; set; }
        public DateTime PlacedTime { get; set; }
        public double Total { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public string Code { get; set; }
        public PromoCode PromoCode { get; set; }

        public virtual Tracking Tracking { get; set; }
    }

    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasOne(t => t.User).WithMany(p => p.OrderDetails).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(t => t.ShippingAddress).WithOne(p => p.OrderDetail).HasForeignKey<OrderDetail>(t => t.ShippingAddressId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(t => t.Payment).WithOne(p => p.OrderDetail).HasForeignKey<OrderDetail>(t => t.PaymentId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(t => t.PromoCode).WithOne(p => p.OrderDetail).HasForeignKey<OrderDetail>(t => t.Code).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
