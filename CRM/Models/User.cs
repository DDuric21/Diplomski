using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }

        [ForeignKey("UserRoleId")]
        public int UserRoleId { get; set; }
    }
}
