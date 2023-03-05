using CRM.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<string> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TResult> Filter<TResult>(
            Expression<Func<T, bool>> filter, 
            Expression<Func<T, TResult>> selector)
        {
            var options = new DbContextOptionsBuilder();
            var connectionString = "Data Source=(localdb)\\Local;Database=DiplomskiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;ApplicationIntent=ReadWrite;MultipleActiveResultSets=True";
            options.UseSqlServer(connectionString);

            using (var context = new CrmDbContext((DbContextOptions<CrmDbContext>)options.Options))
            {
                var dbset = context.Set<T>();

                var select = dbset
                    .AsNoTracking()
                    .Where(filter);

                var result = select
                    .Select(selector)
                    .ToList();

                return result;
            }
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
