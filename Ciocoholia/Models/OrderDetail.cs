using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciocoholia.Models
{
    public class OrderDetail : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CakeName { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
