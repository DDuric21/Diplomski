using CRM.DbContext;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class AddressRepository : IGenericRepository<Address>
    {
        private CrmDbContext _context;

        public AddressRepository(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> InsertAsync(Address entity)
        {
            await _context.Addresses.AddAsync(entity);
            
            return entity;
        }
        public async Task<string> DeleteByIdAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if(address == null)
            {
                return "No such Address";
            }

            _context.Addresses.Remove(address);

            return "Address " + id + " Deleted";
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TResult> Filter<TResult>(Expression<Func<Address, bool>> filter, Expression<Func<Address, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
