using CakeShop.Interfaces;
using CakeShop.Models;
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
    }
}
