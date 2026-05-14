using Microsoft.EntityFrameworkCore;
using Slamty.Domain.Entities;
using Slamty.Domain.Interfaces.Repositores;
using Slamty.Domain.Specifications;
using Slamty.Infrastructure.Data.Identity;
using Slamty.Infrastructure.Specifications;
using System.Linq.Expressions;

namespace Slamty.Infrastructure.Repository
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

        public async Task<T> FindByCriatria(Expression<Func<T, bool>> criatria)
        => await _context.Set<T>().FirstOrDefaultAsync(criatria);


        public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetBySpecAsync(ISpecification<T> specification)
        {
            var query = SpecificationEvaluator<T>.GenerateQuery(_context.Set<T>().AsQueryable(), specification);
            return await query.ToListAsync();
        }

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
    }
}
