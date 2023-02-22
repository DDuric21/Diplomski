using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? FullAddress { get; set; }
    }
}
