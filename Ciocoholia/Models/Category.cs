using Ciocoholia.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciocoholia.Models
{
    [Table("Category")]
    public class Category : BaseEntity
    { 
        [Required(ErrorMessage = "Name type is required")]
        public string Name { get; set; }

        public ICollection<Cake> Cakes { get; set; }
    }
}
