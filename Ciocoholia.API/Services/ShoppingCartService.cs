using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly RepositoryContext _context;

        public string Id { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartObjects { get; set; }

        private ShoppingCartService(RepositoryContext context)
        {
            _context = context;
        }

        public static ShoppingCartService GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<RepositoryContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new ShoppingCartService(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCartAsync(Cake cake, int quantity = 1)
        {
            return await AddOrRemoveCart(cake, quantity);

        }

        public async Task<int> RemoveFromCartAsync(Cake cake)
        {
            return await AddOrRemoveCart(cake, -1);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartObjectsAsync()
        {
            ShoppingCartObjects = ShoppingCartObjects ?? await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartCookie == Id)
                .Include(e => e.Cake)
                .ToListAsync();

            return ShoppingCartObjects;

        }

        public async Task<IEnumerable<ShoppingCartItems>> GetShoppingCartItemsAsync()
        {
            var shopCartItems = await _context.ShoppingCartItems
                .Where(e => e.ShoppingCartCookie == Id)
                .Include(e => e.Cake)
                .ToListAsync();

            List<ShoppingCartItems> shopCartVm = new List<ShoppingCartItems>();

            foreach (var shop in shopCartItems)
            {
                shopCartVm.Add(new ShoppingCartItems
                {
                    ShoppingCartId = Id,
                    CakeId = shop.Cake.Id,
                    CakeDescription = shop.Cake.Description,
                    CakeName = shop.Cake.Name,
                    CakePrice = shop.Cake.Price,
                    CakeUrl = shop.Cake.ImageUrl,
                    ItemPrice = shop.Cake.Price * shop.Quantity,
                    Quantity = shop.Quantity,
                    CakeWeigth = shop.Cake.Weigth,
                    CakeIsCakeOfTheWeek = shop.Cake.IsCakeOfTheWeek
                });
            }

            return shopCartVm;
        }

        public async Task ClearCartAsync()
        {
            var shoppingCartItems = _context
                .ShoppingCartItems
                .Where(s => s.ShoppingCartCookie == Id);

            _context.ShoppingCartItems.RemoveRange(shoppingCartItems);

            ShoppingCartObjects = new List<ShoppingCartItem>() ; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, decimal TotalAmmount)> GetCartCountAndTotalAmmountAsync()
        {
            var subTotal = ShoppingCartObjects?
                .Select(c => c.Cake.Price * c.Quantity) ??
                await _context.ShoppingCartItems
                .Where(c => c.ShoppingCartCookie == Id)
                .Select(c => c.Cake.Price * c.Quantity)
                .ToListAsync();

            return (subTotal.Count(), subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCart(Cake cake, int quatity)
        {
            var shoppingCartItem = await _context.ShoppingCartItems
                            .SingleOrDefaultAsync(s => s.Cake.Id == cake.Id && s.ShoppingCartCookie == Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartCookie = Id,
                    Cake = cake,
                    Quantity = 0
                };

                await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }

            shoppingCartItem.Quantity += quatity;

            if (shoppingCartItem.Quantity <= 0)
            {
                shoppingCartItem.Quantity = 0;
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();

            ShoppingCartItems = null; // Reset

            return await Task.FromResult(shoppingCartItem.Quantity);
        }

    }
}
