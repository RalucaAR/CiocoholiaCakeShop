using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IShoppingCartService _shoppingCart;

        public ShoppingController(IRepositoryWrapper repositoryWrapper, IShoppingCartService shoppingCart)
        {
            _repositoryWrapper = repositoryWrapper;
            _shoppingCart = shoppingCart;
        }

        [Route("[action]/{id}")]
       // [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var selectedCake = await _repositoryWrapper.Cake.GetByIdAsync(id);
            if (selectedCake == null)
            {
                return NotFound();
            }

            var result = await _shoppingCart.AddToCartAsync(selectedCake);
           // var shopping = await _shoppingCart.GetCartCountAndTotalAmmountAsync();

            return Ok();
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedCake = await _repositoryWrapper.Cake.GetByIdAsync(id);
            if (selectedCake == null)
            {
                return NotFound();
            }

            await _shoppingCart.RemoveFromCartAsync(selectedCake);

            return Ok();
        }

        [Route("[action]")]
        //[HttpPost]
        public async Task<IActionResult> RemoveAllCart()
        {
            await _shoppingCart.ClearCartAsync();
            return Ok();
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<ShoppingCartItems>> GetCartItems()
        {
           return await _shoppingCart.GetShoppingCartItemsAsync();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public string GetCartItemById()
        {
            return  _shoppingCart.Id;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Cake> GetCakeById(int id)
        {
            return await  _repositoryWrapper.Cake.GetByIdAsync(id);
        }

    }
}