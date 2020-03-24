using CakeShop.Models;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.ViewModels
{
    public class ManageCakeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Cake Cake { get; set; }

        public ManageCakeViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
