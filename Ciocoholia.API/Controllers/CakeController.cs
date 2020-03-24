using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.Models;
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

        [Route("[action]/{cakeStatus}")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> CakeOfTheWeek(bool cakeStatus)
        {
            var CakeOfTheWeek = await _repositoryWrapper.Cake.GetCakeByIsCakeOfTheWeek(cakeStatus);
            if (CakeOfTheWeek != null)
            {
                return CakeOfTheWeek;
            }
            else
            {
                return null;
            }
        }

        [Route("[action]/{category}")]
        [HttpGet]
        public async Task<IEnumerable<Cake>> Category(string category)
        {
            var Cake = await _repositoryWrapper.Cake.GetCakeByCategoryName(category);
            if (Cake != null)
            {
                return Cake;
            }
            else
            {
                return null;
            }
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