using CakeShop.Interfaces;
using CakeShop.IRepositories;
using Ciocoholia.IRepositories;
using System.Threading.Tasks;

namespace CakeShop.Repositories
{
    public interface IRepositoryWrapper
    {
        ICakeRepository Cake { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IShoppingCartItemRepository ShoppingCartItem { get; }
        IFeedbackRepository Feedback { get; }
        Task SaveAsync();
    }
}
