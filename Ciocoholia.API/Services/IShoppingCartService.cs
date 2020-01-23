using CakeShop.Models;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public interface IShoppingCartService
    {
        string Id { get; set; }
        IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        IEnumerable<ShoppingCartItem> ShoppingCartObjects { get; set; }
        Task<int> AddToCartAsync(Cake cake, int qty = 1);
        Task ClearCartAsync();
        Task<IEnumerable<ShoppingCartItems>> GetShoppingCartItemsAsync();
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartObjectsAsync();
        Task<int> RemoveFromCartAsync(Cake cake);
        Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync();
    }
}