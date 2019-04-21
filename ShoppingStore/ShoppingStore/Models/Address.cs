using System.ComponentModel.DataAnnotations;

namespace ShoppingStore.Models
{
    public class Address
    {
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

        public bool DefaultAddress { get; set; }

        public string VerifyAddress()
        {
            if (Zip.Length != 5 || !int.TryParse(Zip, out int z))
                return "Invalid ZipCode";
            if (Phone == "")
                Phone = null;
            if (Phone != null && !long.TryParse(Phone, out long p))
                return "Invalid Phone Number";

            return "valid";
        }
    }
}
