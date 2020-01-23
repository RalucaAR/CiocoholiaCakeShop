using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.ViewModels
{
    public class FeedbackViewModel
    {
        [StringLength(255)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(1500)]
        [Display(Name = "Mesajul tău:")]
        public string Content { get; set; }
    }
}
