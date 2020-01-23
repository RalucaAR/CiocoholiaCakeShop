using System.ComponentModel.DataAnnotations;

namespace CakeShop.API.ViewModels
{
    public class OrderViewModel
    {
        [StringLength(255)]
        [Display(Name = "Nume")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine1 { get; set; }

        [StringLength(255)]
        [Display(Name = "Oraș")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Număr de telefon")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
