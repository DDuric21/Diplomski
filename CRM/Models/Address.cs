using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        public string? FullAddress { get; set; }
    }
}
