using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CiocoholiaCakeShop.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmă Parola")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolele nu corespund!")]
        public string ConfirmPassword { get; set; }
    }
}
