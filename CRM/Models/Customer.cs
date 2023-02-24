using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("AdressId")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public DateTime Birthday { get; set; }

        [NotMapped]
        public IDictionary<int, Asset> Assets { get; set; }
    }
}
