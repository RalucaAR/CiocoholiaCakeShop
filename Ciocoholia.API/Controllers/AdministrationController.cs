using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.API.ViewModels;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(
            IRepositoryWrapper repositoryWrapper,
            UserManager<IdentityUser> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _userManager = userManager;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<MyOrderViewModel>> AllOrders()
        {
            var orders =  await _repositoryWrapper.Order.GetAllAsync();
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


        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> ManageCakes()
        {
            return await _repositoryWrapper.Cake.GetAllAsync();
        }

        
        [Route("[action]")]
        [HttpGet]
        public async Task<AddCakeViewModel> AddCake()
        {
            var category = await _repositoryWrapper.Category.GetAllAsync();
            return new AddCakeViewModel
            {
                Categories = category
            };
        }

        [Route("[action]/{cake}")]
        [HttpPost]
        public async Task<IActionResult> AddCake(Cake cake)
        {
            if (!ModelState.IsValid)
            {
                return Problem("Invalid action!");
            }
            await _repositoryWrapper.Cake.CreateAsync(cake);
            await _repositoryWrapper.SaveAsync();
            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ManageCakeViewModel> EditCake(int id)
        {
            var cake = await _repositoryWrapper.Cake.GetByIdAsync(id);
            var category = await _repositoryWrapper.Category.GetAllAsync();
            
            return new ManageCakeViewModel
            {
                Categories = category,
                Cake = cake
            };
        }

        [Route("[action]/{cake}")]
        [HttpPut]
        public async Task<IActionResult> EditCake(Cake cake)
        {
            if (!ModelState.IsValid)
            {
                return Problem("Invalid action!");
            }
           var cakeById =  _repositoryWrapper.Cake.AsNoTracking().FirstOrDefault(x => x.Name == cake.Name);
            cake.Id = cakeById.Id;
            _repositoryWrapper.Cake.Update(cake);
            await _repositoryWrapper.SaveAsync();

            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCake(int id)
        {
            var cake = await _repositoryWrapper.Cake.GetByIdAsync(id);
            _repositoryWrapper.Cake.Delete(cake);
            await _repositoryWrapper.SaveAsync();
            return Ok();
        }

        [Route("[action]/{order}")]
        [HttpPut]
        public async Task<IActionResult> SetOrderState(Order order)
        {
            var orderById = _repositoryWrapper.Order.AsNoTracking().FirstOrDefault(x => x.Id == order.Id);
            if (orderById != null)
            {
                orderById.OrderState = order.OrderState;
                _repositoryWrapper.Order.Update(orderById);
                await _repositoryWrapper.SaveAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}