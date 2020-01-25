using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CakeShop.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> GetElemByCondition(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        IQueryable<T> AsNoTracking();
    }
}
