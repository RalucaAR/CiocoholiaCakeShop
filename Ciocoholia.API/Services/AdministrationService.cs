using CakeShop.API.ViewModels;
using CakeShop.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationService(
            IRepositoryWrapper repositoryWrapper,
            UserManager<IdentityUser> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _userManager = userManager;
        }
        public async Task<IEnumerable<MyOrderViewModel>> GetAllUserOrders()
        {
            var orders = await _repositoryWrapper.Order.GetAllAsync();
            List<MyOrderViewModel> allOrders = new List<MyOrderViewModel>();
            foreach (var order in orders)
            {
                var user = await _userManager.FindByIdAsync(order.UserId);
                allOrders.Add(new MyOrderViewModel
                {
                    Id = order.Id,
                    OrderPlacedTime = order.OrderPlacedTime,
                    OrderTotal = order.OrderTotal,
                    OrderPlaceDetails = new OrderViewModel
                    {
                        AddressLine1 = order.AddressLine1,
                        City = order.City,
                        Email = user.Email,
                        Name = user.UserName,
                        PhoneNumber = order.PhoneNumber
                    },
                    CakeOrderInfos = _repositoryWrapper.OrderDetail.GetByCondition(x => x.OrderId == order.Id)
                    .Result.Select(x => new MyCakeOrderInfo
                    {
                        Name = x.CakeName,
                        Quantity = x.Quantity,
                        Price = x.Price
                    }),
                    OrderState = order.OrderState
                });
            }

            return allOrders;
        }
    }
}
