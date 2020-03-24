using Ciocoholia.Models;
using Ciocoholia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CakeShop.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected RepositoryContext _repositoryContext { get; set; }
        protected RepositoryBase(RepositoryContext repositoryContext)
            : base()
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _repositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repositoryContext.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _repositoryContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetElemByCondition(Expression<Func<T, bool>> expression)
        {
            return await _repositoryContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> result = await _repositoryContext.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public T Update(T entity)
        {
            EntityEntry<T> result = _repositoryContext.Set<T>().Update(entity);
            return result.Entity;
        }

        public T Delete(T entity)
        {
            EntityEntry<T> result = _repositoryContext.Set<T>().Remove(entity);
            return result.Entity;
        }

        public IQueryable<T> AsNoTracking()
        {
            return _repositoryContext.Set<T>().AsNoTracking();
        }
    }
}
