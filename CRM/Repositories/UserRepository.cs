using CRM.Models;
using Microsoft.EntityFrameworkCore;
using CRM.DbContext;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private CrmDbContext _context;

        public UserRepository(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _context.Users.AddAsync(entity);

            return entity;
        }

        public async Task<string> DeleteByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return "No such User";
            }

            _context.Users.Remove(user);

            return "User " + id + " Deleted";
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TResult> Filter<TResult>(Expression<Func<User, bool>> filter, Expression<Func<User, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
