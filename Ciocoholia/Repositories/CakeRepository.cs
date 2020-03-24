using CakeShop.Interfaces;
using Ciocoholia.Models;
using Ciocoholia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Repositories
{
    public class CakeRepository : RepositoryBase<Cake>, ICakeRepository
    {
        protected RepositoryContext repositoryContext { get; set; }
        public CakeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public Task<List<Cake>> GetCakeByCategoryName(string name)
        {
            return GetByCondition(cake => cake.Category.Name == name);
        }

        public Task<List<Cake>> GetCakeByIsCakeOfTheWeek(bool cakeStatus)
        {
            return GetByCondition(cake => cake.IsCakeOfTheWeek == cakeStatus);
        }

        public Cake GetCakeByNameAsNoTracking(string name)
        {
            return AsNoTracking().FirstOrDefault(cake => cake.Name == name);
        }
    }
}
