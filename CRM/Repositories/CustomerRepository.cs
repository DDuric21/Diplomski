using CRM.DbContext;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CrmDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> InsertAsync(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
           
            return entity;
        }

        public async Task<string> DeleteByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer == null)
            {
                return "No such Customer";
            }

            _context.Customers.Remove(customer);

            return "Customer " + id + " Deleted";
        }

        public async Task Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
