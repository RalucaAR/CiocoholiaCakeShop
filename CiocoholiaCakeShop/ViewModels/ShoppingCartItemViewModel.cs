using CakeShop.Models;

namespace CakeShop.ViewModel
{
    public class ShoppingCartItemViewModel
    {
       public Cake Cake { get; set; }
        public int Quantity { get; set; }
    }
}