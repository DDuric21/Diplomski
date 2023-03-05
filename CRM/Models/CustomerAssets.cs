using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class CustomerAssets
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerID { get; set; }
        [ForeignKey("AssetID")]
        public int AssetID { get; set; }
    }
}
