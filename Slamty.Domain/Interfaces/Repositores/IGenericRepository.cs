using Slamty.Domain.Entities;
using Slamty.Domain.Specifications;
using System.Linq.Expressions;

namespace Slamty.Domain.Interfaces.Repositores
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(T entity);
        public Task DeleteAsync(Guid id);
        public Task<T> GetByIdAsync(Guid id);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetBySpecAsync(ISpecification<T> specification);

        public Task<T> FindByCriatria(Expression<Func<T, bool>> criatria);
    }
}
