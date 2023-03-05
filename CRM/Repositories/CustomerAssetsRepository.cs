using CRM.DbContext;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class CustomerAssetsRepository : IGenericRepository<CustomerAssets>, ICustomerAssetsRepository
    {
        private CrmDbContext _context;

        public CustomerAssetsRepository(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerAssets>> GetAllAsync()
        {
            return await _context.CustomerAssets.ToListAsync();
        }

        public async Task<CustomerAssets> GetByIdAsync(int id)
        {
            return await _context.CustomerAssets.FindAsync(id);
        }

        public async Task<IEnumerable<CustomerAssets>> GetByCustomerIdAsync(int id)
        {
            return await _context.CustomerAssets
                .Where(cA => cA.CustomerID == id)
                .ToListAsync();
        }

        public async Task<CustomerAssets> InsertAsync(CustomerAssets entity)
        {
            await _context.CustomerAssets.AddAsync(entity);

            return entity;
        }
        public async Task<string> DeleteByIdAsync(int id)
        {
            var customerAsset = await _context.CustomerAssets.FindAsync(id);

            if (customerAsset == null)
            {
                return "No such Asset on Customer";
            }

            _context.CustomerAssets.Remove(customerAsset);

            return "Asset " + id + "Deleted from Customer";
        }

        public async Task Save()
        {
            _context.SaveChangesAsync();
        }

        public IEnumerable<TResult> Filter<TResult>(Expression<Func<CustomerAssets, bool>> filter, Expression<Func<CustomerAssets, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
