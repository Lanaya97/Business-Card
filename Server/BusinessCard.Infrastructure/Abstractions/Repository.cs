using BusinessCard.Application.Common;
using BusinessCard.Application.Interfaces;
using BusinessCard.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessCard.Infrastructure.Abstraction
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).CountAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = await _db.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {

            TEntity entity = await _db.Set<TEntity>().FirstOrDefaultAsync(predicate);

            return entity;
        }

        public virtual async Task<List<TEntity>> FindListAsync(
                                       Expression<Func<TEntity, bool>> predicate,
                                       PagingCriteria<TEntity> pageCriteria,
                                       bool disableTracking = true
                                       )
        {
            IQueryable<TEntity> query = _db.Set<TEntity>().AsQueryable();

            if (disableTracking)
                query = query.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (pageCriteria.Order != null)
                query = pageCriteria.IsAscending ? query.OrderBy(pageCriteria.Order) : query.OrderByDescending(pageCriteria.Order);

            return await query.Skip((pageCriteria.PageNumber - 1) * pageCriteria.PageSize).Take(pageCriteria.PageSize).ToListAsync();
        }


        public virtual async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);

        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entites)
        {
            await _db.Set<TEntity>().AddRangeAsync(entites);
        }

        public virtual void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entites)
        {
            _db.Set<TEntity>().RemoveRange(entites);
        }


    }
}
