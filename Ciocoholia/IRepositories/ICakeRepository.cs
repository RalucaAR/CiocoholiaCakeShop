using Ciocoholia.Models;
using CakeShop.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CakeShop.Interfaces
{
    public interface ICakeRepository : IRepositoryBase<Cake>
    {
        // methods created in order to facilitate the mutants killing (Mutation testing)
        Task<List<Cake>> GetCakeByCategoryName(string name);
        Task<List<Cake>> GetCakeByIsCakeOfTheWeek(bool cakeStatus);
        Cake GetCakeByNameAsNoTracking(string name);
    }
}
