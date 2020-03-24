using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.API.ViewModels;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.Services;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IAdministrationService _administrationService;

        public AdministrationController(
            IRepositoryWrapper repositoryWrapper,
            IAdministrationService administrationService)
        {
            _repositoryWrapper = repositoryWrapper;
            _administrationService = administrationService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<MyOrderViewModel>> AllOrders()
        {
            return await _administrationService.GetAllUserOrders();
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
                return BadRequest(ModelState);
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
           var cakeById =  _repositoryWrapper.Cake.GetCakeByNameAsNoTracking(cake.Name);
            if (cakeById != null)
            {
                cake.Id = cakeById.Id;
                _repositoryWrapper.Cake.Update(cake);
                await _repositoryWrapper.SaveAsync();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
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
            var orderById = _repositoryWrapper.Order.GetOrderByIdAsNoTraking(order.Id);
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