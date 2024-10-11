using System.Threading.Tasks;

namespace BusinessCard.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void Add<TEntity>(TEntity item) where TEntity : class;

        Task AddAsync<TEntity>(TEntity item) where TEntity : class;

        Task<bool> CompleteAsync();

        bool Complete();

        void Dispose();

    }
}