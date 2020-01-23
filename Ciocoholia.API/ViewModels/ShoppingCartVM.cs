using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.ViewModels
{
    public class ShoppingCartItems
    {
        public int Quantity { get; set; }
        public string CakeName { get; set; }
        public decimal CakePrice { get; set; }
        public string CakeDescription { get; set; }
        public int CakeId { get; set; }
        public string CakeUrl { get; set; }
        public string CakeWeigth { get; set; }
        public bool CakeIsCakeOfTheWeek { get; set; }
        public decimal ItemPrice { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
