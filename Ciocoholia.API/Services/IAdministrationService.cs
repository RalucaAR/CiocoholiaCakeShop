using CakeShop.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciocoholia.API.Services
{
    public interface IAdministrationService
    {
        Task<IEnumerable<MyOrderViewModel>> GetAllUserOrders();
    }
}
