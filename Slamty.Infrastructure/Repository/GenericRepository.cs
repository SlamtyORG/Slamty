using Microsoft.EntityFrameworkCore;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Domain.Entities;
using Slamty.Infrastructure.Data.Identity;

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

        public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
        => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
        => _context.Set<T>().Update(entity);
    }
}
