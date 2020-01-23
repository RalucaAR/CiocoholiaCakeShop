using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciocoholia.Repositories
{
    public class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
