using CRM.Models;

namespace CRM.Repositories
{
    public interface ICrmRepository
    {
        ICustomerRepository Customers { get; }
        IAssetRepository Assets { get; }
        ICustomerAssetsRepository CustomerAssets { get; }
        IGenericRepository<Address> Addresses { get; }
        IGenericRepository<User> Users { get; }
    }
}
