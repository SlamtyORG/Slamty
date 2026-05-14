using Slamty.Domain.Entities;

namespace Slamty.Application.Interfaces.Repositores
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public Task<int> Complete();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
