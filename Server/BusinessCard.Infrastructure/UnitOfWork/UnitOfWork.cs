using BusinessCard.Application.Interfaces;
using BusinessCard.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BusinessCard.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class
        {
            _context.Set<TEntity>().Add(item);
        }

        public async Task AddAsync<TEntity>(TEntity item) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(item).ConfigureAwait(false);
        }

        public async Task<bool> CompleteAsync()
        {

            try
            {
                return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Failed to insert or update Database due to concurrency issue");
            }
            catch (DbUpdateException)
            {
                throw new Exception("Failed to insert or update Database");
            }
        }
        public bool Complete()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Failed to insert or update Database due to concurrency issue");
            }
            catch (DbUpdateException)
            {
                throw new Exception("Failed to insert or update Database");
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
