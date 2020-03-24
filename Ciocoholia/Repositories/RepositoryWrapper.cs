using CakeShop.Interfaces;
using CakeShop.IRepositories;
using Ciocoholia.Models;
using Ciocoholia;
using Ciocoholia.IRepositories;
using Ciocoholia.Repositories;
using System.Threading.Tasks;

namespace CakeShop.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ICakeRepository _cake;
        private ICategoryRepository _category;
        private IOrderRepository _order;
        private IOrderDetailRepository _orderDetail;
        private IShoppingCartItemRepository _shoppingCartItem;
        private IFeedbackRepository _feedback;

        public ICakeRepository Cake
        {
            get
            {
                if (_cake == null)
                {
                    _cake = new CakeRepository(_repositoryContext);
                }
                return _cake;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repositoryContext);
                }

                return _category;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repositoryContext);
                }
                return _order;
            }
        }

        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if(_orderDetail == null)
                {
                    _orderDetail = new OrderDetailRepository(_repositoryContext);
                }
                return _orderDetail;
            }
        }
        public IShoppingCartItemRepository ShoppingCartItem
        {
            get
            {
                if (_shoppingCartItem == null)
                {
                    _shoppingCartItem = new ShoppingCartItemRepository(_repositoryContext);
                }
                return _shoppingCartItem;
            }
        }

        public IFeedbackRepository Feedback
        {
            get
            {
                if (_feedback == null)
                {
                    _feedback = new FeedbackRepository(_repositoryContext);
                }
                return _feedback;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
