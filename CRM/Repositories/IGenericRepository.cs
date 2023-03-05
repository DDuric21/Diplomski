using System.Linq.Expressions;

namespace CRM.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<string> DeleteByIdAsync(int id);
        Task Save();
        IEnumerable<TResult> Filter<TResult>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector);
    }
}
