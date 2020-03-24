using Ciocoholia.Models;
using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Ciocoholia.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }

        public Order GetOrderByIdAsNoTraking(int id)
        {
            return AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

    }
}
