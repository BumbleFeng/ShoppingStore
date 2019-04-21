using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace StoreAPI.Models
{
    [Table("promocode")]
    public class PromoCode
    {
        [Key]
        public string Code { get; set; }
        public double Discount { get; set; }

        [JsonIgnore]
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
