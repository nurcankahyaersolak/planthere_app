using AuthServer.Application.Interfaces.Repositories;

namespace UdemyAuthServer.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommmitAsync();

        void Commit();

        IRepository<T> GetGenericRepository<T>() where T : class, new();

    }
}