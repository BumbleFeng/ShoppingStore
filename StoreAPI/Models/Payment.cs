using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("payment")]
    public class Payment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Column(TypeName = "TINYINT(1)")]
        public bool DefaultPayment { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }

        [JsonIgnore]
        public virtual OrderDetail OrderDetail { get; set; }

        public Payment()
        {
        }
    }

    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(t => t.BillingAddress).WithOne(p => p.Payment).HasForeignKey<Payment>(t => t.BillingAddressId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(t => t.User).WithMany(p => p.Payments).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
