using Slamty.Core.Entities;

namespace Slamty.Core.Interfaces.Infrastracture
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public Task<int> Complete();
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
