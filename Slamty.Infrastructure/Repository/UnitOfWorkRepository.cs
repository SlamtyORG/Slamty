using Slamty.Application.Interfaces.Repositores;
using Slamty.Domain.Entities;
using Slamty.Infrastructure.Data.Identity;
using System.Collections;

namespace Slamty.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;
        private readonly Hashtable _repositories;
        public UnitOfWork(AppIdentityDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> Complete()
        => await _context.SaveChangesAsync();


        public ValueTask DisposeAsync()
        => _context.DisposeAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity).Name))
            {
                return _repositories[typeof(TEntity).Name] as IGenericRepository<TEntity>;
            }
            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity).Name, repository);
            return repository;
        }
    }
}
