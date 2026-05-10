using Slamty.Core.Entities;

namespace Slamty.Core.Interfaces.Infrastracture
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(T entity);
        public Task DeleteAsync(Guid id);
        public Task<T> GetByIdAsync(Guid id);
        public Task<List<T>> GetAllAsync();
    }
}
