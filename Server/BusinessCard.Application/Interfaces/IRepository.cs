using BusinessCard.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessCard.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, PagingCriteria<TEntity> pagingCriteria, bool disableTracking = true);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entites);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);

    }

}