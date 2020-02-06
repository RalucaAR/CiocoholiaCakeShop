using CakeShop.API.ViewModels;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IShoppingCartService _shoppingCartService;
        public OrderService(RepositoryContext repositoryContext, IShoppingCartService shoppingCartService)
        {
            _repositoryContext = repositoryContext;
            _shoppingCartService = shoppingCartService;
        }
        public async Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync(string id)
        {
            return await _repositoryContext.Orders
                .Where(e => e.UserId == id)
                .Include(e => e.OrderDetails)
                .Select(e => new MyOrderViewModel
                {
                    Id = e.Id,
                    OrderPlacedTime = e.OrderPlacedTime,
                    OrderTotal = e.OrderTotal,
                    OrderPlaceDetails = new OrderViewModel
                    {
                        AddressLine1 = e.AddressLine1,
                        City = e.City,
                        Email = e.User.Email,
                        Name = e.User.UserName,
                        PhoneNumber = e.PhoneNumber
                    },
                    CakeOrderInfos = e.OrderDetails.Select(o => new MyCakeOrderInfo
                    {
                        Name = o.CakeName,
                        Price = o.Price,
                        Quantity = o.Quantity
                    }),
                    OrderState = e.OrderState
                })
                .ToListAsync();
        }

        public async Task  CreateOrderAsync(Order order)
        {
            order.OrderPlacedTime = DateTime.Now;
           var shoppingCartItems = await _shoppingCartService.GetShoppingCartObjectsAsync();
            order.OrderTotal = (await _shoppingCartService.GetCartCountAndTotalAmmountAsync()).TotalAmmount;

            await _repositoryContext.Orders.AddAsync(order);
            await  _repositoryContext.SaveChangesAsync();

            foreach(var item in shoppingCartItems)
            {
                await _repositoryContext.OrderDetails.AddAsync(new OrderDetail
                {
                    Quantity = item.Quantity,
                    CakeName = item.Cake.Name,
                    OrderId = order.Id,
                    Price = item.Cake.Price,

                });
                
            }
            await _repositoryContext.SaveChangesAsync();

        }
    }
}
