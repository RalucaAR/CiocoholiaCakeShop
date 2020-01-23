using CakeShop.Models;
using CakeShop.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Interfaces
{
    public interface ICakeRepository : IRepositoryBase<Cake>
    {
    }
}
