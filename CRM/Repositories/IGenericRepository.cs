using System.Linq.Expressions;

namespace CRM.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> InsertAsync(T entity);
        Task<string> DeleteByIdAsync(long id);
        Task Save();
        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>An System.Linq.IQueryable`1 that contains elements from the input sequence that satisfy the condition specified by predicate.</returns>
        /// <exceptions>T:System.ArgumentNullException: source or predicate is null.</exceptions>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
