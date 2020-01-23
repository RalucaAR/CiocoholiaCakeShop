using CakeShop.Models;
using Ciocoholia.API.ViewModels;
using System.Collections.Generic;

namespace CakeShop.API.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string ShoppingCartId { get; set; }
        public IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}
