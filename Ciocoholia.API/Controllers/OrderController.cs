using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.API.ViewModels;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.Services;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly RepositoryContext _repositoryContext;

        public OrderController(
            IShoppingCartService shoppingCartService,
            IMapper mapper,
            IOrderService orderService,
            RepositoryContext repositoryContext)
        {
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            _orderService = orderService;
            _repositoryContext = repositoryContext;
        }

        [Route("[action]")]
       // [HttpPost]
        public async Task<IEnumerable<ShoppingCartItems>> Checkout()
        {
            return await _shoppingCartService.GetShoppingCartItemsAsync();

        }

        [Route("[action]/{order}")]
        [HttpPost]
        public async Task<IActionResult> CheckoutOrder(Order order)
        {
            var cartItems = await Checkout();

            if (cartItems?.Count() <= 0)
            {
                return NoContent();
            }
            //var order = _mapper.Map<OrderViewModel, Order>(orderViewModel);
           
            await _orderService.CreateOrderAsync(order);
            await _shoppingCartService.ClearCartAsync();
            
            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IEnumerable<MyOrderViewModel>> MyOrder(string id)
        {

            var userId = id;
            return await _orderService.GetAllOrdersAsync(userId);
        }
    }
}