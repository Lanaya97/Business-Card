using BusinessCard.Application.Interfaces;
using BusinessCard.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessCard.Infrastructure.Repository
{
    public abstract class GenericRepositery<TEntity> : Irepository<TEntity> where TEntity : class
    {
        protected readonly BusinessCardContext _db;

        public GenericRepositery(BusinessCardContext db)
        {
            _db = db;
        }

        public virtual async Task<int> GetCount(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).CountAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {

            TEntity entity = await _db.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public virtual async Task<TEntity> GetByIdAsync(string[] includes, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _db.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var result = await query.FirstOrDefaultAsync(predicate);

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string include)
        {
            var query = _db.Set<TEntity>().AsQueryable();

            query = query.Include(include);

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] includes)
        {
            var query = _db.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string[] includes, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _db.Set<TEntity>().Where(predicate).AsQueryable();

            foreach (var include in includes)
            {
                query.Include(include);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }


        public virtual async Task<TEntity> FindSingleAsync(string include, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _db.Set<TEntity>().Where(predicate).AsQueryable();

            if (include != null)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> FindSingleAsync(string[] includes, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _db.Set<TEntity>().Where(predicate).AsQueryable();

            if (includes != null || includes.Any())
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            }
            return await query.SingleOrDefaultAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(string include, Expression<Func<TEntity, bool>> predicate)
        {
            var query = _db.Set<TEntity>().Where(predicate).AsQueryable();
            if (include != null)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
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
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }


        public virtual void Update<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> property)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).Property(property).IsModified = true;
        }

        public virtual void UpdateRange<TProperty>(IEnumerable<TEntity> entities, Expression<Func<TEntity, TProperty>> property)
        {
            _db.Set<TEntity>().AttachRange(entities);
            foreach (var entity in entities)
            {
                _db.Entry(entity).Property(property).IsModified = true;
            }
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
