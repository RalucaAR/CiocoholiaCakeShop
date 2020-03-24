using CakeShop.Models;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.ViewModels
{
    public class AddCakeViewModel
    {
        public string Name { set; get; }

        public string Weigth { set; get; }

        public decimal Price { set; get; }

        public string Description { set; get; }

        public IFormFile Image { get; set; }
        public bool IsCakeOfTheWeek { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public AddCakeViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
