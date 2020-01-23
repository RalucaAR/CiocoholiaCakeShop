using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciocoholia.Models
{
    [Table("Feedback")]
    public class Feedback : BaseEntity
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15000)]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
