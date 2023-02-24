using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CurrencyID { get; set; }
    }
}
