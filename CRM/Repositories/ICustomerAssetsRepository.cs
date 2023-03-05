using CRM.Models;

namespace CRM.Repositories
{
    public interface ICustomerAssetsRepository : IGenericRepository<CustomerAssets>
    {
        Task<IEnumerable<CustomerAssets>> GetByCustomerIdAsync(int id);
    }
}
