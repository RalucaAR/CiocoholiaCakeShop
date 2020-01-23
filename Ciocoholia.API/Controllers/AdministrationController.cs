using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.API.ViewModels;
using Ciocoholia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AdministrationController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Order>> AllOrders()
        {
            return await _repositoryWrapper.Order.GetAllAsync();
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> ManageCakes()
        {
            return await _repositoryWrapper.Cake.GetAllAsync();
        }

        
        [Route("[action]")]
        [HttpGet]
        public async Task<ManageCakeViewModel> AddCake()
        {
            var category = await _repositoryWrapper.Category.GetAllAsync();
            return new ManageCakeViewModel
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
    }
}