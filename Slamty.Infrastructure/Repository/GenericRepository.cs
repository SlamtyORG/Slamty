using Microsoft.EntityFrameworkCore;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Domain.Entities;
using Slamty.Domain.Specifications;
using Slamty.Infrastructure.Data.Identity;
using System.Linq.Expressions;

namespace Slamty.Infrastracture.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppIdentityDbContext _context;

        public GenericRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        => _context.Set<T>().Add(entity);

        public async Task DeleteAsync(Guid id)
        => _context.Set<T>().Remove(await GetByIdAsync(id));

        public Task<T> FindByCriatria(Expression<Func<T, bool>> criatria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
        => await _context.Set<T>().FindAsync(id);

        public Task<List<T>> GetBySpecAsync(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
    }
}
