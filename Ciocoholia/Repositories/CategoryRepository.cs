using CakeShop.Interfaces;
using CakeShop.IRepositories;
using Ciocoholia.Models;
using Ciocoholia;

namespace CakeShop.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
