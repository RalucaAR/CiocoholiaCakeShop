using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciocoholia.Models
{
    public class ShoppingCartItem : BaseEntity
    {
        public int Quantity { get; set; }

        public Cake Cake { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemPrice { get; set; }

        [Required]
        [StringLength(255)]
        public string ShoppingCartCookie { get; set; }
    }
}
