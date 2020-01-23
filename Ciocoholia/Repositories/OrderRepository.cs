using CakeShop.Models;
using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ciocoholia.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }

        
    }
}
