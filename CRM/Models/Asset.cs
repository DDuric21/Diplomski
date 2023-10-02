using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Asset
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CurrencyID { get; set; }
    }
}
