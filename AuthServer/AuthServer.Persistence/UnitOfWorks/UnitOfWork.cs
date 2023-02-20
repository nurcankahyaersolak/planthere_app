using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Persistence.Repositories;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IRepository<T> GetGenericRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommmitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}