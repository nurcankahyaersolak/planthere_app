using System.Linq.Expressions;

namespace PlantHere.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetQueryableAsNoTracking();

        Task<List<T>> GetAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Remove(T entity);

        Task RemoveAsync(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
