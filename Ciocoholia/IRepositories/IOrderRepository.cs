using CakeShop.Repositories;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciocoholia.IRepositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        //method created in order to kill mutants (Mutation testing)
        Order GetOrderByIdAsNoTraking(int id);
    }
}
