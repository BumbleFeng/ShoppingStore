using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StoreAPI.Models
{
    [Table("tracking")]
    public class Tracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackingId { get; set; }

        public string Status { get; set; }

        public string OrderId { get; set; }

        public OrderDetail OrderDetail { get; set; }
        
        public Tracking()
        {
        }
    }

    public class TrackingMap : IEntityTypeConfiguration<Tracking>
    {
        public void Configure(EntityTypeBuilder<Tracking> builder)
        {
            builder.HasOne(t => t.OrderDetail).WithOne(p => p.Tracking).HasForeignKey<Tracking>(t => t.OrderId).OnDelete(DeleteBehavior.SetNull);
        }
    }

}