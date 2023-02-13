using PlantHere.Application.Interfaces.Repositories;

namespace PlantHere.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetGenericRepository<T>() where T : class, new();

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);

        void Commit();
    }
}
