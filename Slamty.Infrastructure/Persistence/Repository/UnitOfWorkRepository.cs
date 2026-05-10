using Slamty.Core.Entities;
using Slamty.Core.Interfaces.Infrastracture;
using Slamty.Infrastracture.Persistence.Data;
using System.Collections;

namespace Slamty.Infrastracture.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Hashtable _repositories;
        public UnitOfWork(AppDbContext context)
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
