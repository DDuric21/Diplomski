using CRM.DbContext;
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Repositories
{
    public class AssetRepository : IGenericRepository<Asset>, IAssetRepository
    {
        private CrmDbContext _context;

        public AssetRepository(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task<Asset> InsertAsync(Asset entity)
        {
            await _context.Assets.AddAsync(entity);

            return entity;
        }

        public async Task<string> DeleteByIdAsync(int id)
        {
            var asset = _context.Assets.Find(id);

            if(asset == null)
            {
                return "No such Asset";
            }

            _context.Assets.Remove(asset);

            return "Asset " + id + " Deleted";
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TResult> Filter<TResult>(Expression<Func<Asset, bool>> filter, Expression<Func<Asset, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
