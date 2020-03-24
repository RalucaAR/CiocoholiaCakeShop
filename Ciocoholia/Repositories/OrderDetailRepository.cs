using Ciocoholia.Models;
using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciocoholia.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }
    }
}
