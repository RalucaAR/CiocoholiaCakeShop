using CakeShop.API.ViewModels;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync(string userId);
       // Task CreateOrderAsync(Order order);
        Task CreateOrderAsync(Order order);
        
    }
}
