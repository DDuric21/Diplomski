﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("AdressId")]
        public long AddressId { get; set; }
        public Address? Address { get; set; }
        public DateTime Birthday { get; set; }

        [NotMapped]
        public ICollection<Asset> Assets { get; set; }
    }
}
