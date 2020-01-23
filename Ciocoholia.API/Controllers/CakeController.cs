using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Models;
using CakeShop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ciocoholia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CakeController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> CakeOfTheWeek()
        {
            var CakeOfTheWeek = await _repositoryWrapper.Cake.GetByCondition(cake => cake.IsCakeOfTheWeek == true);

            return CakeOfTheWeek;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> PieceOfCake()
        {
            var PieceOfCake = await _repositoryWrapper.Cake.GetByCondition(cake => cake.Category.Name == "PieceOfCake");

            return PieceOfCake;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> Cake()
        {
            var Cake = await _repositoryWrapper.Cake.GetByCondition(cake => cake.Category.Name == "Cake");

            return Cake;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Cake> CakeDetail(int id)
        {

            var Cake = await _repositoryWrapper.Cake.GetByIdAsync(id);

            return Cake;
        }
    }
}