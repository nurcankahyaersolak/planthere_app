using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Repositories;
using PlantHere.Domain.Common.Class;
using PlantHere.Persistence.Repositories;
using System.Collections.Concurrent;

namespace PlantHere.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object>();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetGenericRepository<T>() where T : class, new()
        {
         
            return (Repository<T>)_repositories.GetOrAdd(typeof(T).Name, t => new Repository<T>(_context)); ;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
