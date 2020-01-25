using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciocoholia.Models
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        [Required]
        public DateTime OrderPlacedTime { get; set; }

        public string AddressLine1 { get; set; }

        [StringLength(255)]
        [Required]
        public string City { get; set; }

        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderTotal { get; set; }

        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
