using CRM.DbContext;
using CRM.Models;

namespace CRM.Repositories
{
    public class CrmRepository : ICrmRepository
    {
        private readonly CrmDbContext _context;
        public CrmRepository(CrmDbContext context)
        {
            _context = context;
        }

        private ICustomerRepository _customers;

        public ICustomerRepository Customers 
        {
            get
            {
                if( _customers == null)
                {
                    _customers = new CustomerRepository(_context);
                }

                return _customers;
            }
        }

        public IAssetRepository _asets;

        public IAssetRepository Assets
        {
            get
            {
                if (_asets == null)
                {
                    _asets = new AssetRepository(_context);
                }

                return _asets;
            }
        }

        public ICustomerAssetsRepository _customerAssets;

        public ICustomerAssetsRepository CustomerAssets
        {
            get
            {
                if (_customerAssets == null)
                {
                    _customerAssets = new CustomerAssetsRepository(_context);
                }

                return _customerAssets;
            }
        }

        public IGenericRepository<Address> Addresses { get; set; }

        public IGenericRepository<User> Users { get; set; }
    }
}
