using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        [StringLength(5)]
        public string Zip { get; set; }
        [Phone]
        public string Phone { get; set; }

        [Column(TypeName = "TINYINT(1)")]
        public bool DefaultAddress { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public virtual Payment Payment { get; set; }

        [JsonIgnore]
        public virtual OrderDetail OrderDetail { get; set; }
        
        public Address()
        {
        }
    }

    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(t => t.User).WithMany(p => p.Addresses).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
