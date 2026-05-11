using Slamty.Domain.Entities;

namespace Slamty.Domain.Interfaces.Repositores
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public Task<int> Complete();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
